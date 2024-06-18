using UnityEngine;
using UnityEngine.UI;

public class CalculatorButton : MonoBehaviour
{
    public string value; // Value can be "0"-"9", "Enter", "*", "#"
    private Button button;
    private RSACalculator rsaCalculator;

    void Start()
    {
        rsaCalculator = FindObjectOfType<RSACalculator>(); // Find the RSACalculator in the scene
        if (rsaCalculator == null)
        {
            Debug.LogError("RSACalculator not found in the scene.");
            return;
        }

        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => {
                rsaCalculator.OnKeyPressed(value);
            });
        }
        else
        {
            Debug.LogError("Button component not found on the gameObject.");
        }
    }
}