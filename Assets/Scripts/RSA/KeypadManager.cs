using UnityEngine;
using TMPro;

public class KeypadManager : MonoBehaviour
{
    public TextMeshProUGUI codeDisplay;  // Link this to a TextMeshProUGUI element on your UI
    public GameObject successPanel;  // Panel to show on successful unlock
    public GameObject keypadPanel;  // Panel that contains the keypad

    private string expectedCode;  // The code players need to match

    void Start()
    {
        if (keypadPanel == null)
            Debug.LogError("Keypad panel is not assigned in the inspector.");
    }

    public void SetCorrectCode(string code)
    {
        expectedCode = code;
        Debug.Log("Correct code set: " + expectedCode);
    }

    public void AddDigit(string digit)
    {
        if (digit == "X")
        {
            CloseKeypad();  // Handle closing the keypad when "X" is pressed
        }
        else if (digit == "#")
        {
            VerifyCode();  // Attempt to verify the code when "#" is entered
        }
        else if (codeDisplay.text.Length < expectedCode.Length)
        {
            codeDisplay.text += digit;
            if (codeDisplay.text.Length == expectedCode.Length)
            {
                VerifyCode();
            }
        }
    }

    void VerifyCode()
    {
        if (codeDisplay.text == expectedCode)
        {
            Debug.Log("Correct Code! Access Granted");
            successPanel.SetActive(true);  // Show success message or unlock something
            CloseKeypad();  // Also close the keypad after a successful entry
        }
        else
        {
            Debug.Log("Incorrect Code! Try Again");
            codeDisplay.text = "";  // Reset the code
        }
    }

    private void CloseKeypad()
    {
        codeDisplay.text = "";
        if (keypadPanel != null)
            keypadPanel.SetActive(false);
        Debug.Log("Keypad closed.");
    }
}
