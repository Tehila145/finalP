using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro; // Include the TextMeshPro namespace

public class GameController : MonoBehaviour
{
    public int requiredCorrectAnswers = 8; // Number of correct selections needed
    public TextMeshProUGUI feedbackText; // Now using TextMeshProUGUI instead of Text
    private HashSet<int> correctNumbers = new HashSet<int>(); // Set correct numbers
    private List<Button> selectedButtons = new List<Button>(); // Track selected buttons
    private int correctCount = 0;

    void Start()
    {
        if (feedbackText == null)
        {
            Debug.LogError("Feedback TextMeshPro is not assigned in the Inspector!");
            return; // Exit if feedbackText is not assigned to avoid further errors
        }

        feedbackText.text = ""; // Initialize feedback text safely
        InitializeCorrectNumbers();
    }

    void InitializeCorrectNumbers()
    {
        correctNumbers = new HashSet<int> {2, 3, 5, 7}; // Initialize with specific correct numbers
    }

    public void EvaluateSelection(Button button, int selectedNumber)
    {
        if (correctNumbers.Contains(selectedNumber))
        {
            if (button != null)
            {
                button.GetComponent<Image>().color = Color.green; // Highlight the button
                selectedButtons.Add(button); // Add to list of selected buttons
                correctCount++;
                CheckIfCompleted();
            }
        }
        else
        {
            ResetGame();
        }
    }

    private void CheckIfCompleted()
    {
        if (correctCount >= requiredCorrectAnswers)
        {
            feedbackText.text = "Correct"; // Display feedback using TextMeshPro
            // Optionally, proceed to next level or trigger other actions
        }
    }

    private void ResetGame()
    {
        foreach (Button button in selectedButtons)
        {
            if (button != null)
                button.GetComponent<Image>().color = Color.white; // Reset highlight safely
        }
        selectedButtons.Clear();
        correctCount = 0;
        feedbackText.text = ""; // Reset feedback text using TextMeshPro
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Optional: reset the scene
    }
}
