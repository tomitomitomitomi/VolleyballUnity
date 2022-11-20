using System.Collections;
using UnityEngine;

/// <summary>
/// AIController controls the AI player's functions, movement, jump, hit, etc.
/// </summary>
public class AIController : MonoBehaviour {
    // Fields
    private Transform ball; // Ball objects transform
    private Rigidbody2D rb; // AI player objects Rigidbody
    private Animator roboAnimator; // Animator for AI player object
    private Vector2 aiVector; // AI player vector2 for movement
    private Vector2 ballVector; // Ball vector2 for movement
   
    [SerializeField] private int jumpCount; // How many jumps can be done
    [SerializeField] private float moveSpeed; // Movement speed
    [SerializeField] private float jumpForce; // Force for jumping

    //Setting up audio
    AudioSource roboAudio;
    [SerializeField]
    AudioClip audioJump;
    [SerializeField]
    private AudioClip audioHit;

    private bool facingRight = true; // Used for flipping character sprite

    // Fields used for ground check
    [SerializeField] private float groundCheckLength;
    [SerializeField] private float len;
    private bool isGrounded;
    public LayerMask ground;

    
    private float jumpDistance; // Distance to ball when AI jumps towards it.
    private float hitDistance; // Distance to ball when AI hits it.

    // Use this for initialization
    void Start () {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        roboAnimator = GetComponent<Animator>();
        roboAudio = GetComponent<AudioSource>();


        // Set values for jumpDistance and hitDistance
        jumpDistance = 2f;
        hitDistance = 1.5f;


        // If player2 is facing right in the start, flip the sprite
        if (this.gameObject.tag == "player2")
        {
            Flip();
        }

    }

	
	// Update is called once per frame
	void Update () {

        // Set Vector2:s for AI player and Ball. Used to determine moving direction for AI player.
        // This needs to be in update in order to constantly update the position of the AI and Ball.
        aiVector = new Vector2(rb.transform.position.x, rb.transform.position.y);
        ballVector = new Vector2(ball.transform.position.x, ball.transform.position.y);

        // Checking if AI character is on ground (used for multijump)
        GroundCheck();

        // AI movement
        AIMovement();

        // AI jump
        AiJump();

        // Flip player sprite when moving
        PlayerFlip();

        // Hitting the ball with hammer
        StartCoroutine(HitHammer());


    }

    /// <summary>
    /// GroundCheck() Checks if the player is grounded. Resets jumpcount when grounded.
    /// </summary>
    private void GroundCheck() //Checking if player is on ground with raycast and resetting jumpcount if grounded
    {
        Vector3 position = rb.position;
        Vector3 direction = new Vector3(0, -len, 0);

        //Drawing line downwards
        Debug.DrawRay(position, direction, Color.red);
        RaycastHit2D raycast = Physics2D.Raycast(position, direction, groundCheckLength, ground);

        // checking if raycast hits something on ground layer
        if (raycast.collider != null)
        {
            isGrounded = true;
            jumpCount = 2;
        }
        else
        {   // 
            isGrounded = false;
        }
    }

    /// <summary>
    /// AIMovement() Controls AI movement
    /// </summary>
    private void AIMovement() // Controls AI movement
    {

        // Moving left
        // if Ball's X axis value is smaller than AI's X axis value. And distance between them is greater than 1.
        if (aiVector.x > (ballVector.x + 1))
        {   // Add velocity "moveSpeed" towards left on X-axis (negative)
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            // Start movement animation
            roboAnimator.SetBool("anim_move", true);
        }

        // Moving right
        // if Ball's X axis value is greater than AI's X axis value. And distance between them is greater than 1.
        else if (aiVector.x < (ballVector.x - 1))
        {   // Add velocity "moveSpeed" towards right on X-axis (positive)
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            // Start movement animation
            roboAnimator.SetBool("anim_move", true);
        }

    }

    /// <summary>
    /// AiJump() Controls AI jumping
    /// </summary>
    private void AiJump() // Controls when AI jumps towards the ball.
    {
        // AI jumping when ball is at set jumping distance, and jumpCount is > 0.
        if //(Vector2.Distance(transform.position, ball.position) <= jumpDistance && jumpCount > 0)
            (ball.position.y - rb.position.y < jumpDistance && jumpCount > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            roboAudio.PlayOneShot(audioJump);
            jumpCount--;
            //StartCoroutine(Wait(0.5f));
        }
    }


    /// <summary>
    /// HitHammer() Controls when AI hits the ball.
    /// </summary>
    /// <returns></returns>
    private IEnumerator HitHammer() // Hitting with hammer
    {
        if (Vector2.Distance(transform.position, ball.position) < hitDistance)
        {
            //roboAnimator.Play("robot_hammer");
            roboAnimator.SetBool("anim_hit", true);
            roboAudio.PlayOneShot(audioHit);
            // Wait between hits
            yield return new WaitForSecondsRealtime(0.5f);
            roboAnimator.SetBool("anim_hit", false);
            yield return new WaitForSecondsRealtime(0.5f);
        }
        else
        {   // If not within hit range, don't do the hit animation
            roboAnimator.SetBool("anim_hit", false);
        }
    }

    /// <summary>
    /// PlayerFlip() Flips the AI player depending which way they are moving
    /// </summary>
    private void PlayerFlip()
    {
        //flipping if player is facing left and moving right
        if (rb.velocity.x > 0 && !facingRight)
        {   // Do the flip
            Flip();
            // Wait 0.5s to avoid continuous spinning
            Wait(0.5f);
        }
        //flipping if player is facing right and moving left
        if (rb.velocity.x < 0 && facingRight)
        {   // Do the flip
            Flip();
            // Wait 0.5s to avoid continuous spinning
            Wait(0.5f);
        }
    }

    /// <summary>
    /// Flip() Flipping the player sprite on x axis
    /// </summary>
    private void Flip() //Flipping the player sprite on x axis
    {   // facingRight is false
        facingRight = !facingRight;
        // facing gets AI sprite's localScale value
        Vector2 facing = transform.localScale;

        // This flips the sprite on X-axis
        facing.x *= -1;
        // Set facing as the new orientation of the sprite
        transform.localScale = facing;
    }

    /// <summary>
    /// Universal Wait method.
    /// </summary>
    /// <param name="time">float time</param>
    /// <returns>WaitForSecondsRealTime(time)</returns>
    private IEnumerator Wait(float time)
    {
        yield return new WaitForSecondsRealtime(time);
    }

}
