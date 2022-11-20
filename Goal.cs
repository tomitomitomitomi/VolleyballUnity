using UnityEngine;
using System.Collections;

/// <summary>
/// This script handles the text fields for player scores and "Goal!",
/// And adds to the player score once a goal has been registered.
/// Attach it to the Goals in Unity.
/// </summary>
public class Goal : GameController {
   
    // For Domination only:
    // Float variables to count time using Time.deltaTime. To be converted to int later.
    // This is used because (int)Time.deltaTime stopped working for whatever reason.
    private float p1Score;
    private float p2Score;

    // Let's find the Ball game object and make an variable for it
    private GameObject ball;
    // Save starting position of the ball
    private Vector2 defpos;
    // Out of screen position for the ball
    private Vector2 resetpos;
    // Velocity after ball reset
    Rigidbody2D ballrb;
    // Trail
    [SerializeField] private TrailRenderer trail;

    //Audio for goals
    AudioSource goalAudio;
    [SerializeField] AudioClip goalSound;

    // Particle animation
    public ParticleSystem particles;


    private void Start()
    {
        ball = GameObject.Find("Ball");
        ballrb = ball.GetComponent<Rigidbody2D>();
        defpos = new Vector2(ball.transform.position.x, ball.transform.position.y);
        resetpos = new Vector2(0, 100);
        goalAudio = GetComponent<AudioSource>();
        
    }

    /// <summary>
    /// Trigger to register goals when ball hits the goal triggers.
    /// For gamemodes: Basic / Volleyball
    /// </summary>
    /// <param name="other">Ball</param>
    private void OnTriggerEnter2D(Collider2D other)
    {   // If scene is Basic or Volleyball, use following triggers for goals.
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "BasicGameVsP"
            || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "BasicGameVsC"
            || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "VolleyBallVsP"
            || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "VolleyBallVsC")
        {
            // If ball hits goal 1, add score for player 2
            if (other.CompareTag("Ball") && this.CompareTag("Goal P1"))
            {
                countP2++; // Add score to Player 2
                //not working like this! trail.SetActive(false); //Deactivates trail object
                trail.Clear();
                particles.Play(); // Play particle animation
                goalAudio.PlayOneShot(goalSound); //Plays goal sound
                SetScoreText(); // Set score to show in textfield
                StartCoroutine(ShowGoalText()); // Show "Goal!" text Coroutine
                StartCoroutine(BallReset()); // Reset ball position                
            }
            // If ball hits goal 2, add score for player 1
            if (other.CompareTag("Ball") && this.CompareTag("Goal P2"))
            {
                countP1++; // Add score to Player 1
                
                particles.Play(); // Play particle animation
                //not working like this! trail.SetActive(false); //Deactivates trail object 
                trail.Clear();
                goalAudio.PlayOneShot(goalSound); // Plays goal sound
                SetScoreText(); // Set score to show in textfield
                StartCoroutine(ShowGoalText()); // Show "Goal!" text Coroutine
                StartCoroutine(BallReset()); // Reset ball position
            }
        }
    }

    /// <summary>
    /// Trigger to register goals when ball stays in the goal triggers.
    /// For gamemode: Domination
    /// </summary>
    /// <param name="other">Ball</param>
    private void OnTriggerStay2D(Collider2D other)
    {   // If scene is Domination, use following triggers for goals.
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "DominationVsP"
            || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "DominationVsC")
        {

            // If ball hits goal 1, add score for player 2
            if (other.CompareTag("Ball") && this.CompareTag("Goal P1"))
            {
                p2Score += Time.deltaTime;  // adds 1 score per second in to local float variable
                countP2 = (int)p2Score;     // change float into int
                SetScoreText();             // set the score to display in textfield
            }
            // If ball hits goal 2, add score for player 1
            if (other.CompareTag("Ball") && this.CompareTag("Goal P2"))
            {
                p1Score += Time.deltaTime;  // adds 1 score per second in to local float variable
                countP1 = (int)p1Score;     // change float into int
                SetScoreText();             // set the score to display in textfield
            }
        }
    }

    /// <summary>
    /// Method to display the Goal text for 2 seconds once goal has been made
    /// </summary>
    /// <returns></returns>
    private IEnumerator ShowGoalText()
    {   
        // Change text to GOAL!
        goalText.text = "GOAL!";
        // Display it for 1 second
        yield return new WaitForSecondsRealtime(1);
        // Change text back to empty making it invisible
        goalText.text = " ";
    } // https://docs.unity3d.com/ScriptReference/WaitForSeconds.html

    /// <summary>
    /// Method to reset the ball to starting position after goal
    /// </summary>
    /// <returns></returns>
    private IEnumerator BallReset()
    {
        ball.transform.position = resetpos;
        trail.Clear();
        yield return new WaitForSecondsRealtime(2);
        
        ball.transform.position = defpos;
        
        ballrb.velocity = new Vector2(0,0);
        //not working like this! trail.SetActive(true); //Activates trail object again
        
        ballrb.rotation = 0f;
    }
}
