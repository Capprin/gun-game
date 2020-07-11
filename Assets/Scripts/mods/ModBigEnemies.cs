using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModBigEnemies : Mod
{
    public override void Activate() {
        BasicEnemy.scaleUp *= 1.5f;
    }

    public override string GetName() {
        return "Bigger Enemies";
    }
}
