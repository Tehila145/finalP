using UnityEngine;

public class boat : MonoBehaviour
{
    // Choose the desired approach:
    // Option 1: Directly set position to camera's position (simpler)
    // public Camera mainCamera;

    // Option 2: Set position to center of camera's viewport with adjustable distance (more flexible)
    public float distanceFromCamera = 5.0f; // adjust as needed

    void Start()
    {
        // Option 1 (uncomment if using)
        // mainCamera = Camera.main;
    }

    void LateUpdate() // Use LateUpdate for consistent positioning after camera movements
    {
        if (Camera.main != null) // Check if main camera exists
        {
            // Option 1 (uncomment if using)
            // transform.position = mainCamera.transform.position;

            // Option 2 (more flexible)
            Vector3 center = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
            transform.position = center + Vector3.forward * distanceFromCamera;
        }
    }
}
