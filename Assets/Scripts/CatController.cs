using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CatController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField]private float speed = 7f;
    [SerializeField] private float hjump = 9f;
  
    private float dirX = 0f; //just for safety reasons
    // idle 0 , running 1, jumping 2, falling 3
    private enum MoveMentState { idle, running, jumping, falling }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //walking
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        //jumping
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, hjump );
        }

        UpdateAnimationState(); 

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
}
