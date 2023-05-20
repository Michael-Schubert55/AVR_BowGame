using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    public TMP_Dropdown dropDown;

    public void SaveDifficulty()
    {
        if (dropDown.value == 0)
        {
            PlayerPrefs.SetString("difficulty", "easy");
        }
        if (dropDown.value == 1)
        {
            PlayerPrefs.SetString("difficulty", "medium");
        }
        else
        {
            PlayerPrefs.SetString("difficulty", "hard");
        }
    }
}
