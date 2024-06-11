using UnityEngine;
using TMPro;

public class PillarInteraction : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    private int number;

    void Start()
    {
        textComponent = GetComponentInChildren<TextMeshProUGUI>();
        if (textComponent != null)
        {
            number = int.Parse(textComponent.text);
        }
    }

    void OnMouseDown()
    {
        // This method is called when the player clicks on the pillar
        HandleInteraction();
    }

    private void HandleInteraction()
    {
        // Check if the clicked pillar has the correct phi value
        if (number == BookInteraction.CurrentPhi)
        {
            Debug.Log("Correct pillar selected!");
            // You can add additional logic here, such as:
            // - Highlighting the pillar
            // - Displaying a success message
            // - Triggering an animation
        }
        else
        {
            Debug.Log("Incorrect pillar selected.");
            // You can add additional logic here, such as:
            // - Displaying an error message
            // - Shaking the pillar
        }
    }
}