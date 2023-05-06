using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        rBody.isKinematic = true;
        sCollider.isTrigger = true;

        GameObject stuckArrowInstance = Instantiate(stuckArrow);
        stuckArrowInstance.transform.position = transform.position;
        stuckArrowInstance.transform.forward = transform.forward;

        if(collision.collider.attachedRigidbody != null)
        {
            stuckArrowInstance.transform.parent = collision.collider.attachedRigidbody.transform;
        }

        //collision.collider.GetComponent<IHittable>()?.GetHit();

        Destroy(gameObject);
    }
}
