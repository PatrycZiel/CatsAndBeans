using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CatController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float speed = 7f;
    [SerializeField] private float hjump = 9f;
  
    private float dirX = 0f; //just for safety reasons
    // idle 0 , running 1, jumping 2, falling 3
    private enum MoveMentState { idle, running, jumping, falling }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        //walking
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        Jump();

        UpdateAnimationState();


    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, hjump);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpeedBoost")
        {
            StartCoroutine(SpeedBoostTimer());
            Destroy(other.gameObject);
        }

        if (other.tag == "Leaf")
        {
            StartCoroutine(StopTimer());
            Destroy(other.gameObject);
        }
        

        if(other.tag == "Mocha")
        {
            StartCoroutine(JumpBoostTimer());
            StartCoroutine(SpeedBoostTimer());
            Destroy(other.gameObject);
        }

        if(other.tag == "JumpBoost")
        {
            StartCoroutine(JumpBoostTimer());
            Destroy(other.gameObject);
        }

        if (other.tag == "Caramel")
        {
            StartCoroutine(Stuck());
        }

       
    }

    private IEnumerator JumpBoostTimer()
    {
        hjump *= 2;
        yield return new WaitForSeconds(3f);
        hjump /= 2;
    }

    private IEnumerator SpeedBoostTimer()
    {
        speed *= 2;
        yield return new WaitForSeconds(3f);
        speed /= 2;
    }

    private IEnumerator StopTimer()
    {
        speed = 0;
        yield return new WaitForSeconds(3f);
        speed = 7;
    }

    private IEnumerator Stuck()
    {
        speed /= 2;
        hjump = 6;
        yield return new WaitForSeconds(3f);
        speed *= 2;
        hjump = 9; 

    }


    private void UpdateAnimationState()
    {
        MoveMentState state;

        //animations for running

        if (dirX > 0f) //we move right
        {
            state = MoveMentState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f) //we move left
        {
            state = MoveMentState.running;
            sprite.flipX = true;
        }
        else //idle animation
        {
            state = MoveMentState.idle;
        }

        //checking if we are jumping or falling

        if (rb.velocity.y > .1f)
        {
            state = MoveMentState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MoveMentState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
