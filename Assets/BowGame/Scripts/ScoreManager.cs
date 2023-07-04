using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// =============================================================
// AUTHOR       : Kunisch Paul, Schubert Michael
// CREATE DATE  : July 2023
// SOURCE       : Custom
// PURPOSE      : Counts the arrows shot and calculates a score.
// SPECIAL NOTES: -
// =============================================================
public class ScoreManager : MonoBehaviour
{
    //[SerializeField]
    //private int maxArrows;
    public int arrows;
    public int score;
    [SerializeField]
    private TMP_Text textScore;
    [SerializeField]
    private TMP_Text textArrows;
    private string currentSceneName;
    private GameObject[] allTargets;

    [SerializeField]
    private IngameMenuManager ingameMenuManager;

    private void Awake()
    {
        
        currentSceneName = GetCurrentSceneName();
        allTargets = GameObject.FindGameObjectsWithTag("Target");

    }

    //public int Score
    //{
    //    get { return score; }
    //    set { score = value; UpdateScore(); }
    //}
    //public int Arrows
    //{
    //    get { return arrows; }
    //    set { arrows = value; UpdateArrows(); }
    //}

    //private void UpdateArrows()
    //{
    //    textArrows.text = (arrows).ToString();
    //}
    //private void UpdateScore()
    //{
    //    textScore.text = score.ToString();
    //}

    private string GetCurrentSceneName()
    {
        int sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

        string sceneName = SceneManager.GetSceneByBuildIndex(sceneBuildIndex).name;

        return sceneName;
    }

    public void AllTargetsHit()
    {
        bool openMenu = true;

        foreach(GameObject target in allTargets)
        {
            if(target.GetComponent<TargetController>().isHit == false)
            {
                openMenu = false;
                return;
            }
        }

        if(openMenu == true && ingameMenuManager != null)
        {
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

            ingameMenuManager.ActivateExternal();
        }
    }

}
