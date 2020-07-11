using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    public GameObject lookingFor = null;
    public float speed = 7;
    public int health = 200;

    private SpriteRenderer sprite;
    private Rigidbody2D body;

    private Color color; 

    // Start is called before the first frame update
    void Start()
    {
        if (lookingFor == null) {
            lookingFor = GameObject.Find("Player");
        }
        body = GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update() {
        //float frequency = .02f;
        //r = (float)(Mathf.Sin(frequency * health + 0) + 0.5);
        //g = (float)(Mathf.Sin(frequency * health + 2*Mathf.PI/3) + 0.5);
        //b = (float)(Mathf.Sin(frequency * health + 4*Mathf.PI/3) + 0.5);

        /*
        if(health <= 20)
            color = new Color(1, 0, 0);
        else if (health <= 30)
            color = new Color(1, 0.25f, 0);
        else if(health <= 40)
            color = new Color(1, 0.5f, 0);
        else if (health <= 50)
            color = new Color(1, 0.75f, 0);
        else if(health <= 60)
            color = new Color(1, 1, 0);
        else if (health <= 70)
            color = new Color(0.75f, 1, 0);
        else if(health <= 80)
            color = new Color(0.5f, 1, 0);
        else if (health <= 90)
            color = new Color(0.25f, 1, 0);
        else if (health <= 100)
            color = new Color(0, 1, 0);
        else if (health <= 110)
            color = new Color(0, 1, 0.25f);
        else if (health <= 120)
            color = new Color(0, 1, 0.5f);
        else if (health <= 130)
            color = new Color(0, 1, 0.75f);
        else if (health <= 140)
            color = new Color(0, 1, 1);
        else if (health <= 150)
            color = new Color(0, 0.75f, 1);
        else if (health <= 160)
            color = new Color(0, 0.5f, 1);
        else if (health <= 170)
            color = new Color(0, 0.25f, 1);
        else if (health <= 180)
            color = new Color(0, 0, 1);
        else if (health <= 190)
            color = new Color(0.25f, 0, 1);
        else
            color = new Color(0.5f, 0, 1);
        */

        float r = 1-(health / 200f)-0.2f;
        float g = health / 200f-0.2f;
        float b = 0.8f;

        //Debug.Log("r: " + r + " g: " + g + " b: " + b);

        sprite.color = new Color(r,g,b);
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        // move towards other
        transform.position = Vector2.MoveTowards(transform.position,
                                                 lookingFor.transform.position,
                                                 speed * Time.fixedDeltaTime);

        // TODO: rotate towards other (not needed atm; circle)
        // https://answers.unity.com/questions/1592029/how-do-you-make-enemies-rotate-to-your-position-in.html
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Bullet") {
            health -= collision.gameObject.GetComponent<Bullet>().damage;
            Destroy(collision.gameObject);
            if (health <= 0) {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("TRIGGER");
        if (other.tag == "Bullet") {
            health -= other.GetComponent<Bullet>().damage;
            Destroy(other.gameObject);
            if (health <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
