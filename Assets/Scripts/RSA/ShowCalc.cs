using UnityEngine;

public class ShowCalc : MonoBehaviour
{
    public GameObject calculatorObject; // Assign this in the Unity Editor

    void Start()
    {
        // Optionally hide the calculator at the start
        if (calculatorObject != null)
            calculatorObject.SetActive(false);
    }

    void OnMouseDown()
    {
        // Toggle the visibility of the calculator object when this object is clicked
        if (calculatorObject != null)
            calculatorObject.SetActive(!calculatorObject.activeSelf);
    }
}
