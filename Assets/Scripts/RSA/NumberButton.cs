using UnityEngine;
using UnityEngine.UI;

public class NumberButton : MonoBehaviour
{
    public int number; // Assign this number via the Inspector to match the button
    private Button button;
    private GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<GameController>(); // Find the GameController in the scene
        button = GetComponent<Button>();
        button.onClick.AddListener(() => gameController.EvaluateSelection(button, number));
    }
}