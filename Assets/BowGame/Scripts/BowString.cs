using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

// =============================================================
// AUTHOR       : Schubert Michael, Kunisch Paul
// CREATE DATE  : Mai 2023
// SOURCE       : https://github.com/SunnyValleyStudio/VR-Archery-in-Unity-2022/tree/main/Vid%205
// PURPOSE      : Handles the visualization of the bow string.
// SPECIAL NOTES: -
// =============================================================
public class BowString : MonoBehaviour
{
    [SerializeField]
    private Transform endpoint_1, endpoint_2;

    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void CreateString(Vector3? midPosition)
    {
        // Checks if string is pulles. Then 3 linepoints.
        Vector3[] linePoints = new Vector3[midPosition == null ? 2 : 3];
        linePoints[0] = endpoint_1.localPosition;
        if (midPosition != null)
        {
            linePoints[1] = transform.InverseTransformPoint(midPosition.Value);
        }

        // ^1 Gets last position of array
        linePoints[^1] = endpoint_2.localPosition;

        lineRenderer.positionCount = linePoints.Length;
        lineRenderer.SetPositions(linePoints);
    }

    private void Start()
    {
        CreateString(null);
    }
}
