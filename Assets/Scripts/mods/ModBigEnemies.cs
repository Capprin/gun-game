using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModBigEnemies : Mod
{
    public override void Activate() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            enemy.transform.localScale *= 1.5f;
        }
    }

    public override string GetName() {
        return "Bigger Enemies";
    }
}
