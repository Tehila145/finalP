using UnityEngine;

public class LockInteraction : MonoBehaviour
{
    public GameObject keypadPanel; // Assign this in the inspector
    //private bool isPlayerInRange = false;
    void OnMouseDown()
    {
        // Activate the keypad panel when this object is clicked
        keypadPanel.SetActive(true);
        Debug.Log("Lock clicked, keypad activated."); // Log message to confirm activation
    }
//    void Update()
//    {
//        // Check if the player is in range and the left mouse button (mouse 0) is pressed
//        if (isPlayerInRange && Input.GetMouseButtonDown(0))
//        {
//            keypadPanel.SetActive(true); // Activate the keypad panel when the mouse is clicked
//        }
//    }

//    void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            isPlayerInRange = true; // Player is in range to interact
//            Debug.Log("Player in range"); // Add a log to confirm when the player enters the range
//        }
//    }

//    void OnTriggerExit2D(Collider2D other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            isPlayerInRange = false; // Player leaves the range
//            Debug.Log("Player out of range"); // Add a log to confirm when the player leaves the range
//        }
//    }
}
