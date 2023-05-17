//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.UI;

//public class CatController_v2 : MonoBehaviour
//{
//    private Rigidbody2D rb;
//    private Animator anim;
//    private SpriteRenderer sprite;

//     added by Yu:
//    private float boostTimer;
//    private bool boosting;
//    private float doubleJumping;
//    private bool doublejumping;
//    public float jumpForce = 20;
//    public float gravity = -9.81f;
//    float velocity;
//    [SerializeField]
//    private Text beanCounter;
//    private int beanAmount;
//    private float jumpheight = 30f;
//    public float jumpAmount = 30;
//     end of Yushitterie
//     also sorry for the amount of if's I take it on me - Yu


//    [SerializeField] private float speed = 7f;
//    [SerializeField] private float hjump = 9f;

//    private float dirX = 0f; //just for safety reasons
//     idle 0 , running 1, jumping 2, falling 3
//    private enum MoveMentState { idle, running, jumping, falling }


//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        sprite = GetComponent<SpriteRenderer>();
//        anim = GetComponent<Animator>();

//         Yu addition:
//        speed = 7;
//        boostTimer = 0;
//        boosting = false;
//        doublejumping = false;
//        beanAmount = 0;

//    }

//    void Update()
//    {
//        walking
//        dirX = Input.GetAxisRaw("Horizontal");
//        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

//        jumping
//        if (Input.GetButtonDown("Jump"))
//        {
//            rb.velocity = new Vector2(rb.velocity.x, hjump);
//        }

//        UpdateAnimationState();

//        if (boosting)
//        {
//            boostTimer += Time.deltaTime;
//            if (boostTimer >= 3)
//            {
//                speed = 7;
//                boostTimer = 0;
//                boosting = false;
//            }
//        }
//        if (doublejumping)
//        {
//            doubleJumping += Time.deltaTime;
//            if (doubleJumping >= 3)
//            {

//            }
//        }
//         bean counts
//        beanCounter.text = "Beans: " + beanAmount;
//    }

//     collision detection: (yu addon)
//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.tag == "SpeedBoost")
//        {
//            boosting = true;
//            speed = 14;
//        }

//        if (other.tag == "Bean")
//        {
//            beanAmount += 1;
//        }

//        if (other.tag == "JumpBoost")
//        {

//        }

//        Destroy(other.gameObject);
//         nie wiem czemu to sie na czerwono robi, ale dzia³a, nie ruszaæ - Yu
//    }



//    private void UpdateAnimationState()
//    {
//        MoveMentState state;

//        animations for running

//        if (dirX > 0f) //we move right
//        {
//            state = MoveMentState.running;
//            sprite.flipX = false;
//        }
//        else if (dirX < 0f) //we move left
//        {
//            state = MoveMentState.running;
//            sprite.flipX = true;
//        }
//        else //idle animation
//        {
//            state = MoveMentState.idle;
//        }

//        checking if we are jumping or falling

//        if (rb.velocity.y > .1f)
//        {
//            state = MoveMentState.jumping;
//        }
//        else if (rb.velocity.y < -.1f)
//        {
//            state = MoveMentState.falling;
//        }
//        anim.SetInteger("state", (int)state);
//    }
//}
