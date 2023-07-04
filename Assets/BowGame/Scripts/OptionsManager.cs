using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private Slider volumeSlider = null;
    [SerializeField]
    private TMP_Text volumeText = null;

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

        LoadVolume();
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

    // Handles the volume settings
    public void SaveVolume()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeValue);
        LoadVolume();
    }

    public void VolumeSlider(float volume)
    {
        volumeText.text = volume.ToString("0.0");
    }

    public void LoadVolume()
    {
        float volumeValue = PlayerPrefs.GetFloat("Volume");

        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
