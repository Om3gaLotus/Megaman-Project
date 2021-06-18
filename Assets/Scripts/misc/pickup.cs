using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
   public enum CollectibleType
    {
        POWERUP,
        COLLECTIBLE,
        LIVES

    }
   
    public CollectibleType currentCollectible;

    void Start()
    {
        
    }

 



    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            switch (currentCollectible)
            {
                case CollectibleType.COLLECTIBLE:
                   playermovement pmScript = collision.gameObject.GetComponent<playermovement>();
                    pmScript.score++;
                    Debug.Log(pmScript.score);
                    
                    break;
                case CollectibleType.LIVES:
                    pmScript = collision.gameObject.GetComponent<playermovement>();
                    pmScript.lives++;
                    break;
                case CollectibleType.POWERUP:
                    collision.gameObject.GetComponent<playermovement>().StartJumpForceChange();
                    break;
            }
            Destroy(gameObject);
        }
    }
}
