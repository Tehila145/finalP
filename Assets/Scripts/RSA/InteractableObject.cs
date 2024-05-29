using UnityEngine;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    public TextMeshProUGUI interactionTMP;
    public string displayText = "You have discovered the magical book of secrets!";
    public KeyCode interactionKey = KeyCode.E;  // Default is set to 'E', but can be changed in the Inspector
    private bool isPlayerInRange = false;

    void Start()
    {
        // Check if the TextMeshPro component is assigned and initially hide the parent (chat bubble)
        if (interactionTMP != null && interactionTMP.transform.parent.gameObject != null)
        {
            interactionTMP.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("TextMeshPro is not assigned or parent is missing in the Inspector!");
        }
    }

    void Update()
    {
        // Display the chat bubble when the customizable 'interactionKey' is pressed and the player is in range
        if (isPlayerInRange && Input.GetKeyDown(interactionKey))
        {
            interactionTMP.text = displayText;
            interactionTMP.transform.parent.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            // Hide the chat bubble when the player leaves
            if (interactionTMP != null && interactionTMP.transform.parent.gameObject != null)
            {
                interactionTMP.transform.parent.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("TextMeshPro component or parent GameObject is missing or destroyed");
            }
        }
    }
}
