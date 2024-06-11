using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject panel; // Assign this in the inspector

    public void TogglePanel()
    {
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf);
        }
        else
        {
            Debug.LogError("Panel is not assigned!");
        }
    }
}