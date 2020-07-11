using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModSlowMove : Mod
{
    public override void Activate() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerMovement>().speed *= 0.7f;
    }

    public override string GetName() {
        return "Slow Move";
    }
}
