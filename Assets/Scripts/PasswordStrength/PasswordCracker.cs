// using System.Collections;
// using UnityEngine;
// using TMPro;
// using UnityEngine.UI;
//
// public class PasswordCracker : MonoBehaviour
// {
//     public TMP_InputField inputField; // Input field for the password
//     public TMP_Text resultText; // Text element to display the result
//     public TMP_Text timerText; // Text element to display the timer
//     public Button checkButton;
//     private DatabaseManager dbManager; // Reference to the DatabaseManager
//     private int maxPasswordLength = 16; // Maximum length for the brute force attack
//     private int maxTime = 50; // Maximum time for the brute force attack
//     private string currentGuess = ""; // Current guess during the brute force attack
//
//     void Start()
//     {
//         dbManager = FindObjectOfType<DatabaseManager>(); // Find the DatabaseManager component
//         if (dbManager == null)
//         {
//             Debug.LogError("DatabaseManager component not found on this GameObject.");
//         }
//         checkButton.onClick.AddListener(CheckPasswordStrength); // Add a listener to the check button
//     }
//
//     void CheckPasswordStrength()
//     {
//         string password = inputField.text.Trim(); // Get and trim the password from the input field
//         if (string.IsNullOrEmpty(password)) // Check if the password is empty or null
//         {
//             resultText.text = "Please enter a password."; // Display an error message if the password is empty
//             return;
//         }
//
//         StartCoroutine(CheckPassword(password)); // Start the coroutine to check the password strength
//     }
//
//     IEnumerator CheckPassword(string enteredPassword)
//     {
//         if (dbManager.commonPasswords.Contains(enteredPassword)) // Check if the entered password is a common password
//         {
//             resultText.text = "Weak password: Commonly used."; // Display a message indicating that the password is weak
//         }
//         else
//         {
//             yield return StartCoroutine(BruteForceAttack(enteredPassword)); // Start the brute force attack if the password is not a common password
//         }
//     }
//
//     IEnumerator BruteForceAttack(string targetPassword)
//     {
//         float startTime = Time.time; // Start time of the brute force attack
//         bool passwordFound = false;
//
//         for (int length = 1; length <= maxPasswordLength && !passwordFound; length++)
//         {
//             string currentGuess = new string('a', length); // Start with the lowest possible string for current length
//
//             while (!passwordFound && Time.time - startTime < maxTime)
//             {
//                 if (currentGuess == targetPassword) // Check if the current guess is the target password
//                 {
//                     resultText.text = "Password cracked: " + currentGuess;
//                     passwordFound = true;
//                     break; // Break out of the loop if password is found
//                 }
//
//                 char[] charArray = currentGuess.ToCharArray();
//                 int index = charArray.Length - 1;
//                 bool increment = true;
//
//                 while (index >= 0 && increment)
//                 {
//                     if (charArray[index] < 'z') // If current character is less than 'z', increment it
//                     {
//                         charArray[index]++;
//                         increment = false; // No carry needed, stop incrementing
//                     }
//                     else
//                     {
//                         charArray[index] = 'a'; // Reset current character and carry over to the next character
//                         index--;
//                     }
//                 }
//
//                 if (increment) // If still true, all characters were 'z' and need to increase the length
//                     break; // Will automatically increase the length in the next iteration of the outer loop
//
//                 currentGuess = new string(charArray); // Update currentGuess with the new combination
//                 yield return null; // Yield to keep the UI responsive
//             }
//         }
//
//         if (!passwordFound)
//             resultText.text = "Password not cracked within time limit.";
//     }
// }


//works
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PasswordCracker : MonoBehaviour
{
    public TMP_InputField inputField; // Input field for the password
    public TMP_Text resultText; // Text element to display the result
    public TMP_Text timerText; // Text element to display the timer
    public Button checkButton;
    private int maxPasswordLength = 16; // Maximum length for the brute force attack
    private int maxTime = 50; // Maximum time for the brute force attack
    private string currentGuess = ""; // Current guess during the brute force attack
    private string characterSet = "0123456789";//"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"; // Character set to use

    void Start()
    {
        checkButton.onClick.AddListener(CheckPasswordStrength); // Add a listener to the check button
    }

    void CheckPasswordStrength()
    {
        string password = inputField.text.Trim(); // Get and trim the password from the input field
        if (string.IsNullOrEmpty(password)) // Check if the password is empty or null
        {
            resultText.text = "Please enter a password."; // Display an error message if the password is empty
            return;
        }

        StartCoroutine(BruteForceAttack(password)); // Start the brute force attack coroutine
    }

    IEnumerator BruteForceAttack(string targetPassword)
    {
        float startTime = Time.time; // Start time of the brute force attack
        bool passwordFound = false;
        currentGuess = new string(characterSet[0], 1); // Start with the first character in the set

        while (!passwordFound && Time.time - startTime < maxTime)
        {
            if (currentGuess == targetPassword)
            {
                resultText.text = "Password cracked: " + currentGuess;
                passwordFound = true;
                break;
            }

            currentGuess = IncrementPassword(currentGuess);

            timerText.text = $"Time remaining: {(maxTime - (Time.time - startTime)).ToString("F2")}s";
            yield return null; // Yield to keep the UI responsive
        }

        if (!passwordFound)
            resultText.text = "Password not cracked within time limit.";
    }

    string IncrementPassword(string guess)
    {
        var chars = guess.ToCharArray();
        for (int i = chars.Length - 1; i >= 0; i--)
        {
            int index = characterSet.IndexOf(chars[i]);
            if (index < characterSet.Length - 1)
            {
                chars[i] = characterSet[index + 1];
                return new string(chars);
            }
            chars[i] = characterSet[0];
        }
        return new string(chars) + characterSet[0];
    }
}

