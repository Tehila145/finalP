using UnityEngine;
using UnityEngine.UI;

public class NumberButton : MonoBehaviour
{
    public string value; // Assign this value via the Inspector to match the button, can be "1", "2", "X", "#", "*"
    private Button button;
    private GameController gameController;

    void Start()
    {
        // Find the GameController in the scene
        gameController = FindObjectOfType<GameController>();
        if (gameController == null)
        {
            Debug.LogError("GameController not found in the scene.");
            return;
        }

        // Get the Button component and add the onClick listener
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => gameController.EvaluateSelection(value));
        }
        else
        {
            Debug.LogError("Button component not found on the gameObject.");
        }
    }
}