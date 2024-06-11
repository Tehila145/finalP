using UnityEngine;

public class VisibilityControl : MonoBehaviour
{
    public GameObject objectToShow; // Assign this in the inspector with the object or outline to show/hide

    void Start()
    {
        if (objectToShow != null)
        {
            objectToShow.SetActive(false);
            Debug.Log("Object is initially hidden.");
        }
        else
        {
            Debug.LogError("objectToShow not assigned in the Inspector");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter Detected");
        if (other.CompareTag("Player") && objectToShow != null)
        {
            objectToShow.SetActive(true);
            Debug.Log("Object should now be visible.");
        }
        else
        {
            Debug.Log("Other object entered trigger: " + other.gameObject.name);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exit Detected");
        if (other.CompareTag("Player") && objectToShow != null)
        {
            objectToShow.SetActive(false);
            Debug.Log("Object should now be hidden.");
        }
    }
}