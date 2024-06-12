using UnityEngine;
using TMPro;

public class Level5GameController : MonoBehaviour
{
    public TextMeshProUGUI feedbackText;
    public GameObject portal;
    public GameObject keypadPanel;  // Make sure to assign this in the inspector

    private string currentInput = "";  // Store the current input from the player
    public string correctCode = "";  // This will hold the 'phi' from another script

    void Start()
    {
        UpdateFeedbackText("Welcome! Find the code.");
        portal.SetActive(false);
        keypadPanel.SetActive(false);  // Ensure the keypad is initially hidden
    }

    public void EnterDigit(string digit)
    {
        if (digit == "X")
        {
            currentInput = "";  // Clear the current input
            UpdateFeedbackText("Input cleared.");
            HideKeypad();  // Close the keypad panel
        }
        else if (digit == "#")
        {
            VerifyCode();  // Check the code when '#' is pressed
        }
        else
        {
            currentInput += digit;  // Append the input digit
            UpdateFeedbackText("Code: " + currentInput);  // Update the display
        }
    }

	private void VerifyCode()
	{
    	if (currentInput.Equals(correctCode))
    	{
        	UpdateFeedbackText("Correct! Portal opened!");
        	portal.SetActive(true);  // Show the portal on correct code
        	HideKeypad();  // Optionally close the keypad on correct entry

        	// Find the BookInteractionClosed component and close the pillars
        	var bookClosed = FindObjectOfType<BookInteractionClosed>();
        	if (bookClosed != null)
            	bookClosed.ClearPillars();
    	}
    	else
    	{
        	UpdateFeedbackText("Incorrect! Try again.");
        	currentInput = "";  // Reset input if incorrect
    	}
	}


    public void SetCorrectCode(string decryptedMessage)
    {
        correctCode = decryptedMessage;  // Set the correct code from another script
        Debug.Log("Correct code set: " + correctCode);
    }

    private void HideKeypad()
    {
        if (keypadPanel != null)
            keypadPanel.SetActive(false);  // Hide the keypad panel
    }

    private void UpdateFeedbackText(string message)
    {
        if (feedbackText != null)
            feedbackText.text = message;  // Update the feedback text with the message
    }
}
