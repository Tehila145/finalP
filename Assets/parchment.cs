using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parchment : MonoBehaviour
{
    public float distanceFromCamera = 5.0f;
    void LateUpdate()
    {
        if (Camera.main != null) // Check if main camera exists
        {
            Vector3 center = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
            transform.position = center + Vector3.forward * distanceFromCamera;
        }
    }
}
