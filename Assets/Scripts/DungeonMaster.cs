using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMaster : MonoBehaviour {

    public Vector2 xRange = new Vector2(-14, 14);
    public Vector2 yRange = new Vector2(-10, 10);
    public int points_init = 500;

    public bool reset = false;

    private int enemiesAlive = 0;
    private ModManager modManager;
    private GameObject player;
    private int points;
    private List<EnemySpawner> enemy_types;

    // Start is called before the first frame update
    void Start() {

        // Populate list of enemy types
        enemy_types = new List<EnemySpawner>();
        enemy_types.Add(new EnemySpawner_BasicEnemy());
        enemy_types.Add(new EnemySpawner_BasicEnemyElite());
        enemy_types.Add(new EnemySpawner_GunEnemy());
        points = points_init;

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
        ResetRoom();
    }

    // Update is called once per frame
    void Update() {  
        // check if all enemies dead
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length == 0 || reset) {
            Cleanup();
            ResetRoom();
            modManager.ActivateRandom();
            reset = false;
        }
    }

    void ResetRoom() {

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
            Vector3 ePos = new Vector3(Random.Range(xRange.x, xRange.y),
                               Random.Range(yRange.x, yRange.y),
                               0);
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
        points_init += 100;
        points = points_init;
    }

    void Cleanup() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            Destroy(enemy);
        }
    }
}
