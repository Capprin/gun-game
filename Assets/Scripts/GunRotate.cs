using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{

    private Vector3 setScale = new Vector3(7, 7, 0);
    void Start() {
        setScale = transform.localScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float joyX = Input.GetAxis("Joy X");
        float joyY = Input.GetAxis("Joy Y");

        // flip sprite according to joy x
        if (joyX < 0) {
            Vector3 newScale = setScale;
            newScale.y *= -1;
            transform.localScale = newScale;
        } else {
            transform.localScale = setScale;
        }

        float joyAngle = Mathf.Atan2(-joyY, joyX) * Mathf.Rad2Deg;
        joyAngle = (joyAngle + 360) % 360; //go 0-360 instead of with neg

        float delta = joyAngle - transform.eulerAngles.z;
        transform.RotateAround(transform.parent.transform.position,
                               new Vector3(0, 0, 1),
                               delta);
    }
}
