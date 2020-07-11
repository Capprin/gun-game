using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModBigBullets : Mod
{
    public override void Activate() {
        GameObject gun = GameObject.FindGameObjectWithTag("Gun");
        gun.GetComponent<FireGun>().bullet_scale *= 2;
        AudioSource audio_source = gun.GetComponent<AudioSource>();
        audio_source.pitch *= 0.9f;
    }

    public override string GetName() {
        return "Big Bullets";
    }
}
