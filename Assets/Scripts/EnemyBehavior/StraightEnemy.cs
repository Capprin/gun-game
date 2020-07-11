using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightEnemy : BasicEnemy
{
    public float aimDelay = 1.0f;
    public float fireVel = 50f;

    private float aimTime;

    new void Start() {
        base.Start();
        aimTime = aimDelay;
        body = gameObject.GetComponent<Rigidbody2D>();
        if (lookingFor == null) {
            lookingFor = GameObject.Find("Player");
        }
    }

    void FixedUpdate() {
        if (aimTime > 0) {
            aimTime -= Time.fixedDeltaTime;
        } else {
            body.velocity = Vector3.zero;
            Fire();
            aimTime = aimDelay;
        }
    }

    void Fire() {
        // get unit vector to player location
        Vector2 toOther = lookingFor.transform.position - transform.position;
        toOther.Normalize();
        // apply force
        body.velocity += toOther * fireVel;
    }
}
