using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModBigBullets : Mod
{

    public float capScale = 12;

    private static float currentScale;
    public override void Activate() {
        GameObject gun = GameObject.FindGameObjectWithTag("Gun");
        if (gun.GetComponent<FireGun>().bullet_scale < capScale) {
            gun.GetComponent<FireGun>().bullet_scale *= 1.5f;
            Debug.Log("Scaling up");
        } else {
            Debug.Log("Not scaling up");
        }

        AudioSource audio_source = gun.GetComponent<AudioSource>();
        audio_source.pitch *= 0.9f;
    }

    public override string GetName() {
        return "Big Bullets";
    }
}
