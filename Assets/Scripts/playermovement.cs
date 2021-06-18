using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class playermovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer megaSprite;

    public float speed;
    public int jumpForce;
    public bool isGrounded;
    private bool isHurt = false;
    private bool isDead = false;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;
    private Transform Respawn;
    public int score = 0;
    public int lives = 3;
    private int health = 5;
    public AudioSource jump;
    public AudioSource hurt;
    public AudioSource shot;
    public AudioSource die;
    public AudioSource life;
    public AudioSource power;
    public Image[] healthMarker;
    public Image[] lifeMarker;

    bool coroutineRunning;
    // Start is called before the first frame update
    void Start()
    {
        

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        megaSprite = GetComponent<SpriteRenderer>();
        Respawn = GameObject.FindGameObjectWithTag("Respawn").transform;

        if (speed <= 0)
        {
            speed = 5.0f;
        }

        if (jumpForce <= 0)
        {
            jumpForce = 300;
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.2f;
        }

        if (!groundCheck)
        {
            Debug.Log("Groundcheck does not exist, please assign a ground check object");
        }

    }
   
    void Update()
    {


        

            if (Input.GetButton("Fire1"))
            {
                shot.Play();
                anim.SetBool("isAttacking", true);
            }
            else
            {

                anim.SetBool("isAttacking", false);
            }


            float horizontalInput = Input.GetAxisRaw("Horizontal");
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                jump.Play();
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * jumpForce);

            }

            Vector2 moveDirection = new Vector2(horizontalInput * speed, rb.velocity.y);
            rb.velocity = moveDirection;


            anim.SetFloat("speed", Mathf.Abs(horizontalInput));
            anim.SetBool("isGrounded", isGrounded);

            if (megaSprite.flipX && horizontalInput > 0 || !megaSprite.flipX && horizontalInput < 0)
                megaSprite.flipX = !megaSprite.flipX;


            if (lives <= 0)
            {

                Invoke("gameOver", 1);

            }

        for (int i = 0; i < healthMarker.Length; i++)
        {
            if (i < health)
            {
                healthMarker[i].enabled = false;
            }
            else
            {
                healthMarker[i].enabled = true;
            }
        }
        
        for (int i = 0; i < lifeMarker.Length; i++)
        {
            if (i < lives)
            {
                lifeMarker[i].enabled = true;
            }
            else
            {
                lifeMarker[i].enabled = false;
            }
        }



    }

    void gameOver()
    {
        SceneManager.LoadScene(2);
    }

     public void StartJumpForceChange()
    {
        if (!coroutineRunning)
        {
            StartCoroutine(JumpForceChange());
        }
        else
        {
            StopCoroutine(JumpForceChange());
            StartCoroutine(JumpForceChange());

        }    
     }

    IEnumerator JumpForceChange()
    {
        coroutineRunning = true;
        jumpForce = 600;
        yield return new WaitForSeconds(10.0f);
        jumpForce = 300;
        coroutineRunning = false;
    }



    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "fall")
        {
            if (lives > 1)
            {
                die.Play();
                lives--;
                transform.position = Respawn.position;
                health = 5;
            }
            else
            {
                anim.SetBool("isDead", true);
                lives--;
                die.Play();
            }
            
        }

        if (collision.gameObject.tag == "EnemyProjectile")


            if (health <= 1)
            {
                if (lives > 1)
                {
                    hurt.Play();
                    lives--;
                    transform.position = Respawn.position;
                    health = 5;
                }
                else
                {
                    anim.SetBool("isDead", true);
                    lives--;
                    die.Play();
                }
            }
            else
            {
                isHurt = true;
                anim.SetBool("isHurt", true);
                health--;
                hurt.Play();
                yield return new WaitForSeconds(0.1f);
                anim.SetBool("isHurt", false);
                isHurt = false;
            }

        if (collision.gameObject.tag == "Enemy")

            if (health <= 1)
            {

                if (lives > 1)
                {
                    hurt.Play();
                    lives--;
                    transform.position = Respawn.position;
                    health = 5;
                }
                else
                {
                    anim.SetBool("isDead", true);
                    lives--;
                    die.Play();
                }
            }
        else
            {
                isHurt = true;
                anim.SetBool("isHurt", true);
                hurt.Play();
                health--;
                yield return new WaitForSeconds(0.1f);
                anim.SetBool("isHurt", false);
                isHurt = false;
            }

        if (collision.gameObject.tag == "Power")
        {
            power.Play();
        }
        
    }


}