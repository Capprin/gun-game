using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{

    GameObject Gun;
    public int fire_delay_init = 60;
    public float bullet_speed = 2000;
    public float bullet_scale = 1;

    // should be between 0 and 1
    public float accuracy = 0.9f;
    public float max_fire_cone = 90;

    private int fire_delay;
    private bool can_fire = true;

    // Start is called before the first frame update
    void Start()
    {
        //Gun = GameObject.FindGameObjectsWithTag("Gun")[0];
        fire_delay = fire_delay_init;
    }

    // Update is called once per frame
    void Update()
    {
        float firing = Input.GetAxis("Fire1");

        // assuming exactly one gun-tagged object at all times
        // if the gun is lost we will crash
        if (can_fire) {
            if (firing > 0) {
                // compute fire accuracy
                float fireCone = 90f - 90f * accuracy;
                float dirMod = Random.Range(-fireCone/2f, fireCone/2f);

                GameObject bullet = (GameObject)Instantiate(Resources.Load("Bullet"), transform.position, transform.rotation);
                bullet.transform.localScale = bullet.transform.localScale * bullet_scale;
                bullet.transform.Rotate(Vector3.forward * dirMod);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(bullet_speed * bullet.transform.right);

                can_fire = false;
            }
        }
        else {
            fire_delay--;
            if(fire_delay == 0) {
                fire_delay = fire_delay_init;
                can_fire = true;
            }
        }
    }
}
