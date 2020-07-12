using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModMovement : MonoBehaviour {

    public GameObject lookingFor;
    public float speed = 5.0f;
    public float speed_up_time_init = 0.2f;

    private float speed_up_time;

    private void Start() {
        lookingFor = GameObject.Find("Player");
        speed_up_time = speed_up_time_init;
    }

    // Update is called once per frame
    void FixedUpdate() {
        // Chase player
        transform.position = Vector2.MoveTowards(transform.position, lookingFor.transform.position, speed * Time.fixedDeltaTime);
        // Speed up every X seconds
        speed_up_time -= Time.deltaTime;
        if (speed_up_time < 0) {
            speed_up_time = speed_up_time_init;
            speed *= 1.5f;
        }
    }

    // Collide with player, give activate and destroy mod
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            GameObject dm = GameObject.FindGameObjectWithTag("GameController");
            ModManager mm = dm.GetComponent<ModManager>();
            mm.ActivateRandom();
            Destroy(gameObject);
        }
    }
}
