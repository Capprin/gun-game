using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeEnemy : MonoBehaviour
{
    public int length = 7;
    public int speed = 3;
    public float head_health = 200;
    public string prefab = "BasicEnemy";
    void Start()
    {
        // set up snake
        gameObject.GetComponent<BasicEnemy>().speed = speed;
        gameObject.GetComponent<BasicEnemy>().health = head_health;
        AddNodes(gameObject, length);
    }

    void AddNodes(GameObject target, int remaining) {
        if (remaining == 0) {
            return;
        }
        // create enemy node
        GameObject node = (GameObject) Instantiate(Resources.Load(prefab),
                                                   target.transform.position,
                                                   target.transform.rotation);
        // offset by a bit
        SpriteRenderer sprite = target.GetComponent<SpriteRenderer>();
        node.transform.position -= sprite.bounds.size.x * node.transform.right;
        // modify properties
        node.GetComponent<BasicEnemy>().lookingFor = target;
        node.GetComponent<BasicEnemy>().speed = speed;
        node.GetComponent<BasicEnemy>().health = target.GetComponent<BasicEnemy>().health - head_health/((float)length);
        Debug.Log(node.GetComponent<BasicEnemy>().health);
        // recurse
        AddNodes(node, remaining-1);
    }
}
