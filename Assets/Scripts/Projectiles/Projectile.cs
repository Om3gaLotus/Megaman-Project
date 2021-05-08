using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]

public class Projectile: MonoBehaviour
{
    public float speed;
    public float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        if (lifetime <= 0)
        {
            lifetime = 2.0f;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        Destroy(gameObject, lifetime);
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag != "Player" || col.gameObject.tag != "pickup")
        {
            Destroy(gameObject);
            Debug.Log("you got it");
        }
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
