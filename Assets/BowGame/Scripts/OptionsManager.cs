using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// =============================================================
// AUTHOR       : Schubert Michael
// CREATE DATE  : June 2023
// SOURCE       : Custom
// PURPOSE      : Handles and saves the options set in the main menu.
// SPECIAL NOTES: -
// =============================================================
public class OptionsManager : MonoBehaviour
{
    public TMP_Dropdown dropDown;

    // Set selected value
    void Start()
    {
        string difficulty = PlayerPrefs.GetString("difficulty");

        if (difficulty != null)
        {
            if (difficulty == "medium")
            {
                dropDown.value = 1;
            }
            else if (difficulty == "hard")
            {
                dropDown.value = 2;
            }
            else
            {
                dropDown.value = 0;
            }
        }
    }

    // Handles the difficulty selection
    public void SaveDifficulty()
    {
        if (dropDown.value == 1)
        {
            PlayerPrefs.SetString("difficulty", "medium");
        }
        else if (dropDown.value == 2)
        {
            PlayerPrefs.SetString("difficulty", "hard");
        }
        else
        {
            PlayerPrefs.SetString("difficulty", "easy");
        }
    }
}
