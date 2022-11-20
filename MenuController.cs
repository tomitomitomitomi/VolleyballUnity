using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// Menu controller Controls the transition between scenes.
/// </summary>

public class MenuController : MonoBehaviour {
  
    //Fields
    private static int vsComputer;
    private static int vsPlayer;
    private static int basicMode;
    private static int volleyBall;
    private static int domination;
    public static bool backToMM = false;
    AudioSource buttonClick;

    private void Start()
    {
        buttonClick = GetComponent<AudioSource>();
    }
    /// <summary>
    /// To play against the computer.
    /// and to load choose playmode menu.
    /// </summary>


 
    public void playVsComputer()
    {

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("SecondaryMenu");
        vsComputer = 1;
        Debug.Log("VsComputer choosed");
        
    }

    public void playSound()
    {
        buttonClick.Play();
    }
    /// <summary>
    /// To play against a player.
    /// and to load choose playmode menu.
    /// </summary>

    public void playVsPlayer(){


      
        SceneManager.LoadScene("SecondaryMenu");
        vsPlayer = 2;
        Debug.Log("VsPlayer choosed");
    }
    /// <summary>
    /// Quits the game.
    /// </summary>
    public void quitGame(){

        
        Debug.Log("Quit!");
        Application.Quit();
        vsPlayer = 0;
        vsComputer = 0;

    }
    /// <summary>
    /// To play BasicMode against the computer or a player.
    /// </summary>

    public void playBasic()
    {
        if (vsComputer ==1)
        {
           
            SceneManager.LoadScene("CharacterSelect");
            basicMode = 1;
           // vsComputer = 1;
            Debug.Log("Basic mode choosed!");

        } else if (vsPlayer == 2)
        {
            
            SceneManager.LoadScene("TwoCharacterSelect");
            basicMode = 1;
           // vsPlayer = 2;
            Debug.Log("Basic mode choosed!");

        }
       
    }
    /// <summary>
    /// To play VolleyBall against the computer or a player.
    /// </summary>

    public void playVolleyBall()
    {

        if (vsComputer == 1)
        {
            
            // vsComputer = 1;
            SceneManager.LoadScene("CharacterSelect");
            volleyBall = 2;
            Debug.Log("Volleyball  choosed!");

        }
        else if (vsPlayer == 2)
        {
            
            // vsPlayer = 2;
            SceneManager.LoadScene("TwoCharacterSelect");
            volleyBall = 2;
            Debug.Log("Volleyball choosed!");

        }


    }
    /// <summary>
    /// To play Domination against the computer or a player.
    /// </summary>

    public void playDomination()
    {

        if (vsComputer == 1)
        {
           
            // vsComputer = 1;
            SceneManager.LoadScene("CharacterSelect");
            domination = 3;
            Debug.Log("Domination  choosed!");

        }
        else if (vsPlayer == 2)
        {
            
            // vsPlayer = 2;
            SceneManager.LoadScene("TwoCharacterSelect");
            domination = 3;
            Debug.Log("Domination choosed!");

        }
    }
    /// <summary>
    /// Backs to main menu.
    /// </summary>
    public void backToMainMenu()
    {
        backToMM = true;  
        SceneManager.LoadScene("MainMenu");
        vsComputer = 0;
        vsPlayer = 0;
        Debug.Log("Back to main menu");
    }
    /// <summary>
    /// Starts the game.
    /// </summary>

    public void  startGame(){
        // Load BasicMode against a player.
        if(vsPlayer == 2 && basicMode == 1  ){
            
            SceneManager.LoadScene("BasicGameVsP");
            vsPlayer = 0;
            basicMode = 0;

            Debug.Log("VsPlayer && basicMode Choosed,game started ");

        }
        // Load Volleyball against a player.
        if (vsPlayer == 2 && volleyBall == 2)
        {
            
            SceneManager.LoadScene("VolleyBallVsP");
            vsPlayer = 0;
            volleyBall = 0;
            Debug.Log("VsPlayer && Volley ball Choosed. Game started! ");

        }
        // Load domination against a player.
        if (vsPlayer == 2 && domination == 3)
        {
            
            SceneManager.LoadScene("DominationVsP");
            vsPlayer = 0;
            domination = 0;
            Debug.Log("VsPlayer && Domination mode Choosed. Game started! ");

        }
        // Load BasicMode against the computer.

        if (vsComputer == 1 && basicMode == 1)
        {
            
            SceneManager.LoadScene("BasicGameVsC");
            vsComputer = 0;
            basicMode = 0;
            Debug.Log("VsComputer && Basic mode Choosed. Game started! ");




        }
        //Load VolleyBall against the computer.

        if (vsComputer == 1 && volleyBall == 2)
        {
            
            SceneManager.LoadScene("VolleyBallVsC");
            vsComputer = 0;
            volleyBall = 0;
            Debug.Log("VsComputer && volley ball Choosed. Game started! ");

        }
        //Load Domination against the computer.
        if (vsComputer == 1 && domination == 3)
        {
            
            SceneManager.LoadScene("DominationVsC");
            vsComputer = 0;
            domination = 0;
            Debug.Log("VsComputer && domination mode Choosed. Game started! ");



        }


    }

 

}
