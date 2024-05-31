using UnityEngine;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    public TextMeshProUGUI interactionTMP;
    public KeyCode interactionKey = KeyCode.E;
    private bool isPlayerInRange = false;

    void Start()
    {
        if (interactionTMP == null || interactionTMP.transform.parent == null)
        {
            Debug.LogError("Start: TextMeshPro or its parent is not assigned in the Inspector!");
        }
        else
        {
            interactionTMP.transform.parent.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(interactionKey))
        {
            if (interactionTMP != null && interactionTMP.transform.parent != null)
            {
                interactionTMP.transform.parent.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogError("Update: TextMeshPro component or parent GameObject is missing or destroyeddd");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Player is now in range.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (interactionTMP != null && interactionTMP.transform.parent != null)
            {
                interactionTMP.transform.parent.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("OnTriggerExit2D: TextMeshPro component or parent GameObject is missing or destroyed");
            }
        }
    }
}
