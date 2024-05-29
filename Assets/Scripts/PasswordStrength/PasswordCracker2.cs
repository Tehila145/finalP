// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;
// // using TMPro;
// //
// // public class PasswordCracker2 : MonoBehaviour
// // {
// //    public TMP_InputField inputField; // Input field for the password
// //    public TMP_Text resultText; // Text element to display the result
// //    public TMP_Text timerText; // Text element to display the timer
// //    public Button checkButton; // Button to check the password strength
// //    private DatabaseManager dbManager; // Reference to the DatabaseManager
// //    private int maxPasswordLength = 16; // Maximum length for the brute force attack
// //    private int maxTime = 50; // Maximum time for the brute force attack
// //    private string currentGuess = ""; // Current guess during the brute force attack
// //
// //    void start()
// //    {
// //       dbManager = FindObjectOfType<DatabaseManager>(); // Find the DatabaseManager component
// //       if (dbManager == null)
// //       {
// //          Debug.LogError("DatabaseManager component not found on this GameObject.");
// //       }
// //
// //       checkButton.onClick.AddListener(CheckPasswordStrength); // Add a listener to the check button, means when the button is clicked, the CheckPasswordStrength method will be called
// //    }
// //    
// //    void CheckPasswordStrength()
// //    {
// //       string password = inputField.text.Trim(); // Get the password from the input field and remove any leading or trailing whitespace
// //       if (string.IsNullOrEmpty(password)) // Check if the password is empty or null
// //       {
// //          resultText.text = "Please enter a password."; // Display an error message if the password is empty
// //          return;
// //       }
// //
// //       StartCoroutine(CheckPassword(password)); // Start the coroutine to check the password strength
// //    }
// //    
// //    //CheckPassword() will check if the entered password is a common password or not. If it is a common password, it will display a message indicating that the password is weak. If it is not a common password, it will start the brute force attack.
// //    IEnumerator CheckPassword(string enteredPassword)
// //    {
// //       if (dbManager.commonPasswords.Contains(enteredPassword)) // Check if the entered password is a common password
// //       {
// //          resultText.text = "Weak password: Commonly used."; // Display a message indicating that the password is weak
// //       }
// //       else
// //       {
// //          yield return StartCoroutine(BruteForceAttack(enteredPassword)); // Start the brute force attack if the password is not a common password
// //       }
// //    }
// //    //BruteForceAttack() will perform a brute force attack to crack the password. It generates all possible combinations of characters up to a certain length and compares them with the target password.
// //    IEnumerator BruteForceAttack(string targetPassword)
// //    {
// //       float startTime = Time.time; // Get the start time of the brute force attack
// //       while (Time.time - startTime < maxTime) // Check if the time limit for the brute force attack has not been reached
// //       {
// //          string guess = "";
// //          //for loop to try all possible combinations of characters up to a certain length
// //          for (int i = 1; i <= maxPasswordLength; i++)
// //          {
// //             guess = GenerateNextGuess(i); // Generate the next guess with the specified length
// //             if (guess == targetPassword) // Check if the guess matches the target password
// //             {
// //                resultText.text = "Password cracked: " + guess; // Display the cracked password
// //                yield break; // Exit the coroutine
// //             }
// //          }
// //
// //          resultText.text =
// //             "Password not cracked within time limit."; // Display a message indicating that the password was not cracked within the time limit
// //       }
// //    }
// //
// //    //GenerateNextGuess() will generate the next guess for the brute force attack based on the current guess and the maximum length of the password.
// //    string GenerateNextGuess(int length)
// //    {
// //       string guess = currentGuess; // Initialize the guess with the current guess
// //       if (string.IsNullOrEmpty(guess)) // Check if the current guess is empty
// //       {
// //          guess = new string('a', length); // Initialize the guess with the first character
// //       }
// //       else
// //       {
// //          char[] charArray = guess.ToCharArray(); // Convert the guess to a character array
// //          int index = charArray.Length - 1; // Get the index of the last character
// //          while (index >= 0) // Loop through the characters in reverse order
// //          {
// //             if (charArray[index] < 'z') // Check if the character is not 'z'
// //             {
// //                charArray[index]++; // Increment the character
// //                break; // Exit the loop
// //             }
// //             else
// //             {
// //                charArray[index] = 'a'; // Reset the character to 'a'
// //                index--; // Move to the previous character
// //             }
// //          }
// //
// //          guess = new string(charArray); // Convert the character array back to a string
// //       }
// //
// //       currentGuess = guess; // Update the current guess
// //       return guess; // Return the generated guess
// //    }
// // }
//
//
//
//
//
//
// //
// //     IEnumerator BruteForceAttack(string targetPassword)
// //     {
// //         float startTime = Time.time;
// //         currentGuess = "";// Reset the current guess
// //         while (Time.time - startTime < maxTime)  // maxTime - time limit for the brute force attack
// //         {
// //             string guess = GenerateNextGuess();
// //             if (guess == targetPassword)
// //             {
// //                 resultText.text = "Password cracked: " + guess;
// //                 yield break;
// //             }
// //             timerText.text = $"Time remaining: {(maxTime - (Time.time - startTime)).ToString("F2")}s";
// //             yield return null;  // Yield to keep the UI responsive
// //         } 
// //         resultText.text = "Password not cracked. Good Job!";
// //     }
// //
// //     string GeneratorNextGuess()
// //     {
// //         if (string.IsNullOrEmpty(currentGuess))
// //         {
// //             currentGuess = new string('!', maxPasswordLength); // Start with the shortest password.
// //             return currentGuess;
// //         }
// //         var chars = currentGuess.ToCharArray();
// //         
// //     }
// //
// //     // IEnumerator BruteForceAttack(string targetPassword)
// //     // {
// //     //     float startTime = Time.time;
// //     //     currentGuess = "";// Reset the current guess
// //     //     while (Time.time - startTime < maxTime)  // maxTime - time limit for the brute force attack
// //     //     {
// //     //         string guess = GenerateNextGuess();
// //     //         if (guess == targetPassword)
// //     //         {
// //     //             resultText.text = "Password cracked: " + guess;
// //     //             yield break;
// //     //         }
// //     //         timerText.text = $"Time remaining: {(maxTime - (Time.time - startTime)).ToString("F2")}s";
// //     //         yield return null;  // Yield to keep the UI responsive
// //     //     }
// //     //     resultText.text = "Password not cracked. Good Job!";
// //     // }
// //     //
// //     // string GenerateNextGuess()
// //     // {
// //     //     if (string.IsNullOrEmpty(currentGuess))
// //     //     {
// //     //         currentGuess = new string('!', maxPasswordLength); // Start with the shortest password.
// //     //         return currentGuess;
// //     //     }
// //     //
// //     //     var chars = currentGuess.ToCharArray();
// //     //     bool carry = true;
// //     //
// //     //     for (int i = chars.Length - 1; i >= 0 && carry; i--)
// //     //     {
// //     //         if (chars[i] < '~') // '~' is the highest ASCII character that is commonly used.
// //     //         {
// //     //             chars[i]++;
// //     //             carry = false;
// //     //         }
// //     //         else
// //     //         {
// //     //             chars[i] = '!'; // Reset this character and carry to the next.
// //     //         }
// //     //     }
// //     //
// //     //     currentGuess = new string(chars);
// //     //     return currentGuess;
// //     // }
// // }
//
// using System.Collections;
// using UnityEngine;
// using TMPro;
// using UnityEngine.UI;
// using ExcelDataReader;
// using System.IO;
// using System.Data;
// using ExcelDataReader;
//
// public class PasswordCracker2 : MonoBehaviour
// {
//     public TMP_InputField inputField; // Input field for the password
//     public TMP_Text resultText; // Text element to display the result
//     public TMP_Text timerText; // Text element to display the timer
//     public Button checkButton;
//     private int maxPasswordLength = 16; // Maximum length for the brute force attack
//     private int maxTime = 50; // Maximum time for the brute force attack
//     private string currentGuess = ""; // Current guess during the brute force attack
//
//     void Start()
//     {
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
//     // IEnumerator CheckPassword(string enteredPassword)
//     // {
//     //     string path = "Assets/Data/1000 common passwords.xlsx"; // Set the path to your Excel file
//     //     using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read))
//     //     {
//     //         using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
//     //         {
//     //             DataSet dataSet = reader.AsDataSet();
//     //             DataTable dataTable = dataSet.Tables[0];
//     //             foreach (DataRow row in dataTable.Rows)
//     //             {
//     //                 string password = row[0].ToString(); // Assuming the passwords are in the first column
//     //                 if (password == enteredPassword)
//     //                 {
//     //                     resultText.text = "Weak password: Commonly used."; // Display a message indicating that the password is weak
//     //                     yield break;
//     //                 }
//     //             }
//     //         }
//     //     }
//     //
//     //     yield return StartCoroutine(BruteForceAttack(enteredPassword)); // Start the brute force attack if the password is not found in the Excel file
//     // }
//
//     IEnumerator CheckPassword(string enteredPassword)
//     {
//         string path = "Assets/Data/1000CommonPasswords.xlsx"; // Set the path to your Excel file
//         using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read))
//         {
//             using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
//             {
//                 DataSet dataSet = reader.AsDataSet();
//                 DataTable dataTable = dataSet.Tables[0];
//                 foreach (DataRow row in dataTable.Rows)
//                 {
//                     string password = row[0].ToString(); // Assuming the passwords are in the first column
//                     if (password == enteredPassword)
//                     {
//                         resultText.text = "Weak password: Commonly used."; // Display a message indicating that the password is weak
//                         yield break;
//                     }
//                 }
//             }
//         }
//
//         yield return StartCoroutine(BruteForceAttack(enteredPassword)); // Start the brute force attack if the password is not found in the Excel file
//     }
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
