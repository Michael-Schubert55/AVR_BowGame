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
        if (PlayerPrefs.HasKey("Score Level_1") && PlayerPrefs.HasKey("Score Level_2") && (PlayerPrefs.HasKey("Score Level_3")))
        //if (!(PlayerPrefs.HasKey("Score Level_1")) && !(PlayerPrefs.HasKey("Score Level_2")) && (!(PlayerPrefs.HasKey("Score Level_3"))))
            {
            highscore.text = "  Level            |         Hoechste Punktzahl        |       Wenigste Pfeile\n\n\n" +
                         "Übungslevel:                      "+PlayerPrefs.GetInt("Score Level_1")+"                                              "+PlayerPrefs.GetInt("Arrows Level_1")+"\n" +
                         "Level_1:                              "+PlayerPrefs.GetInt("Score Level_2")+"                                             "+PlayerPrefs.GetInt("Arrows Level_2") + "\n" +
                         "Level_2:                             "+PlayerPrefs.GetInt("Score Level_3")+"                                             "+PlayerPrefs.GetInt("Arrows Level_3");
        }else
        {
            highscore.text = "  Level                |    Hoechste Punktzahl           |     Wenigste Pfeile\n\n\n" +
                         "Übungslevel:        "+"Keine Punkte vorhanden"+"            "+"Keine Anzahl vorhanden"+"\n" +
                         "Level_1:             "+"Keine Punkte vorhanden"+"            "+"Keine Anzahl vorhanden"+"\n" +
                         "Level_2:            "+"Keine Punkte vorhanden"+"            "+"Keine Anzahl vorhanden";
        }


    }
    
}

