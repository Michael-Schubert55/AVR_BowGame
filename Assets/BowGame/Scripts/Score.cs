using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

// =============================================================
// AUTHOR       : Kunisch Paul
// CREATE DATE  : July 2023
// SOURCE       : Custom
// PURPOSE      : Counts the arrows shot and calculates a score.
// SPECIAL NOTES: -
// =============================================================
public class Score : MonoBehaviour
{
    ScoreManager score;
    

    private void Awake()
    {
        score = GameObject.Find("GlobalScripts").GetComponent<ScoreManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            GameObject otherGameObject = contact.otherCollider.gameObject;
            //Debug.Log("Kollision mit: " + otherGameObject.tag);
            if (GetPoints(otherGameObject.tag) != 0) { score.Score +=GetPoints(otherGameObject.tag); }
            
            
        }
    }
    private int GetPoints(string tag)
    {
        switch (tag)
        {
            case "TargetArea_2Points":
                return 2;
            case "TargetArea_4Points":
                return 4;
            case "TargetArea_6Points":
                return 6;
            case "TargetArea_8Points":
                return 8;               
            case "TargetArea_10Points":
                return 10;              
        }
        return 0;
        
    }
    

    /* private void Update()
     {
         Debug.Log("Score: " + score);
     }*/
    
}
