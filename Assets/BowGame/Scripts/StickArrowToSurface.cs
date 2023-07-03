using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// =============================================================
// AUTHOR       : Schubert Michael
// CREATE DATE  : May 2023
// SOURCE       : https://github.com/SunnyValleyStudio/VR-Archery-in-Unity-2022/tree/main/Vid%205
// PURPOSE      : Handles what happens when the arrow hits a target.
// SPECIAL NOTES: -
// =============================================================
public class StickArrowToSurface : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rBody;

    [SerializeField]
    private SphereCollider sCollider;

    [SerializeField]
    GameObject stuckArrow;

    // Stick arrow and destory shot arrow
    private void OnCollisionEnter(Collision collision)
    {
        sCollider.isTrigger = true;
        rBody.isKinematic = true;

        GameObject stuckArrowInstance = Instantiate(stuckArrow);
        stuckArrowInstance.transform.position = transform.position;
        stuckArrowInstance.transform.forward = transform.forward;
       

        if (collision.collider.attachedRigidbody != null)
        { 
            stuckArrowInstance.transform.parent = collision.collider.attachedRigidbody.transform;  
        }

        //collision.collider.GetComponent<IHittable>()?.GetHit();
        if(collision.collider.transform.parent != null)
        {
            collision.collider.transform.parent.GetComponent<IHittable>()?.GetHit();
        }

        Destroy(gameObject);
    }
}
