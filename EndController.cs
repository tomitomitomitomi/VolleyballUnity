using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// End controller controls end menu activity.
/// </summary>
public class EndController : MonoBehaviour
{

    // Fields
    public static bool gameEnded = false;
    [SerializeField]private  GameObject endMenuUI;
    [SerializeField]private Text endText;



    /// <summary>
    /// When the condition is true, implements endGame() method.
    /// </summary>
    void Update()
    {

        if ((GameController.countP1 == GameController.EndScore || GameController.countP2 == GameController.EndScore) && gameEnded == false)
        {
            endGame();
        }
    }
    /// <summary>
    /// Ends the game by activating the endMenuUI.
    /// </summary>

    public void endGame()
    {
        endMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameEnded = true;
        
        // If player wins, change goal text to show the winner.
        if (GameController.countP1 == GameController.EndScore)
        {
          endText.text = "Player 1 wins!";
        }
        if (GameController.countP2 == GameController.EndScore)
        {
            endText.text = "Player 2 wins!";
        }

        // Insert score into database.
        Database.Instance.GetInformation();
        Debug.Log("Got info for DB");
        Database.Instance.InsertScore();
        Debug.Log("Inserted score in DB");

        Debug.Log("Game Ended!");





    }
    /// <summary>
    /// To rematch the game when it end.
    /// </summary>

    public void rematch()
    {

        if (gameEnded == true)
        {
            endMenuUI.SetActive(false);
            gameEnded = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Game rematched");
            GameController.countP1 = 0;
            GameController.countP2 = 0;

        }


    }
    /// <summary>
    /// Backs to main menu.
    /// </summary>


    public void backToMainMenu()
    {
        MenuController.backToMM = true;
        Debug.Log("To Main Menu");
        Time.timeScale = 1f;
        gameEnded = false;
        GameController.countP1 = 0;
        GameController.countP2 = 0;
        SceneManager.LoadScene("MainMenu");

    }
    /// <summary>
    /// Quits the game.
    /// </summary>

    public void quitGame()
    {

        Debug.Log("Quitting the game");
        Application.Quit();
    }
}

