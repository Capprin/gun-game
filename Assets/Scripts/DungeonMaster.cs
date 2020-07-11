using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMaster : MonoBehaviour {

    public Vector2 xRange = new Vector2(-14, 14);
    public Vector2 yRange = new Vector2(-10, 10);
    public int points_init = 500;
    public float enemy_respawn_time_init = 5.0f;
    public bool reset = false;

    private ModManager modManager;
    private GameObject player;
    private int points;
    private List<EnemySpawner> enemy_types;
    private float enemy_respawn_time;
    private int few_enemy_threshold;

    // Start is called before the first frame update
    void Start() {

        // Populate list of enemy types
        enemy_types = new List<EnemySpawner>();
        enemy_types.Add(new EnemySpawner_BasicEnemy());
        enemy_types.Add(new EnemySpawner_BasicEnemyElite());
        enemy_types.Add(new EnemySpawner_GunEnemy());
        enemy_types.Add(new EnemySpawner_SnakeEnemy());
        enemy_types.Add(new EnemySpawner_GunSnake());
        points = points_init;
        enemy_respawn_time = enemy_respawn_time_init;
        few_enemy_threshold = 2;

        // create modManager if not already exists
        ModManager maybeManager = gameObject.GetComponent<ModManager>();
        if (maybeManager == null) {
            modManager = gameObject.AddComponent<ModManager>() as ModManager;
        } else {
            modManager = maybeManager;
        }
        // create player
        player = (GameObject) Instantiate(Resources.Load("Player"),
                                                     new Vector3(0, 0, 0),
                                                     Quaternion.identity);
        player.name = "Player";

        // do initial setup
        SpawnEnemies();
    }

    // Handle timer stuff here
    private void FixedUpdate() {
        // Respawn enemies every X seconds
        enemy_respawn_time -= Time.deltaTime;
        if(enemy_respawn_time < 0) {
            enemy_respawn_time = enemy_respawn_time_init;
            SpawnEnemies();
        }
    }

    void Update() {  
        // If there are too few enemies remaining spawn more!
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length <= few_enemy_threshold) {
            SpawnEnemies();
            few_enemy_threshold++;  // If killed all enemies, spawn reinforcements mor readily
        }
    }

    void SpawnEnemies() {

        // Check list of enemy types to see which enemies we can spawn with our max points
        List<EnemySpawner> valid_enemy_types = new List<EnemySpawner>();
        for(int i = 0; i < enemy_types.Count; i++) {
            if(enemy_types[i].GetPoints() < points) {
                valid_enemy_types.Add(enemy_types[i]);
            } 
        }

        while (valid_enemy_types.Count > 0) {

            // Check list of enemy types to see which enemies we can spawn this turn
            // Get random position for the next enemy!
            Vector3 ePos = new Vector3(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y), 0); // Random position
            while (Vector3.Distance(player.transform.position, ePos) < 5.0f) {
                ePos = new Vector3(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y), 0); // Reroll if too close to player
            }

            // Choose enemy randomly
            EnemySpawner enemy = valid_enemy_types[Random.Range(0, valid_enemy_types.Count)];
            points -= enemy.GetPoints();
            Instantiate(Resources.Load(enemy.GetName()), ePos, Quaternion.identity);


            // Prune invalid enemies again
            valid_enemy_types = new List<EnemySpawner>();
            for (int i = 0; i < enemy_types.Count; i++) {
                if (enemy_types[i].GetPoints() < points) {
                    valid_enemy_types.Add(enemy_types[i]);
                }
            }
        }

        // Reset and increase point counter
        points_init += 40;
        points = points_init;
    }

    void Cleanup() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            Destroy(enemy);
        }
    }
}
