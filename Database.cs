using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

/// <summary>
/// Database handles the functions of importing and exporting data to database.
/// </summary>
public class Database : MonoBehaviour {

    private string dbPath; // Path to database file

    public static string statstext; // Final statistics string, used to display statistics in StatisticsController.cs

    // Fields where we store information from other scripts into database
    private int p1score;    // Player 1 score
    private int p2score;    // Player 2 score
    private int gametime;   // Game time
    private string gamemode;    // Game mode that was played
    private string multiplayer; // VS player or computer?

    // Static singleton property
    public static Database Instance { get; private set; }

    void Awake()
    {
        Instance = this;    // Save a reference to the Database component as our singleton instance
    }

    private void Start()
    {
        dbPath = "URI=file:" + Application.dataPath + "/database.db"; // Connection script
        //dbPath = @"Data Source=" + Application.dataPath + "/database.db";   // Another style of connecting, for testing purposes.
        //Debug.Log(dbPath);
        CreateSchema(); // Open connection to DB and create table if it doesn't exist.
        //Debug.Log("CreateSchema run in Start");
        // GetInformation(); // Get game information
        // InsertScore(); <- Tällä komennolla lisätään matskua databaseen
        // GetDB(5); // Print database info

    }

    /// <summary>
    /// Method to get information from the game (player scores, Scene name, multiplayer?, time played.)
    /// Information fetched from GameController script.
    /// </summary>
    public void GetInformation()
    {
        // Let's see if the gamemode is multiplayer or vs computer
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "BasicGameVsP"
           || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "VolleyBallVsP"
           || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "DominationVsP")
        {
            multiplayer = "Player vs. Player";
        }
        else
        {
            multiplayer = "Player vs. Computer";
        }
        //Debug.Log("Haettiin multiplayer arvo: " + multiplayer);

        // Get gamescore from countP1/P2 @ GameController
            p1score = GameController.countP1;
            p2score = GameController.countP2;
        //Debug.Log("Haettiin scoret, p1: " + p1score + " p2: " + p2score);

        // Get gamemode
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "BasicGameVsP"
            || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "BasicGameVsC")
        {
            gamemode = "Basic game";
        }
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "VolleyBallVsP"
            || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "VolleyBallVsC")
        {
            gamemode = "Volleyball";
        }
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "DominationVsP"
            || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "DominationVsC")
        {
            gamemode = "Domination";
        }


        // Get game duration from timerInt @ GameController
        gametime = GameController.timerInt;
    }

    /// <summary>
    /// Opens connection to DB.
    /// Creates table if doesn't exist already.
    /// </summary>
    public void CreateSchema()
    {
        using (var conn = new SqliteConnection(dbPath))
        {
            //Debug.Log("Before opening connection: " + conn);
            conn.Open();
            //Debug.Log("Opened connection");
            using (var cmd = conn.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS 'Game' ( " +
                                  "  'id' INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, " +
                                  "  'gamemode' TEXT, " +
                                  "  'multiplayer' TEXT, " +
                                  "  'p1score' INTEGER, " +
                                  "  'p2score' INTEGER, " +
                                  "  'duration' INTEGER " +
                                  ");";
                var result = cmd.ExecuteNonQuery();
                //Debug.Log("create schema: " + result);
            }
        }
    }

    /// <summary>
    /// InsertScore() Inserts the score that we acquired with GetInformation(), into the database.
    /// </summary>
    public void InsertScore()
    {
        using (var conn = new SqliteConnection(dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                string temp = "INSERT INTO Game (gamemode, multiplayer, p1score, p2score, duration) " +
                                  "VALUES (@Gamemode, @Multiplayer, @P1score, @P2score, @Duration);";
                //Debug.Log(temp);
                cmd.CommandText = "INSERT INTO Game (gamemode, multiplayer, p1score, p2score, duration) " +
                                  "VALUES (@Gamemode, @Multiplayer, @P1score, @P2score, @Duration);";

                cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "Gamemode",
                    Value = gamemode
                });

                cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "Multiplayer",
                    Value = multiplayer
                });

                cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "P1score",
                    Value = p1score
                });

                cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "P2score",
                    Value = p2score
                });

                cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "Duration",
                    Value = gametime
                });


                var result = cmd.ExecuteNonQuery();
                //Debug.Log("insert score: " + result);
            }
        }
    }

    /// <summary>
    /// Exports the (int limit) amount of entries from database into string statstext.
    /// In Descending order.
    /// </summary>
    /// <param name="limit"></param>
    public void GetDB(int limit)
    {
        using (var conn = new SqliteConnection(dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Game ORDER BY id DESC LIMIT @Count;";

                cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "Count",
                    Value = limit
                });
                statstext = " "; // Set database to empty to prevent displaying data multiple times.
                Debug.Log("scores (begin)");
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var gamemode = reader.GetString(1);
                    var multiplayer = reader.GetString(2);
                    var p1score = reader.GetInt32(3);
                    var p2score = reader.GetInt32(4);
                    var gametime = reader.GetInt32(5);
                    var text = string.Format("Game: {0} / {1} \n[ P1: {2} ]  |  [ P2: {3} ] \nGame duration: {4}s", gamemode, multiplayer, p1score, p2score, gametime);
                    Debug.Log(text);
                    statstext += text + "\n \n";
                }
                Debug.Log("scores (end)");
            }
        }
    }
}