﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    public static float scaleUp = 1;
    public static float speedMod = 1;
    public GameObject lookingFor = null;
    public float speed = 7;
    public float health = 200;

    private SpriteRenderer sprite;
    private Rigidbody2D body;

    private Color color; 

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();

        transform.localScale *= scaleUp;
    }

    private void Update() {
        float r = 1-(health / 200f)-0.2f;
        float g = health / 200f-0.2f;
        float b = 0.8f;

        //Debug.Log("r: " + r + " g: " + g + " b: " + b);

        sprite.color = new Color(r,g,b);
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        // find player if lookingFor ever empties
        if (lookingFor == null) {
            lookingFor = GameObject.Find("Player");
        }
        // move towards other
        transform.position = Vector2.MoveTowards(transform.position,
                                                 lookingFor.transform.position,
                                                 speedMod * speed * Time.fixedDeltaTime);

        // TODO: rotate towards other (not needed atm; circle)
        // https://answers.unity.com/questions/1592029/how-do-you-make-enemies-rotate-to-your-position-in.html
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Bullet") {
            health -= other.GetComponent<Bullet>().damage;  // Take damage
            Destroy(other.gameObject);                      // Remove bullet
            if (health <= 0) {
                // On death, notify DM and remove self
                GameObject dm = GameObject.FindGameObjectWithTag("GameController");
                ModManager mm = dm.GetComponent<ModManager>();
                mm.enemyDies();
                Destroy(gameObject);
            }
        }
    }
}
