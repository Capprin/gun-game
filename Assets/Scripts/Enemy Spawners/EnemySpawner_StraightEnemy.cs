using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_StraightEnemy : EnemySpawner
{
    public override int GetPoints() {
        return 100;
    }

    public override string GetName() {
        return "StraightEnemy";
    }
}
