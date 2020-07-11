using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int damage = 8;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Wall") {
            Destroy(gameObject);
        }
    }
}
