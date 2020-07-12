using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour {

    private float current_inv;
    private float current_flash;
    private SpriteRenderer sprite;
    private bool gameover = false;
    // Sound
    public AudioClip hurt_sound;
    public AudioClip gameover_sound;
    AudioSource hurt_audio;
    AudioSource gameover_audio;

    public int health = 3;
    public float inv_time = 1.5f;
    public float flash_time = 0.1f;


    // Start is called before the first frame update
    void Start() {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        current_flash = flash_time;
        // Sounds
        hurt_audio = gameObject.AddComponent<AudioSource>();
        hurt_audio.clip = hurt_sound;
        hurt_audio.playOnAwake = false;
        hurt_audio.volume = 1f;
        gameover_audio = gameObject.AddComponent<AudioSource>();
        gameover_audio.clip = gameover_sound;
        gameover_audio.playOnAwake = false;
        gameover_audio.volume = 0.5f;

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
                    new_color.a = 0.2f;
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

    void TakeDamage() {
        if (current_inv <= 0) {
            health -= 1;
            hurt_audio.Play(0);
            current_inv = inv_time;
        }

        if (health <= 0 && !gameover) {
            gameover = true;
            Debug.Log("GAME OVER");
            gameover_audio.Play(0);
            Application.Quit();
        }
    }

    void OnCollisionStay2D(Collision2D coll) {
        if (coll.gameObject.tag == "Enemy") {
            TakeDamage();
        }
    }

    void OnCollision2D(Collision2D coll) {
        if (coll.gameObject.tag == "Enemy") {
            TakeDamage();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "EnemyBullet") {
            Destroy(other.gameObject);
            TakeDamage();
        }
    }
}
