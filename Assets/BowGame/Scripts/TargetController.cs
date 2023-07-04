using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

// =============================================================
// AUTHOR       : Schubert Michael
// CREATE DATE  : June 2023
// SOURCE       : Custom
// PURPOSE      : Handles the targets behaviour and manages the difficulty selection.
// SPECIAL NOTES: -
// =============================================================
public class TargetController : MonoBehaviour, IHittable
{
    private Rigidbody rb;
    private bool stopped = false;

    private Vector3 nextposition;
    private Vector3 originPosition;

    [SerializeField]
    private int health = 1;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private float arriveThreshold, movementRadius = 2, speed = 1;

    [SerializeField]
    private bool isTutorialTarget = false;

    private Component[] childrenRenderes;

    public bool isHit = false;
    ScoreManager scoreManager;

    private void Awake()
    {
        // Movement of the target
        rb = GetComponent<Rigidbody>();
        originPosition = transform.position;
        nextposition = GetNewMovementPosition();

        scoreManager = GameObject.Find("GlobalScripts").GetComponent<ScoreManager>();

        // Movementspeed of the target
        if (isTutorialTarget == false)
        {
            string difficulty = PlayerPrefs.GetString("difficulty");
            if(difficulty == "medium")
            {
                speed = 1;
            }
            else if(difficulty == "hard")
            {
                speed = 2;
            }
            else
            {
                speed = 0;
            }
        } else
        {
            speed = 0;
        }
    }

    private Vector3 GetNewMovementPosition()
    {
        // Next position of the target
        return originPosition + (Vector3)Random.insideUnitCircle * movementRadius;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((rb.isKinematic || collision.gameObject.CompareTag("Arrow")) == false)
        {
            audioSource.Play();
        }

        // Adds points
        foreach (ContactPoint contact in collision.contacts)
        {
            GameObject otherGameObject = contact.thisCollider.gameObject;

            if (otherGameObject.tag != "" && GetPoints(otherGameObject.tag) != 0 && isHit == false)
            {
                scoreManager.Score += GetPoints(otherGameObject.tag);
                isHit = true;
            }

            scoreManager.AllTargetsHit();
        }
    }

    public void GetHit()
    {
        // What happens when the target gets hit
        health--;
        if (health <= 0 && isHit == false)
        {
            if (audioSource)
            {
                audioSource.Play();
            }

            childrenRenderes = gameObject.GetComponentsInChildren<Renderer>();
            int count = 0;

            foreach (Renderer renderer in childrenRenderes)
            {
                if (count%2 == 1)
                {
                    renderer.material.color = Color.green;
                }
                count++;
            }

            //rb.isKinematic = false;
            stopped = true;
        }
    }

    private void FixedUpdate()
    {
        // Moves target around
        if (stopped == false)
        {
            if (Vector3.Distance(transform.position, nextposition) < arriveThreshold)
            {
                nextposition = GetNewMovementPosition();
            }

            Vector3 direction = nextposition - transform.position;
            rb.MovePosition(transform.position + direction.normalized * Time.fixedDeltaTime * speed);
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
}

public interface IHittable
{
    void GetHit();
}