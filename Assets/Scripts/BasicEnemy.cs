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

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Bullet") {
            health -= other.GetComponent<Bullet>().damage;
            Destroy(other.gameObject);
            if (health <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
