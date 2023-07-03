using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// =============================================================
// AUTHOR       : Schubert Michael
// CREATE DATE  : Mai 2023
// SOURCE       : https://github.com/SunnyValleyStudio/VR-Archery-in-Unity-2022/tree/main/Vid%205
// PURPOSE      : Rotates the arrow in the right direction when shot.
// SPECIAL NOTES: -
// =============================================================
public class ArrowRotation : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rBody;

    private void FixedUpdate()
    {
        transform.forward = Vector3.Slerp(transform.forward, rBody.velocity.normalized, Time.fixedDeltaTime);
    }
}
