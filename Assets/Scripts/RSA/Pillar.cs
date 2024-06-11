using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pillar : MonoBehaviour
{
    public int NumberDisplayed;
    public new string name; // If hiding was intended


    void Start()
    {
        TextMeshProUGUI textComponent = GetComponentInChildren<TextMeshProUGUI>();
        if (textComponent != null)
        {
            NumberDisplayed = int.Parse(textComponent.text);
        }
    }

    void OnMouseDown() // or use an event trigger component if using UI elements
    {
        if (NumberDisplayed == BookInteraction.CurrentPhi)
        {
            Debug.Log("Correct pillar selected!");
            // Handle correct selection
        }
        else
        {
            Debug.Log("Incorrect pillar selected.");
            // Handle incorrect selection
        }
    }
}

