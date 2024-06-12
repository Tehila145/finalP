using UnityEngine;
using TMPro;

public class KeypadUIController : MonoBehaviour
{
    public GameObject keypadPanel;  // Panel that contains the keypad
    public TextMeshProUGUI feedbackText;  // Text display for feedback within the keypad UI

    void Start()
    {
        HideKeypad();  // Ensure the keypad is hidden on start
    }

    public void ShowKeypad()
    {
        if (keypadPanel != null)
            keypadPanel.SetActive(true);
        if (feedbackText != null)
            feedbackText.text = "Enter the code:";
    }

    public void HideKeypad()
    {
        if (keypadPanel != null)
            keypadPanel.SetActive(false);
        if (feedbackText != null)
            feedbackText.text = "";  // Clear any feedback when hiding the panel
    }

    public void DisplayMessage(string message)
    {
        if (feedbackText != null)
            feedbackText.text = message;  // Update the feedback text with the message
    }
}