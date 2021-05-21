using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator),typeof(SpriteRenderer))]

public class EnemyTurret : MonoBehaviour
{
    Transform Player;
    private  float attackdistance = 10;
    public Transform projectileSpawnPoint;
    public Projectile projectilePrefab;
    
    SpriteRenderer turretidle;

    public float projectileForce;

    public float projectileFireRate;

    float timeSinceLastFire = 0.0f;
    public int health;

    Animator anim;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        turretidle = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();

        if (projectileForce <= 0)
        {
            projectileForce = 7.0f;
        }
        if (projectileFireRate <= 0)
        {
            projectileFireRate = 2.0f;
        }
        if (health <= 0)
        {
            health = 5;
        }
    }


    void Update()
    {
        

        if (Time.time >= timeSinceLastFire + projectileFireRate)
        {
            anim.SetBool("Fire", true);
            timeSinceLastFire = Time.time;
        }
    }
    public void Fire()
    {
        float distance = Vector3.Distance(Player.position, transform.position);

        if (distance <= attackdistance )
        {
            Projectile temp = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            temp.speed = -50;

        }

       
       
    }
    public void ReturnToIdle()
    {
        anim.SetBool("Fire", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayerProjectile")
        {
            health--;
            Destroy(collision.gameObject);
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    
       
   

    void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(transform.position, attackdistance);
    }
}
