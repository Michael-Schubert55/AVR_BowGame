using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SetHighScore : MonoBehaviour
{
    [SerializeField]
    private TMP_Text highscore;

    // Start is called before the first frame update
    void Awake()
    {
        //Debug.Log("S")
        highscore.text = "Level             |    High score   |    Fewest arrows used\n"+
                         "Übungslevel:        "+PlayerPrefs.GetInt("Score Level_1")+"                           " + PlayerPrefs.GetInt("Arrows Level_1")+"\n"+
                         "Level_1:                "+PlayerPrefs.GetInt("Score Level_2")+"                           " + PlayerPrefs.GetInt("Arrows Level_2")+"\n" +
                         "Level_2:               "+PlayerPrefs.GetInt("Score Level_3")+"                           "+ PlayerPrefs.GetInt("Arrows Level_3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
