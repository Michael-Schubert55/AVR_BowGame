using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    private int maxArrows;
    private int currentArrows;
    private int Scores;
    [SerializeField]
    private TMP_Text textPoints;
    [SerializeField]
    private TMP_Text textArrows;
    public int Counter
    {
        get { return currentArrows; }
        set { currentArrows = value; UpdateText();}
    }
    void Awake ()
    {
        textArrows.text = maxArrows.ToString();
        if (PlayerPrefs.HasKey("Score"))
        {
            textPoints.text = PlayerPrefs.GetInt("Score").ToString();
        }
        else
        {
            textPoints.text = "0";
        }
        Debug.Log("AwakeTest");
        
    }
   
    private void UpdateText()
    {
        textArrows.text = (maxArrows - currentArrows).ToString();
        Debug.Log("Update was called new Arrow count = " + (maxArrows - currentArrows));
    }

    /*Update is called once per frame
    void Update()
    {
        
    }
     public int CalcArrows(int arrowCounter)
    {
        textArrows.text = (maxArrows - arrowCounter).ToString();
        return maxArrows-arrowCounter;
    }*/
}
