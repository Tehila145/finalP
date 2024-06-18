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
    public TMP_Text explanationText;  // TextMeshPro text to provide explanations

    public Passwords commonPasswords; // Reference to the ScriptableObject

    void Start()
    {
        // Ensure that the commonPasswords object is not null
        if (commonPasswords != null)
        {
            commonPasswords.AddPassword();
        }
        else
        {
            Debug.LogError("CommonPasswords ScriptableObject is not assigned.");
        }

        // Add a listener to update password validation in real-time if the input field is not null
        if (inputField != null)
        {
            inputField.onValueChanged.AddListener(delegate { ValidatePassword(inputField.text); });
        }
        else
        {
            Debug.LogError("Input field is not assigned.");
        }
    }

    public void ValidatePassword(string password)
    {
        PasswordStrength strength = EvaluatePasswordStrength(password);
        resultText.text = $"Password Strength: {strength}";
        explanationText.text = GeneratePasswordExplanation(password, strength);

        // Update the strength meter if it's used
        if (strengthMeter != null)
        {
            strengthMeter.value = (float)strength / 4;  // Convert enum to slider value
        }
        else
        {
            Debug.LogError("Strength meter is not assigned.");
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

        // Check against common password list
        if (commonPasswords.passwords.Contains(password.ToLower()))
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

    // Generate explanations for password strengths
    private string GeneratePasswordExplanation(string password, PasswordStrength strength)
    {
        if (strength == PasswordStrength.VeryWeak)
        {
            if (commonPasswords.passwords.Contains(password.ToLower()))
                return "This password is too common and easily guessed.";
            else
                return "This password is too short.";
        }
        else if (strength == PasswordStrength.Weak)
        {
            return "Consider using a mix of uppercase, lowercase, numbers, and symbols.";
        }
        else if (strength == PasswordStrength.Strong || strength == PasswordStrength.VeryStrong)
        {
            return "Great! Your password is strong.";
        }

        return "Your password could be improved.";
    }

    public enum PasswordStrength
    {
        VeryWeak,
        Weak,
        Medium,
        Strong,
        VeryStrong
    }
}
