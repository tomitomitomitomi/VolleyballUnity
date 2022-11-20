using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityScript;
/// <summary>
/// Pause controller controls pause menu activity.
/// </summary>

    public class PauseController : MonoBehaviour
    {
    //Fields

    public static bool gamePaused = false;
    public GameObject pauseMenuUI;

   
    /// <summary>
    /// Making sure game starts unpaused
    /// </summary>
    private void Start()
    {
        Resume();
    }
   /// <summary>
   /// Update the game by activating or deactivating the pause menu depends on the condition.
   /// </summary>
    void Update()
        {

        if (Input.GetKeyDown(KeyCode.Escape) && (System.Convert.ToInt32(GameController.countP1) < (int)GameController.EndScore && System.Convert.ToInt32(GameController.countP2) < (int)GameController.EndScore))
            {

                if (gamePaused)
                {

                    Resume();

                }
                else
                {

                    Pause();
                }

            }
 


    }
    /// <summary>
    /// Deactivate pause menu.
    /// </summary>

    public void Resume()
    {

            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            gamePaused = false;

    }
    /// <summary>
    /// activate pause menu.
    /// </summary>

    public void Pause()
    {

            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            gamePaused = true;
    }
    /// <summary>
    /// Backs to main menu.
    /// </summary>

    public void backToMainMenu()
        {

            // Insert score into database.
            Database.Instance.GetInformation();
            Debug.Log("Got info for DB");
            Database.Instance.InsertScore();
            Debug.Log("Inserted score in DB");

            MenuController.backToMM = true;
            Debug.Log("To Main Menu");
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");

        }
    /// <summary>
    /// Quits the game.
    /// </summary>

        public void quitGame()
        {

            // Insert score into database.
            Database.Instance.GetInformation();
            Database.Instance.InsertScore();

            Debug.Log("Quitting the game");
            Application.Quit();
        }

    }

