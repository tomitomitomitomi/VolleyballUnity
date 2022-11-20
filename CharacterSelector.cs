using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Character selector controls character selection for Vs.Player and Vs.Comuter scenes.
/// </summary>

public class CharacterSelector : MonoBehaviour
{
   // Fields
    private bool chooseFirst = true; 


    /// <summary>
    /// Chooses one character for Vs.Computer scenes, or two characters for Vs.Player scenes.
    /// </summary>
    /// <param name="characterIndex">Character index.</param>

    public void ChooseCharacter(int characterIndex)
    {
        // Check if the active scene is CharacterSelect.
        if (SceneManager.GetActiveScene().name == "CharacterSelect")
        {
            // store choosed character index into preferences.
            PlayerPrefs.SetInt("SellectedCharacter", characterIndex);
            print("Character index that is sellected is " + characterIndex);

        }
        // Check if the active scene is TwoCharacterSelect.
        else if (SceneManager.GetActiveScene().name == "TwoCharacterSelect")
        {

            if (chooseFirst == true)
            {
                chooseFirst = false;
                // Store first choosed character index into preferences.
                PlayerPrefs.SetInt("SellectedCharacter1", characterIndex);
                print("Character 1 index that is sellected is " + characterIndex);
                if (PlayerPrefs.GetInt("SellectedCharacter1") == 3)
                {
                    PlayerPrefs.SetInt("SellectedCharacter1", characterIndex = 0);
                    print("Character 1 index VAIHDETTU TO " + characterIndex);

                }
                else if (PlayerPrefs.GetInt("SellectedCharacter1") == 4)
                {
                    PlayerPrefs.SetInt("SellectedCharacter1", characterIndex = 1);
                    print("Character 1 index VAIHDETTU TO " + characterIndex);

                }
                else if (PlayerPrefs.GetInt("SellectedCharacter1") == 5)
                {
                    PlayerPrefs.SetInt("SellectedCharacter1", characterIndex = 2);
                    print("Character 1 index VAIHDETTU TO " + characterIndex);

                }



            }
            else
            {

                chooseFirst = true;
                // Store second choosed character index into preferences.
                PlayerPrefs.SetInt("SellectedCharacter2", characterIndex);
                print("Character 2 index that is sellected is " + characterIndex);

                if (PlayerPrefs.GetInt("SellectedCharacter2") == 0)
                {
                    PlayerPrefs.SetInt("SellectedCharacter2", characterIndex = 3);
                    print("Character 2 index VAIHDETTU TO " + characterIndex);

                }
                else if (PlayerPrefs.GetInt("SellectedCharacter2") == 1)
                {
                    PlayerPrefs.SetInt("SellectedCharacter2", characterIndex = 4);
                    print("Character 2 index VAIHDETTU TO " + characterIndex);

                }
                else if (PlayerPrefs.GetInt("SellectedCharacter2") == 2)
                {
                    PlayerPrefs.SetInt("SellectedCharacter2", characterIndex = 5);
                    print("Character 2index VAIHDETTU TO " + characterIndex);

                }


            }

            print("player 1 index : " + PlayerPrefs.GetInt("SellectedCharacter1"));
            print("player 2 index : " + PlayerPrefs.GetInt("SellectedCharacter2"));


        }

    }


}


