using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    public GameObject lookingFor = null;
    public float speed = 7;

    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        if (lookingFor == null) {
            lookingFor = GameObject.Find("Player");
        }
        body = GetComponent<Rigidbody2D>();
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
}
