using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level5GameController : MonoBehaviour
{
    // Define level-specific properties and methods
    public TextMeshProUGUI feedbackText;
    public GameObject portal;
    private int playerScore;

    void Start()
    {
        // Initialize level-specific elements
        feedbackText.text = "Welcome to Level 2!";
        portal.SetActive(false);
    }

    // Example method for level-specific functionality
    public void UpdateScore(int points)
    {
        playerScore += points;
        feedbackText.text = "Score: " + playerScore;
        if (playerScore > 100)
        {
            portal.SetActive(true);
            feedbackText.text = "Portal Opened!";
        }
    }
}