using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public void OnIcyButtonClicked()
    {
        // טעינת סצנה עם UserData
        SceneManager.LoadScene("Maze runner");

        // גישה לרכיב UserData לאחר טעינת הסצנה
        GameObject userDataObject = GameObject.Find("Bush (1)"); // החלף בשם האובייקט האמיתי
        UserData userdata = userDataObject.GetComponent<UserData>();
        switch (icyButton.name)
        {
            case "Evelyn Hart ICY button":
                {
                    userdata.GetIDCharacter(1);
                }
                break;
            case "Daniel Hart ICY button":
                {
                    userdata.GetIDCharacter(2);
                }
                break;
            case "Samantha Johnson ICY button":
                {
                    userdata.GetIDCharacter(3);
                }
                break;
            case "Michael Smith ICY button":
                {
                    userdata.GetIDCharacter(4);
                }
                break;
            case "Emily Brown ICY button":
                {
                    userdata.GetIDCharacter(5);
                }
                break;
            case "Chandler Bing ICY button":
                {
                    Debug.Log(icyButton.name);
                    userdata.GetIDCharacter(6);
                }
                break;
            case "James Bond ICY button":
                {
                    userdata.GetIDCharacter(7);
                }
                break;
            case "Sean Paul ICY button":
                {
                    userdata.GetIDCharacter(8);
                }
                break;
        }
        
    }
}
