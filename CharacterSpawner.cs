using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Character spawner controls spawning character for Vs.Computer scenes .
/// </summary>

public class CharacterSpawner : MonoBehaviour
{
    // Fields
    [SerializeField] private GameObject[] players;
    [SerializeField] private Transform playerSpawnPoint;


    /// <summary>
    /// On the start of Vs.computer scenes, instantiates the choosed character which stored into preferences .
    /// </summary>
    void Start()
    {
        // checks if the stored character index is 0
        if (PlayerPrefs.GetInt("SellectedCharacter") == 0)
        {
            // instantiate the character which index is 0
            Instantiate(players[(0)], playerSpawnPoint.position, Quaternion.identity);
            //Instantiate(players[(0)], playerSpawnPoint.position, playerSpawnPoint.rotation);
            print("The player 0 is instantiated");

        }
        // checks if the stored character index is 1
        if (PlayerPrefs.GetInt("SellectedCharacter") == 1)
        {
            // instantiate the character which index is 1
            Instantiate(players[(1)], playerSpawnPoint.position, Quaternion.identity);
            // Instantiate(players[(1)], playerSpawnPoint.position, playerSpawnPoint.rotation);
            print("The player 1 is instantiated");

        }
        // checks if the stored character index is 2
        if (PlayerPrefs.GetInt("SellectedCharacter") == 2)
        {
             // instantiate the character which index is 2
            Instantiate(players[(2)], playerSpawnPoint.position, Quaternion.identity);
            // Instantiate(players[(1)], playerSpawnPoint.position, playerSpawnPoint.rotation);
            print("The player 2 is instantiated");

        }



   }


}
