using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mod_increaseFireRate : mod
{
    GameObject gun;

    public override void Activate() {
        gun = GameObject.FindGameObjectWithTag("Gun");
        gun.GetComponent<FireGun>().fire_delay_init /= 2;
    }
}
