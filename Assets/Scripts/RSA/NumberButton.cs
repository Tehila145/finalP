using UnityEngine;
using UnityEngine.UI;

public class NumberButton : MonoBehaviour
{
    public string value; // Use string to handle "X", "#", "*", and numeric values
    private Button button;
    private Level5GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<Level5GameController>();
        if (gameController == null)
        {
            Debug.LogError("Level5GameController not found in the scene.");
            return;
        }

        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => {
                // Directly use EnterDigit to handle all inputs, numeric or special
                gameController.EnterDigit(value);
            });
        }
        else
        {
            Debug.LogError("Button component not found on the gameObject.");
        }
    }
}
