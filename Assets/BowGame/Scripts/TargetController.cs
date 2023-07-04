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

    //Attribute for score calculation
    public int targets;
    GameObject[] taggedObjects;
    private Dictionary<string, bool> targetObjects;
    //

    private void Awake()
    {
        // Movement of the target
        rb = GetComponent<Rigidbody>();
        originPosition = transform.position;
        nextposition = GetNewMovementPosition();
        // initalize the attributes for score Callculation
        targetObjects = new Dictionary<string, bool>();
        taggedObjects = GameObject.FindGameObjectsWithTag("TargetArea_10Points");
        foreach (GameObject obj in taggedObjects)
        {
            targetObjects[obj.transform.parent.transform.parent.name] = true;
            Debug.Log("Folgende Keys sind eingefüt worden Worden: " + obj.transform.parent.transform.parent.name);
        }
        //
        targets  = taggedObjects.Length;
        Debug.Log("In dieser Szene ist die Anzahl der Ziel: " + targets);

        // Movementspeed of the target
        if(isTutorialTarget == false)
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
        //set hitted targets to falls
        foreach (ContactPoint contact in collision.contacts)
        {
           
            GameObject otherGameObject = contact.otherCollider.gameObject;
            if (otherGameObject.transform.parent.transform.parent.name != null)
            {
                Debug.Log("Das getroffene Ziel ist: " + otherGameObject.transform.parent.transform.parent.name);
                targetObjects[otherGameObject.transform.parent.transform.parent.name] = false;
            }
            
        }
        //

    }

    public void GetHit()
    {
        // What happens when the target gets hit
        health--;
        if (health <= 0)
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
    //Return bool for given Target
    public bool FreshTarget(string key)
    {
        return targetObjects[key];
    }//

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

}

public interface IHittable
{
    void GetHit();
}