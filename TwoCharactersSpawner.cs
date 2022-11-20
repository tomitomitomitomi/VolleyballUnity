
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Two characters spawner controls spawning two characters for Vs.Player scenes.
/// </summary>

public class TwoCharactersSpawner : MonoBehaviour
{
    // Fields
    [SerializeField] private GameObject[] players;
    [SerializeField] private Transform player1SpawnPoint;
    [SerializeField] private Transform player2SpawnPoint;

    /// <summary>
    /// On the start of Vs.Player scenes, instantiates 2 characters which stored into preferences.
    /// </summary>
    void Start()
    {
        // checks if the stored character indexes are 0 & 3
        if (PlayerPrefs.GetInt("SellectedCharacter1") == 0 && PlayerPrefs.GetInt("SellectedCharacter2") == 3)
        {
            // instantiate characters which indexes are 0 & 3
            Instantiate(players[(0)], player1SpawnPoint.position, Quaternion.identity);
            Instantiate(players[(3)], player2SpawnPoint.position, Quaternion.identity);
            //Instantiate(players[(0)], playerSpawnPoint.position, playerSpawnPoint.rotation);
            print("Characters:  0, 3 are instantiated");

        }
        // checks if the stored character indexes are 0 & 4
        else if (PlayerPrefs.GetInt("SellectedCharacter1") == 0 && PlayerPrefs.GetInt("SellectedCharacter2") == 4)
        {
            // instantiate characters which indexes are 0 & 4
            Instantiate(players[(0)], player1SpawnPoint.position, Quaternion.identity);
            Instantiate(players[(4)], player2SpawnPoint.position, Quaternion.identity);

            // Instantiate(players[(1)], playerSpawnPoint.position, playerSpawnPoint.rotation);
            print("Characters:  0, 4 are instantiated");

        }
        // checks if the stored character indexes are 0 & 5
        else if (PlayerPrefs.GetInt("SellectedCharacter1") == 0 && PlayerPrefs.GetInt("SellectedCharacter2") == 5)
        {
            // instantiate characters which indexes are 0 & 5
            Instantiate(players[(0)], player1SpawnPoint.position, Quaternion.identity);
            Instantiate(players[(5)], player2SpawnPoint.position, Quaternion.identity);
            // Instantiate(players[(1)], playerSpawnPoint.position, playerSpawnPoint.rotation);
            print("Characters:  0, 5 are instantiated");

        }
        // checks if the stored character indexes are 1 & 3
        else if (PlayerPrefs.GetInt("SellectedCharacter1") == 1 && PlayerPrefs.GetInt("SellectedCharacter2") == 3)
        {
            // instantiate characters which indexes are 1 & 3
            Instantiate(players[(1)], player1SpawnPoint.position, Quaternion.identity);
            Instantiate(players[(3)], player2SpawnPoint.position, Quaternion.identity);

            // Instantiate(players[(1)], playerSpawnPoint.position, playerSpawnPoint.rotation);
            print("Characters:  1, 3 are instantiated");

        }
        // checks if the stored character indexes are 1 & 4
        else if (PlayerPrefs.GetInt("SellectedCharacter1") == 1 && PlayerPrefs.GetInt("SellectedCharacter2") == 4)
        {
            // instantiate characters which indexes are 1 & 4
            Instantiate(players[(1)], player1SpawnPoint.position, Quaternion.identity);
            Instantiate(players[(4)], player2SpawnPoint.position, Quaternion.identity);
            // Instantiate(players[(1)], playerSpawnPoint.position, playerSpawnPoint.rotation);
            print("Characters: 1, 4 are instantiated");


        }
        // checks if the stored character indexes are 1 & 5
        else if (PlayerPrefs.GetInt("SellectedCharacter1") == 1 && PlayerPrefs.GetInt("SellectedCharacter2") == 5)
        {
            // instantiate characters which indexes are 1 & 5
            Instantiate(players[(1)], player1SpawnPoint.position, Quaternion.identity);
            Instantiate(players[(5)], player2SpawnPoint.position, Quaternion.identity);
            // Instantiate(players[(1)], playerSpawnPoint.position, playerSpawnPoint.rotation);
            print("Characters:  1, 5 are instantiated");

        }
        // checks if the stored character indexes are 2 & 3
        else if (PlayerPrefs.GetInt("SellectedCharacter1") == 2 && PlayerPrefs.GetInt("SellectedCharacter2") == 3)
        {
            // instantiate characters which indexes are 2 & 3
            Instantiate(players[(2)], player1SpawnPoint.position, Quaternion.identity);
            Instantiate(players[(3)], player2SpawnPoint.position, Quaternion.identity);

            // Instantiate(players[(1)], playerSpawnPoint.position, playerSpawnPoint.rotation);
            print("Characters:  2, 3 are instantiated");

        }
        // checks if the stored character indexes are 2 & 4
        else if (PlayerPrefs.GetInt("SellectedCharacter1") == 2 && PlayerPrefs.GetInt("SellectedCharacter2") == 4)
        {
            // instantiate characters which indexes are 2 & 4
            Instantiate(players[(2)], player1SpawnPoint.position, Quaternion.identity);
            Instantiate(players[(4)], player2SpawnPoint.position, Quaternion.identity);
            // Instantiate(players[(1)], playerSpawnPoint.position, playerSpawnPoint.rotation);
            print("Characters: 2, 4 are instantiated");

        }
        // checks if the stored character indexes are 2 & 5
        else if (PlayerPrefs.GetInt("SellectedCharacter1") == 2 && PlayerPrefs.GetInt("SellectedCharacter2") == 5)
        {
            // instantiate characters which indexes are 2 & 5
            Instantiate(players[(2)], player1SpawnPoint.position, Quaternion.identity);
            Instantiate(players[(5)], player2SpawnPoint.position, Quaternion.identity);

            // Instantiate(players[(1)], playerSpawnPoint.position, playerSpawnPoint.rotation);
            print("Characters: 2, 5 are instantiated");

        }

    }

}