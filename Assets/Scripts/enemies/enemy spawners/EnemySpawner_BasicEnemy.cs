using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_BasicEnemy : EnemySpawner {

    public override int GetPoints() {
        return 100;
    }

    public override string GetName() {
        return "BasicEnemy";
    }

}
