using UnityEngine;
using UnityEngine.UI;

public class KeyInteraction : MonoBehaviour
{
    public GameObject displayImage; // Assign the UI Image GameObject in the inspector

    void Start()
    {
        if (displayImage != null)
            displayImage.SetActive(false); // Initially hide the image
    }

    private void OnMouseDown()
    {
        // Toggle the visibility of the image
        if (displayImage != null)
            displayImage.SetActive(!displayImage.activeSelf);
    }
}