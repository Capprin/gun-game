using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_GunSnake : EnemySpawner
{
    public override int GetPoints() {
        return 1000;
    }
    public override string GetName() {
        return "GunSnake";
    }
}
