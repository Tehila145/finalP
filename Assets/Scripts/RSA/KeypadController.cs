using UnityEngine;
using TMPro;
public class KeypadController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI display;
    [SerializeField] private GameObject panel;

    private string correctCode = ""; // This will hold the correct code.
    private string currentInput = "";

    public void SetCorrectCode(int code)
    {
        correctCode = code.ToString();
        Debug.Log("Correct code set in KeypadManager: " + correctCode);
    }

    public void AddDigit(string digit)
    {
        if (digit == "X")
        {
            ClosePanel();
        }
        else if (digit == "#")
        {
            VerifyCode();
        }
        else
        {
            if (currentInput.Length < correctCode.Length)
            {
                currentInput += digit;
                display.text = currentInput;
            }
        }
    }

    private void VerifyCode()
    {
        if (currentInput == correctCode)
        {
            Debug.Log("Unlocked!");
            ClosePanel();  // Close the panel on successful unlock
        }
        else
        {
            Debug.Log("Incorrect Code");
            currentInput = "";  // Reset input
            display.text = "";  // Reset display
        }
    }

    private void ClosePanel()
    {
        panel.SetActive(false);
    }
}
