using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModBigEnemies : Mod
{
    public float capScale = 4;
    public override void Activate() {
        if (BasicEnemy.scaleUp < capScale) {
            BasicEnemy.scaleUp *= 1.5f;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies) {
                enemy.transform.localScale *= 1.5f;
            }
        }
    }

    public override string GetName() {
        return "Bigger Enemies";
    }
}
