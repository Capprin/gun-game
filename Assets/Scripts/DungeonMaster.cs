using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMaster : MonoBehaviour {

    public Vector2 xRange = new Vector2(-14, 14);
    public Vector2 yRange = new Vector2(-10, 10);

    public bool reset = false;

    private int enemiesAlive = 0;
    private ModManager modManager;
    private GameObject player;

    // Start is called before the first frame update
    void Start() {
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
        // create enemies
        GameObject[] enemies = new GameObject[4];
        for (int i = 0; i < 4; i++) {
            // random pos
            Vector3 ePos = new Vector3(Random.Range(xRange.x, xRange.y),
                               Random.Range(yRange.x, yRange.y),
                               0);
            // instantiate
            enemies[i] = (GameObject) Instantiate(Resources.Load("Enemy"),
                                                 ePos,
                                                 Quaternion.identity);
            // set to follow player
            enemies[i].GetComponent<BasicEnemy>().lookingFor = player;

            enemiesAlive++;
        }
        
        // create traps
    }

    void Cleanup() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            Destroy(enemy);
        }
    }
}
