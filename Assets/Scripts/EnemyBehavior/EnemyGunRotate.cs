using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunRotate : MonoBehaviour
{

    public GameObject lookingFor = null;

    private Vector3 setScale = new Vector3(-2, 2, 0);

    void Start()
    {
        if (lookingFor == null) {
            lookingFor = GameObject.Find("Player");
        }
        setScale = transform.localScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // flip sprite according to local angle
        bool onRight = transform.eulerAngles.z < 90 || transform.eulerAngles.z > 270;
        if (!onRight) {
            Vector3 newScale = setScale;
            newScale.y *= -1;
            transform.localScale = newScale;
        } else {
            transform.localScale = setScale;
        }

        // get angle to player
        Vector2 toOther = lookingFor.transform.position - transform.position;
        float localOtherAngle = Mathf.Atan2(toOther.y, toOther.x) * Mathf.Rad2Deg;
        localOtherAngle = (localOtherAngle + 360) % 360;

        // do rotation
        float delta = localOtherAngle - transform.eulerAngles.z;
        transform.RotateAround(transform.parent.transform.position,
                               Vector3.forward,
                               delta);
    }
}
