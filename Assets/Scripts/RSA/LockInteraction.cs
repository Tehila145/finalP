using UnityEngine;

public class LockInteraction : MonoBehaviour
{
    public GameObject keypadPanel; // Assign this in the inspector
    public KeyCode interactionKey = KeyCode.E; // The key to press to interact
    private bool isPlayerInRange = false;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(interactionKey))
        {
            keypadPanel.SetActive(true); // Activate the keypad panel when E is pressed
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true; // Player is in range to interact
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false; // Player leaves the range
        }
    }
}