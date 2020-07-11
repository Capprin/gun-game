using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour {

    private float current_inv;
    private float current_flash;
    private SpriteRenderer sprite;

    public int health = 3;
    public float inv_time = 1.5f;
    public float flash_time = 0.1f;


    // Start is called before the first frame update
    void Start() {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        current_flash = flash_time;
    }

    // Update is called once per frame
    void Update() {
        if (current_inv > 0) {
            current_inv -= Time.deltaTime;

            // Handle flashing sprite while invuln
            if(current_flash > 0) {
                current_flash -= Time.deltaTime;
            }
            else {
                current_flash = flash_time;
                Color new_color = sprite.color;
                if(new_color.a == 1) {
                    new_color.a = 0.5f;
                }
                else {
                    new_color.a = 1f;
                }
                sprite.color = new_color;
            }
        }
        else {
            Color new_color = sprite.color;
            new_color.a = 1f;
            sprite.color = new_color;

            current_inv = 0;
        }
    }

    void OnCollisionStay2D(Collision2D coll) {
        if (coll.gameObject.tag == "Enemy") {
            if (current_inv <= 0) {
                health -= 1;
                current_inv = inv_time;
            }

            if (health <= 0) {
                Debug.Log("GAME OVER");
                Application.Quit();
            }
        }
    }
}
