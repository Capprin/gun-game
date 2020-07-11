using System.Collections;
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
    protected Rigidbody2D body;

    private Color color; 

    // Start is called before the first frame update
    public void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();

        transform.localScale *= scaleUp;
    }

    private void Update() {
        // find player if lookingFor ever empties
        if (lookingFor == null) {
            lookingFor = GameObject.Find("Player");
        }

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
                                                 speedMod * speed * Time.fixedDeltaTime);

        // TODO: rotate towards other (not needed atm; circle)
        // https://answers.unity.com/questions/1592029/how-do-you-make-enemies-rotate-to-your-position-in.html
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Bullet") {
            health -= other.GetComponent<Bullet>().damage;  // Take damage
            Destroy(other.gameObject);                      // Remove bullet
            if (health <= 0) {
                // On death, spawn powerup and remove self
                if (Random.Range(0.0f, 1.0f) > 0.75f) {
                    GameObject mod = (GameObject)Instantiate(Resources.Load("Mod"), transform.position, transform.rotation);
                }
                Destroy(gameObject);
            }
        }
    }
}
