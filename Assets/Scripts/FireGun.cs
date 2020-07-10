using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float firing = Input.GetAxis("Fire1");

        // TODO - assuming exactly one gun-tagged object at all times; if the gun is lost we will crash
        if(firing > 0) {
            GameObject Gun = GameObject.FindGameObjectsWithTag("Gun")[0];
            Instantiate((UnityEngine.Object)Resources.Load("Bullet"), new Vector2(Gun.transform.position.x, Gun.transform.position.y), Quaternion.identity);
        }
    }
}
