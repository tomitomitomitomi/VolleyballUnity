using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// StatisticsController handles showing and hiding Statistics menu, and fetching information from Database. in Main menu.
/// </summary>
public class StatisticsController : MonoBehaviour {

    public static bool gameStatistics = false;
    public GameObject statisticsMenuUI;
    [SerializeField] private Text StatsText;

    /// <summary>
    /// showDetails is called on Stats button click in main menu.
    /// </summary>
    public void showDetails()
    {

        if (gameStatistics)
        {
            // Statistics not displaying
            statisticsMenuUI.SetActive(false);
            Time.timeScale = 0f;
            gameStatistics = false;
        }
        else
        {   // Statistics displaying
            statisticsMenuUI.SetActive(true);
            Time.timeScale = 0f;
            gameStatistics = true;

            //Getting information from Database when Stats menu goes active
            Database.Instance.GetDB(5); // Get DB info for last 5 played games
            StatsText.text = Database.statstext; // Set the Statistics text to display the stats that we got with GetDB(5)
        }
    }
}
