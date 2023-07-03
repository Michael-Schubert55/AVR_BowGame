using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

// =============================================================
// AUTHOR       : Schubert Michael, Kunisch Paul
// CREATE DATE  : Mai 2023
// SOURCE       : https://github.com/SunnyValleyStudio/VR-Archery-in-Unity-2022
// PURPOSE      : Handles the bow and string interaction. Defines the behaviour of the pulling and releasing mechanics of the bow string.
// SPECIAL NOTES: -
// =============================================================
public class BowStringController : MonoBehaviour
{
    [SerializeField]
    private BowString bowStringRenderer;

    private XRGrabInteractable interactable;

    [SerializeField]
    private Transform midPointGrabObject, midPointVisualObject, midPointParent;
    [SerializeField]
    private float bowStringStretchLimit = 0.4f;

    private Transform interactor;

    // Variables for arrow
    private float strength, previousStrength;
    public UnityEvent OnBowPulled;
    public UnityEvent<float> OnBowReleased;

    [SerializeField]
    private float stringSoundThreshold = 0.001f;

    [SerializeField]
    private AudioSource bowPullAudio;

    private void Awake()
    {
        interactable = midPointGrabObject.GetComponent<XRGrabInteractable>();
    }

    private void Start()
    {
        interactable.selectEntered.AddListener(PrepareBowString);
        interactable.selectExited.AddListener(ResetBowString);
    }

    private void ResetBowString(SelectExitEventArgs arg0)
    {
        // Shot arrow
        OnBowReleased?.Invoke(strength);
        strength = 0.0f;

        // bow sound
        previousStrength = 0.0f;
        bowPullAudio.pitch = 1;
        bowPullAudio.Stop();

        // Reset string
        interactor = null;
        midPointGrabObject.localPosition = Vector3.zero;
        midPointVisualObject.localPosition = Vector3.zero;
        bowStringRenderer.CreateString(null);
    }

    private void PrepareBowString(SelectEnterEventArgs arg0)
    {
        interactor = arg0.interactorObject.transform;

        // for showing arrow
        OnBowPulled?.Invoke();
    }

    private void Update()
    {
        if (interactor != null)
        {
            // converts bow string mid point position to the local space of the MidPoint
            Vector3 midPointLocalSpace = midPointParent.InverseTransformPoint(midPointGrabObject.position); // localPosition

            // get the offset
            float midPointLocalXAbs = Mathf.Abs(midPointLocalSpace.x);

            previousStrength = strength;

            HandleStringPushedBackToStart(midPointLocalSpace);

            HandleStringPulledBackTolimit(midPointLocalXAbs, midPointLocalSpace);

            HandlePullingString(midPointLocalXAbs, midPointLocalSpace);

            bowStringRenderer.CreateString(midPointVisualObject.transform.position);
        }
    }

    private void HandlePullingString(float midPointLocalXAbs, Vector3 midPointLocalSpace)
    {
        // What happens when we are between point 0 and the string pull limit
        if (midPointLocalSpace.x < 0 && midPointLocalXAbs < bowStringStretchLimit)
        {
            // Bow sound
            if (bowPullAudio.isPlaying == false && strength <= 0.01f)
            {
                bowPullAudio.Play();
            }

            // Calculate arrow strength
            strength = Remap(midPointLocalXAbs, 0, bowStringStretchLimit, 0, 1);

            midPointVisualObject.localPosition = new Vector3(midPointLocalSpace.x, 0, 0);

            PlayStringPullingSound();
        }
    }

    private void PlayStringPullingSound()
    {
        // Check if we have moved the string enought to play the sound unpause it
        if (Mathf.Abs(strength - previousStrength) > stringSoundThreshold)
        {
            if (strength < previousStrength)
            {
                //Play string sound in reverse if pushing the string towards the bow
                bowPullAudio.pitch = -1;
            }
            else
            {
                //Play the sound normally
                bowPullAudio.pitch = 1;
            }
            bowPullAudio.UnPause();
        }
        else
        {
            // If stop moving Pause the sounds
            bowPullAudio.Pause();
        };
    }

    // Map strength to values from 0 to 1
    private float Remap(float value, int fromMin, float fromMax, int toMin, int toMax)
    {
        return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
    }

    private void HandleStringPulledBackTolimit(float midPointLocalXAbs, Vector3 midPointLocalSpace)
    {
        // Specify max pulling limit for the string. we don't allow the string to go any farther than "bowStringStretchLimit"
        if (midPointLocalSpace.z < 0 && midPointLocalXAbs >= bowStringStretchLimit)
        {
            bowPullAudio.Pause();

            strength = 1;

            // Vector3 direction = midpointparent.transformdirection(new vector3(0, 0, midpointlocalspace.z));
            midPointVisualObject.localPosition = new Vector3(-bowStringStretchLimit, 0, 0);
        }
    }

    private void HandleStringPushedBackToStart(Vector3 midPointLocalSpace)
    {
        // What happens when the string gets pushed forward
        if (midPointLocalSpace.x >= 0)
        {
            bowPullAudio.pitch = 1;
            bowPullAudio.Stop();

            strength = 0;

            midPointVisualObject.localPosition = Vector3.zero;
        }
    }
}
