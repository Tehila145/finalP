using UnityEngine;
using UnityEngine.UI;

public class PrimeButton : MonoBehaviour
{
    public int value; // Prime number value for this button
    private Button button;
    private GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        if (gameController == null)
        {
            Debug.LogError("GameController not found in the scene.");
            return;
        }

        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => {
                // Now properly calling EvaluateSelection with the button and value
                gameController.EvaluateSelection(button, value);
            });
        }
        else
        {
            Debug.LogError("Button component not found on the gameObject.");
        }
    }
}