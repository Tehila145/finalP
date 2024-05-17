using UnityEngine;



public class ChandlerBing : MonoBehaviour
{
    public GameObject objectCard; // Use lowercase for consistency
    public GameObject closeButton;
    public GameObject icyButton;   // Use lowercase for consistency
    void Start()
    {  
        objectCard.SetActive(false);
        closeButton.SetActive(false);
        icyButton.SetActive(false);
    }

    void Update()
    {
    }

    public void OpenCard()
    {

        objectCard.SetActive(true);
        closeButton.SetActive(true);
        icyButton.SetActive(true);
    }

    public void CloseCard()
    {
        objectCard.SetActive(false);
        closeButton.SetActive(false);
        icyButton.SetActive(false);
    }
}
