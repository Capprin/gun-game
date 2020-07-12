using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModSpeedBoost : Mod
{
    public override void Activate() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerMovement>().speed *= 1.30f;
    }

    public override string GetName() {
        return "Speed Boost";
    }
}
