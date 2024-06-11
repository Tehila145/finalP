using UnityEngine;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    public TextMeshProUGUI interactionTMP;
    public KeyCode interactionKey = KeyCode.E;
    private bool isPlayerInRange = false;

    void Start()
    {
        // Ensures the panel starts inactive
        if (interactionTMP == null || interactionTMP.transform.parent == null)
        {
            Debug.LogError("Start: TextMeshPro or its parent is not assigned in the Inspector!");
        }
        else
        {
            interactionTMP.transform.parent.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Toggles the panel when the interaction key is pressed
        if (isPlayerInRange && Input.GetKeyDown(interactionKey))
        {
            TogglePanel();
        }
    }

    // Toggle the visibility of the panel
    private void TogglePanel()
    {
        if (interactionTMP != null && interactionTMP.transform.parent != null)
        {
            bool isActive = interactionTMP.transform.parent.gameObject.activeSelf;
            interactionTMP.transform.parent.gameObject.SetActive(!isActive);
        }
        else
        {
            Debug.LogError("TogglePanel: TextMeshPro component or parent GameObject is missing or destroyed");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Player is now in range.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            // Ensures the panel is hidden when the player leaves the range
            if (interactionTMP != null && interactionTMP.transform.parent != null)
            {
                interactionTMP.transform.parent.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("OnTriggerExit2D: TextMeshPro component or parent GameObject is missing or destroyed");
            }
        }
    }
}
