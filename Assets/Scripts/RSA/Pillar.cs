using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pillar : MonoBehaviour
{
    public int NumberDisplayed;
    public new string name; // If hiding was intended
    public GameObject pillarsContainer; // Assign this in the inspector to the parent object of all pillars
	public bool isActive = false;


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
       if (pillarsContainer != null)
        {
            bool isActive = pillarsContainer.activeSelf;
            pillarsContainer.SetActive(!isActive);

            if (!isActive)
            {
                // Optionally handle correct or incorrect pillar selection here if needed
                Debug.Log("Pillars shown.");
            }
            else
            {
                Debug.Log("Pillars hidden.");
            }
		}
    }
}

