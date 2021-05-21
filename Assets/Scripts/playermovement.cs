using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class playermovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer megaSprite;

    public float speed;
    public int jumpForce;
    public bool isGrounded;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;

    public int score = 0;
    public int lives = 3;

    bool coroutineRunning;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        megaSprite = GetComponent<SpriteRenderer>();

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
   
    // Update is called once per frame
    void Update()
    {

        

        if(Input.GetButton("Fire1"))
        {
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
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
        }

        Vector2 moveDirection = new Vector2(horizontalInput * speed, rb.velocity.y);
        rb.velocity = moveDirection;

        anim.SetFloat("speed", Mathf.Abs(horizontalInput));
        anim.SetBool("isGrounded", isGrounded);

        if (megaSprite.flipX && horizontalInput > 0 || !megaSprite.flipX && horizontalInput < 0)
            megaSprite.flipX = !megaSprite.flipX;

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



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "fall")
        {
            Destroy(gameObject);
        }

    }
}