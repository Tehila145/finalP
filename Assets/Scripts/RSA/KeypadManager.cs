using UnityEngine;
using TMPro;

public class KeypadManager : MonoBehaviour
{
    public TextMeshProUGUI codeDisplay;  // Link this to a TextMeshProUGUI element on your UI
    public GameObject successPanel;  // Panel to show on successful unlock

    private string expectedCode;  // The code players need to match

    public void SetCode(int encryptedCode)
    {
        expectedCode = encryptedCode.ToString();
        Debug.Log("Code Set: " + expectedCode);
    }

    public void AddDigit(string digit)
    {
        if (codeDisplay.text.Length < expectedCode.Length)
        {
            codeDisplay.text += digit;

            // Check if the entered code is complete
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
            codeDisplay.text = "";  // Reset for next use
        }
        else
        {
            Debug.Log("Incorrect Code! Try Again");
            codeDisplay.text = "";  // Reset the code
        }
    }
}