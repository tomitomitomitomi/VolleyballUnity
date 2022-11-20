using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Player character movement and actions are handled here
/// </summary>
public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;

    //movement
    [SerializeField] private int jumpCount;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private bool facingRight = true;

    //groundcheck
    [SerializeField] private float groundCheckLength;
    [SerializeField] private float len;
    [SerializeField] private LayerMask ground;
    private bool isGrounded;

    //dashing
    [SerializeField] private float dashSpeed;
    private float dashCount = 1;
    private bool canDash;

    //audio & animator
    Animator roboAnimator;
    AudioSource roboAudio;
    [SerializeField] private AudioClip audioJump;
    [SerializeField] private AudioClip audioHit;
    [SerializeField] private AudioClip audioDash;
   


    //button mapping
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode jump;
    [SerializeField] private KeyCode hit;
    [SerializeField] private KeyCode dash;



    // Getting rigidbody and animator for player and flipping player 2
    void Start() {

        rb = GetComponent<Rigidbody2D>();
        roboAnimator = GetComponent<Animator>();
        roboAudio = GetComponent<AudioSource>();
        CanDash();
        // Flipping player 2 character at the start of a match
        if (this.gameObject.tag == "Player2")
        {
            Flip();
        }
    }

    /// <summary>
    /// Flipping the player sprite on x axis
    /// </summary>
    private void Flip()
    {
        facingRight = !facingRight;
        Vector2 facing = transform.localScale;

        facing.x *= -1;
        transform.localScale = facing;
    }

    /// <summary>
    /// Checking if player is on ground with raycast and resetting jumpcount if grounded
    /// </summary>
    private void GroundCheck()
    {
        Vector3 position = rb.position;
        Vector3 direction = new Vector3(0, -len, 0);

        //Drawing ray downwards from player
        Debug.DrawRay(position, direction, Color.red);
        RaycastHit2D raycast = Physics2D.Raycast(position, direction, groundCheckLength, ground);

        
        // checking if raycast hits something on ground layer
        if (raycast.collider != null)
        {
            //Debug.Log(this.gameObject.name + " grounded");
            isGrounded = true;
            jumpCount = 2;
            dashCount = 2;
            
        } else
        {
            //Debug.Log(this.gameObject.name + " not grounded");
            isGrounded = false;
            
        }
    }

    /// <summary>
    /// Giving player velocity on y.axis when jump button is pressed
    /// </summary>
    void Jump()
    {
        //Checking if grounded or enough airjumps left to allow jumping
        if (jumpCount > 1 && Input.GetKeyDown(jump) || Input.GetKeyDown(jump) && isGrounded)
        {
            roboAudio.PlayOneShot(audioJump);
            Debug.Log("jumping " + jumpCount);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
        }
    }
    /// <summary>
    /// Handling player movement
    /// </summary>
    void Moving()
    {
        // Moving left
        if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            roboAnimator.SetBool("anim_move", true);
        // Moving right
        }
        else if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            roboAnimator.SetBool("anim_move", true);
        }
        else
        {
        // If not moving, stay still
            rb.velocity = new Vector2(0, rb.velocity.y);
            roboAnimator.SetBool("anim_move", false);
        }

    }

    /// <summary>
    /// Playing hammer hit animation when button "hit" is pressed
    /// </summary>
    void HammerHit()
    {
        if (Input.GetKeyDown(hit))
        {
            roboAnimator.SetBool("anim_hit", true);
            roboAudio.PlayOneShot(audioHit);
        }
        else
        {
            roboAnimator.SetBool("anim_hit", false);
        }
    }
    /// <summary>
    /// restricting airdashing in volleyball mode
    /// </summary>
    /// <returns></returns>
    void CanDash()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "VolleyBallVsP"
           || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "VolleyBallVsC")
        {
             canDash = false;
        }
        else
        {
            canDash = true;
        }
    }

    /// <summary>
    ///  Allowing player to a quick dash forwards when airborne
    /// </summary>
    void Dash()
    {
        
            //Dashing when facing right
            if (Input.GetKeyDown(dash) && facingRight && !isGrounded && dashCount >= 1 && canDash)
        {
            
            Debug.Log("dash");
            roboAudio.PlayOneShot(audioDash);
            rb.velocity = new Vector2(dashSpeed, rb.velocity.y);
            dashCount = 0;
            
        }
        //Dashing when facing left
        if (Input.GetKeyDown(dash) && !facingRight && !isGrounded && dashCount >= 1 && canDash)
        {
            
            Debug.Log("dash");
            roboAudio.PlayOneShot(audioDash);
            rb.velocity = new Vector2(-dashSpeed, rb.velocity.y);
            dashCount = 0;
        }
    }
    // Update is called once per frame
    void Update () {

        
        //Checks if player is touching ground
        GroundCheck();

        // Player movement
        Moving();

        // Jumps when associated button is pressed and reduces available jumps by one
        Jump();

        //Hitting with hammer
        HammerHit();

        //Dash forwards when associated button is pressed
        Dash();

        //flipping if player is facing left and moving right
        if (rb.velocity.x > 0 && !facingRight)
        {
            Flip();
        }
        //flipping if player is facing right and moving left
        if (rb.velocity.x < 0 && facingRight)
        {
            Flip();
        }



    }




    //handle physics based actions here

    private void FixedUpdate()
    {
        
    }
}
