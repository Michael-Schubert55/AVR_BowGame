using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rBody;

    private void FixedUpdate()
    {
        transform.forward = Vector3.Slerp(transform.forward, rBody.velocity.normalized, Time.fixedDeltaTime);
    }
}
