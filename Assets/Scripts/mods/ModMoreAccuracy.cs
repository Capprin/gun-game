using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModMoreAccuracy : Mod
{
    public override void Activate() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponentInChildren<FireGun>().accuracy = 0.95f;
    }

    public override string GetName() {
        return "Deadshot";
    }
}
