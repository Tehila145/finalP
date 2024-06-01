using UnityEngine;

public class VisibilityControl : MonoBehaviour
{
    public GameObject objectToShow; // Assign this in the inspector with the object or outline to show/hide

    void Start()
    {
        if (objectToShow != null)
            objectToShow.SetActive(false);
        else
            Debug.LogError("objectToShow not assigned in the Inspector");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && objectToShow != null)
        {
            objectToShow.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && objectToShow != null)
        {
            objectToShow.SetActive(false);
        }
    }

}