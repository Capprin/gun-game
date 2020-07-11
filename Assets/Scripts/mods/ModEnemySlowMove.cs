using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModEnemySlowMove : Mod
{
    public override void Activate() {
        BasicEnemy.speedMod *= 0.95f;
    }

    public override string GetName() {
        return "Enemy Slow Move";
    }

}
