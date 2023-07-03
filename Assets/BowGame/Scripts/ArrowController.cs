using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// =============================================================
// AUTHOR       : Schubert Michael, Kunisch Paul
// CREATE DATE  : Mai 2023
// SOURCE       : https://github.com/SunnyValleyStudio/VR-Archery-in-Unity-2022/tree/main/Vid%205
// PURPOSE      : Handles the arrow creation, instantiation and sounds when pulling the bow string.
// SPECIAL NOTES: -
// =============================================================

public class ArrowController : MonoBehaviour
{
    [SerializeField]
    private GameObject midPointVisual, arrowPrefab, arrowSpawnPoint;

    [SerializeField]
    private float arrowMaxSpeed = 10;

    [SerializeField]
    private AudioSource bowReleaseAudio;
    //ScoreCounter scoreCounter;
    private void Awake()
    {
        //scoreCounter = GameObject.Find("Scripts").GetComponent<ScoreCounter>();
    }

    public void PrepareArrow()
    {
        // Show arrow when pulled
        midPointVisual.SetActive(true);
    }

    public void ReleaseArrow(float strength)
    {
        bowReleaseAudio.Play();
        // Hide arrow when let go
        midPointVisual.SetActive(false);
        
        // Spawn and shot arrow
        GameObject arrow = Instantiate(arrowPrefab);
        arrow.transform.position = arrowSpawnPoint.transform.position;
        arrow.transform.rotation = arrowSpawnPoint.transform.rotation;
        Rigidbody rBody = arrow.GetComponent<Rigidbody>();
        rBody.AddForce(midPointVisual.transform.right * strength * arrowMaxSpeed, ForceMode.Impulse);
        //Debug.Log(scoreCounter.Counter);
        //scoreCounter.Counter += 1;
    }
}
