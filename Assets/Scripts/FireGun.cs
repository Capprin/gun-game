using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{

    GameObject Gun;
    public int fire_delay_init = 60;
    public int bullet_speed = 2000;

    int fire_delay;
    bool can_fire = true;

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

        // TODO - assuming exactly one gun-tagged object at all times; if the gun is lost we will crash
        if (can_fire) {
            if (firing > 0) {
                can_fire = false;
                GameObject Bullet = (GameObject)Instantiate(Resources.Load("Bullet"), transform.position, transform.rotation);
                Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
                rb.AddRelativeForce(new Vector2(bullet_speed,0));   
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
