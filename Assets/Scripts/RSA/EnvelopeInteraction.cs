using UnityEngine;
using TMPro;

public class EnvelopeInteraction : MonoBehaviour
{
    public TextMeshProUGUI encryptedMessageDisplay;  // Assign this in the Inspector
    public GameObject encryptedMessageBackground; // Background for the encrypted message
    public TextMeshProUGUI clueDisplay;  // Assign a text component for displaying clues
    public GameObject clueBackground; // Background for the clue
    public GameObject envelope; // Assign the envelope object in the Inspector

    private bool displayActive = false; // Track display state

    private void Start()
    {
        // Ensure the message, clue, and their backgrounds are hidden initially
        SetActiveState(false);
    }

    private void OnMouseDown()  // This method is called when the player clicks on the envelope
    {
        displayActive = !displayActive; // Toggle the active state
        SetActiveState(displayActive);

        if (displayActive)
        {
            UpdateDisplayContent();
        }
    }

    private void SetActiveState(bool state)
    {
        // Manage the active state of UI elements based on `state`
        encryptedMessageDisplay.gameObject.SetActive(state);
        if (encryptedMessageBackground != null)
            encryptedMessageBackground.SetActive(state);

        clueDisplay.gameObject.SetActive(state);
        if (clueBackground != null)
            clueBackground.SetActive(state);
    }

    private void UpdateDisplayContent()
    {
        // Access the BookInteraction component to get the encrypted message
        BookInteraction bookInteraction = FindObjectOfType<BookInteraction>();
        if (bookInteraction != null)
        {
            encryptedMessageDisplay.text = $"Encrypted Message: {bookInteraction.GetEncryptedMessage()}";
            clueDisplay.text = "C = M ^e (mod n)"; // Custom clue text
        }
        else
        {
            Debug.LogError("BookInteraction script not found in the scene.");
        }
    }
}
