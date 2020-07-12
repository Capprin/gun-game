using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModMoreDamage : Mod
{
    public override void Activate() {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets) {
            bullet.GetComponent<Bullet>().damage *= 1.50f;
        }
    }

    public override string GetName() {
        return "More Damage";
    }
}
