using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModIncreaseFireRate : Mod
{
    public override void Activate() {
        GameObject gun = GameObject.FindGameObjectWithTag("Gun");
        if (gun.GetComponent<FireGun>().fire_delay_init >= 4) {
            gun.GetComponent<FireGun>().fire_delay_init /= 2;
        }
    }

    public override string GetName() {
        return "Increased Fire Rate";
    }
}
