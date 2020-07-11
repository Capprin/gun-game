using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModEnemySpeedBoost : Mod
{
    public override void Activate() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            enemy.GetComponent<BasicEnemy>().speed *= 1.05f;
        }
    }

    public override string GetName() {
        return "Enemy Speed Boost";
    }
}
