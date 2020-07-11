using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_GunEnemy : EnemySpawner
{
    public override int GetPoints() {
        return 250;
    }
    public override string GetName() {
        return "EnemyGun";
    }
}
