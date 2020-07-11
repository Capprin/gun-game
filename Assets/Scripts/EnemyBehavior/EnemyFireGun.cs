using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireGun : MonoBehaviour
{

    public float fire_frequency = 2.0f;
    public float accuracy = 0.85f;
    public float bullet_speed = 1000;

    private float current_fire;
    private AudioSource audio_source;

    void Start()
    {
        current_fire = fire_frequency;
        audio_source = GetComponent<AudioSource>();
    }

    void Update()
    {
        // timer for firing
        if (current_fire > 0) {
            current_fire -= Time.deltaTime;
        } else {
            Fire();
            current_fire = fire_frequency;
        }
    }

    void Fire() {
        float fireCone = 90f - 90f * accuracy;
        float dirMod = Random.Range(-fireCone/2f, fireCone/2f);

        GameObject bullet = (GameObject)Instantiate(Resources.Load("Bullet"), transform.position, transform.rotation);
        bullet.tag = "EnemyBullet";
        bullet.transform.Rotate(Vector3.forward * dirMod);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bullet_speed * bullet.transform.right);

        // Sound
        audio_source.Play(0);
    }
}
