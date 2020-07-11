using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_BasicEnemyElite : EnemySpawner {

    public override int GetPoints() {
        return 170;
    }

    public override string GetName() {
        return "BasicEnemyElite";
    }

}
