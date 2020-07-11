using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_SnakeEnemy : EnemySpawner
{
    public override int GetPoints() {
        return 700;
    }
    public override string GetName() {
        return "EnemySnake";
    }
}
