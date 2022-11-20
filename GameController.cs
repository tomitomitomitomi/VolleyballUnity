using UnityEngine;
using UnityEngine.UI;

    /// <summary>
    /// GameController controls the game elements like timer, player score and textfields
    /// </summary>
    public class GameController : MonoBehaviour
    {

        // Text field for displaying score and goals (used by Goal.cs)
        public Text scoreText;
        public Text goalText;
        public Text timerText;
  

        // Timer fields to keep track of seconds
        private float timerFloat = 0f;
        public static int timerInt;

        // Fields for counting players score (used by Goal.cs)
        public static int countP1;
        public static int countP2;

        // Ending score to finish game
        public static int EndScore;


    // Use this for initialization
    void Start()
    {
        // Set up the score and textfields
        countP1 = 0;
        countP2 = 0;
        goalText.text = " ";
        timerText.text = "0";
        SetScoreText();

        // Set EndScore depending on the scene
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "BasicGameVsP"
            || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "BasicGameVsC")
        {
            EndScore = 10;
        }
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "VolleyBallVsP"
            || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "VolleyBallVsC")
        {
            EndScore = 10;
        }

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "DominationVsP"
            || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "DominationVsC")
        {
            EndScore = 10;
        }
    }
    /// <summary>
    /// SetCountText() Sets the players score visible into scoreboard text
    /// </summary>
    public void SetScoreText()
        {
            scoreText.text = countP1.ToString() + "  |  " + countP2.ToString();

        }


    /// Update is called once per frame
    void Update()
        {
            // Timer adds +1 every second and updates it to the textfield
            timerFloat += Time.deltaTime;   // Get time from Time.deltaTime and set it to timerFloat
            timerInt = (int)timerFloat;     // Get accumulated time from timerFloat and change it to int and set it to timerInt
            timerText.text = timerInt.ToString();   // Set timerInt value to timerText to display it
        }
    }
