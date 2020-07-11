using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModBigBullets : Mod
{
    public override void Activate() {
        GameObject gun = GameObject.FindGameObjectWithTag("Gun");
        gun.GetComponent<FireGun>().bullet_scale *= 2;
    }

    public override string GetName() {
        return "Big Bullets";
    }
}
