using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator),typeof(SpriteRenderer))]

public class EnemyTurret : MonoBehaviour
{
    Transform Player;
    private  float attackdistance = 10;
    public Transform projectileSpawnPoint;
    public Transform projectileSpawnPointR;
    public Projectile projectilePrefab;
    
    SpriteRenderer turretidle;

    public float projectileForce;

    public float projectileFireRate;

    float timeSinceLastFire = 0.0f;
    public int health;
    public AudioSource fire;
    


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
        if (Player.position.x > transform.position.x)
        {
            turretidle.flipX = true;
        }
        if (Player.position.x < transform.position.x)
        {
            turretidle.flipX = false;
        }

        if (Time.time >= timeSinceLastFire + projectileFireRate)
        {
            anim.SetBool("Fire", true);
            timeSinceLastFire = Time.time;
        }
    }
    public void Fire()
    {
        float distance = Vector3.Distance(Player.position, transform.position);

        if (distance <= attackdistance)
        {
            if (turretidle.flipX == false)
            {
                Projectile temp = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
                temp.speed = -50;
                fire.Play();
            }
            if (turretidle.flipX == true)
            {
                Projectile temp = Instantiate(projectilePrefab, projectileSpawnPointR.position, projectileSpawnPointR.rotation);
                temp.speed = 50;
                fire.Play();
            }

        }

       
       
    }
    public void ReturnToIdle()
    {
        anim.SetBool("Fire", false);
    }

   

    void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(transform.position, attackdistance);
    }
}
