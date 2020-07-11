using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModEnemySlowMove : Mod
{
    public override void Activate() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            enemy.GetComponent<BasicEnemy>().speed *= 0.95f;
        }
    }

    public override string GetName() {
        return "Enemy Slow Move";
    }
}
