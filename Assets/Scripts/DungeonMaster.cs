﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMaster : MonoBehaviour {

    private int enemiesAlive = 0;

    // Start is called before the first frame update
    void Start() {
        // do initial setup
        ResetRoom();
    }

    // Update is called once per frame
    void Update() {
        // check if all enemies dead
        if (enemiesAlive == 0) {
            Cleanup();
            ResetRoom();
        }
    }

    void ResetRoom() {
        // create player
        GameObject player = (GameObject) Instantiate(Resources.Load("Player"),
                                                     new Vector3(0, 0, 0),
                                                     Quaternion.identity);
        player.name = "Player";

        // create enemies
        GameObject[] enemies = new GameObject[4];
        for (int i = 0; i < 4; i++) {
            // random pos
            Vector3 ePos = new Vector3(Random.Range(-10.0f, 10.0f),
                               Random.Range(-10.0f, 10.0f),
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

    }
}