using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDeath : MonoBehaviour
{
    public int health;
    public AudioSource die;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            health--;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Invoke("destroy", 0.5f);
                die.Play();
            }
        }
    }

    void destroy()
    {
        Destroy(gameObject);
    }
}
