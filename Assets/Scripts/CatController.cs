using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CatController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField]private float speed = 6f;
    [SerializeField] private float hjump = 9f;
  
    private float dirX = 0f; //just for safety reasons


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
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
        //animations for running
        if (dirX > 0f) //we move right
        {
            anim.SetBool("isRunning", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f) //we move left
        {
            anim.SetBool("isRunning", true);
            sprite.flipX = true;
        }
        else //idle animation
        {
            anim.SetBool("isRunning", false);
        }
    }
}
