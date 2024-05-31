using System.Collections;
using UnityEngine;
using TMPro;  
using UnityEngine.UI;
using System.Collections.Generic;


public class PasswordManager : MonoBehaviour
{
    public TMP_InputField inputField;  
    public TMP_Text resultText;        
    public Slider strengthMeter;       

    void Start()
    {
        // Optionally, you could add an on-value-changed listener to the input field to update in real-time
        inputField.onValueChanged.AddListener(delegate { ValidatePassword(inputField.text); });
    }

    public void ValidatePassword(string password)
    {
        PasswordStrength strength = EvaluatePasswordStrength(password);
        resultText.text = $"Password Strength: {strength}";

        // Update the strength meter if it's used
        if (strengthMeter != null)
        {
            strengthMeter.value = (float)strength / 4;  // Convert enum to slider value
        }
    }

    private PasswordStrength EvaluatePasswordStrength(string password)
    {
        int score = 0;

        if (password.Length < 6)
            return PasswordStrength.VeryWeak;

        if (password.Length >= 8)
            score++;
        if (password.Length >= 12)
            score++;
        if (System.Text.RegularExpressions.Regex.IsMatch(password, @"\d"))
            score++;
        if (System.Text.RegularExpressions.Regex.IsMatch(password, @"[a-z]"))
            score++;
        if (System.Text.RegularExpressions.Regex.IsMatch(password, @"[A-Z]"))
            score++;
        if (System.Text.RegularExpressions.Regex.IsMatch(password, @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]"))
            score++;


        // Simulate checking against a common password list (make sure to implement this properly in a real scenario)
        if (CommonPasswords.Contains(password.ToLower()))
            return PasswordStrength.VeryWeak;

        switch (score)
        {
            case 0:
            case 1:
                return PasswordStrength.Weak;
            case 2:
            case 3:
                return PasswordStrength.Medium;
            case 4:
            case 5:
                return PasswordStrength.Strong;
            default:
                return PasswordStrength.VeryStrong;
        }
    }

    // Dummy list of common passwords for example purposes
    private HashSet<string> CommonPasswords = new HashSet<string>
    {
        "password", "123456", "12345678", "qwerty", "abc123"
    };

    public enum PasswordStrength
    {
        VeryWeak,
        Weak,
        Medium,
        Strong,
        VeryStrong
    }
}
