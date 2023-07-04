using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class SetHighScore : MonoBehaviour
{
    [SerializeField]
    private TMP_Text highscore;

    private string currentSceneName;


    // Start is called before the first frame update
    void Awake()
    {

        //if (!PlayerPrefs.HasKey("Score " + currentSceneName)) && !(PlayerPrefs.HasKey("Arrows " + currentSceneName)))
        if (PlayerPrefs.HasKey("Score Level_1") || PlayerPrefs.HasKey("Score Level_2") || (PlayerPrefs.HasKey("Score Level_3")))
        //if (!(PlayerPrefs.HasKey("Score Level_1")) && !(PlayerPrefs.HasKey("Score Level_2")) && (!(PlayerPrefs.HasKey("Score Level_3"))))
            {
            highscore.text = "  Level             |       Punktzahl        |     Pfeile\n\n\n" +
                         "Übungslevel:                  "+PlayerPrefs.GetInt("Score Level_1")+"                      "+PlayerPrefs.GetInt("Arrows Level_1")+"\n" +
                         "Level 1:                         "+PlayerPrefs.GetInt("Score Level_2")+"                      "+PlayerPrefs.GetInt("Arrows Level_2") + "\n" +
                         "Level 2:                          "+PlayerPrefs.GetInt("Score Level_3")+"                      "+PlayerPrefs.GetInt("Arrows Level_3");
        }else
        {
            highscore.text = "  Level             |       Punktzahl        |     Pfeile\n\n\n" +
                         "Übungslevel:        "+"Keine Punkte"+"       "+"Keine Anzahl"+"\n" +
                         "Level 1:                 "+"Keine Punkte"+"       "+"Keine Anzahl"+"\n" +
                         "Level 2:                "+"Keine Punkte"+"       "+"Keine Anzahl";
        }


    }
    
}

