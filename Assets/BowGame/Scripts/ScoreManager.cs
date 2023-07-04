using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// =============================================================
// AUTHOR       : Kunisch Paul
// CREATE DATE  : July 2023
// SOURCE       : Custom
// PURPOSE      : Counts the arrows shot and calculates a score.
// SPECIAL NOTES: -
// =============================================================
public class ScoreManager : MonoBehaviour
{
    //[SerializeField]
    //private int maxArrows;
    private int arrows;
    private int score;
    [SerializeField]
    private TMP_Text textScore;
    [SerializeField]
    private TMP_Text textArrows;
    public string currentSceneName;

    private void Awake()
    {
        
        currentSceneName = GetCurrentSceneName();
        //Debug.Log("Aktuelle Szene: " + currentSceneName);
    }

    public int Score
    {
        get { return score; }
        set { score = value; UpdateScore(); }
    }
    public int Arrows
    {
        get { return arrows; }
        set { arrows = value; UpdateArrows(); }
    }

    private void UpdateArrows()
    {
        textArrows.text = (arrows).ToString();
        //Debug.Log("Update was called new Arrow count = " + arrows);


    }
    private void UpdateScore()
    {
        textScore.text = score.ToString();
        //Debug.Log("Update was called Score = " + score);
        if (PlayerPrefs.HasKey("Score " + currentSceneName) && PlayerPrefs.HasKey("Arrows " + currentSceneName))
        {
            if (PlayerPrefs.GetInt("Score " + currentSceneName) < score)
            {
                PlayerPrefs.SetInt("Score " + currentSceneName, score);
            }
            if (PlayerPrefs.GetInt("Arrows " + currentSceneName) > arrows)
            {
                PlayerPrefs.SetInt("Arrows " + currentSceneName, arrows);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Score " + currentSceneName, score);
            PlayerPrefs.SetInt("Arrows " + currentSceneName, arrows);
        }
    }
        private void SetHighScore(int score, int arrows)
        {
            PlayerPrefs.SetInt("Score " + currentSceneName, score);
            PlayerPrefs.SetInt("Arrows " + currentSceneName, arrows);
        }
    private string GetCurrentSceneName()
    {
        int sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

        string sceneName = SceneManager.GetSceneByBuildIndex(sceneBuildIndex).name;

        return sceneName;
    }

}
