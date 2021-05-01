using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(playermovement))]
public class PlayerFire : MonoBehaviour
{

    SpriteRenderer megaSprite;

    public Transform spawnPointLeft;
    public Transform spawnPointRight;

    public float ProjectileSpeed;
    public Projectile projectilePrefab;
    
    void Start()
    {
        megaSprite = GetComponent<SpriteRenderer>();

        if (ProjectileSpeed <= 0)
            ProjectileSpeed = 7.0f;

        if (!spawnPointLeft || !spawnPointRight || !projectilePrefab)
            Debug.Log("Unity Inspector Values Not Set");
    }

   
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            
        }
    }
    void FireProjectile()
    {
        if (megaSprite.flipX)
        {

            Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);
            projectileInstance.speed = ProjectileSpeed = -50.0f;
        }
        else
        {
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointRight.position, spawnPointRight.rotation);
            projectileInstance.speed = ProjectileSpeed = 50.0f;
        }
    }


    void resetFire()
    {
    

    }
}
