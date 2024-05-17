using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class UserData : MonoBehaviour
{
    [SerializeField] InputField inputField; // Serialize the reference for easier assignment in Inspector
    public UnityEngine.UI.Text text;
    [SerializeField] BushWithEyes bush;


    private string name;
    private string city;
    private string country;
    private string hobby;
    private static int questionNum = 0;
    private static int IDCharacter;

    //question

    void Start()
    {
        

        if (inputField == null) // Check if InputField is assigned before using it
        {
            Debug.LogError("InputField not assigned in UserData script!");
            return; // Exit Start() if no InputField found
        }

        inputField.onEndEdit.AddListener(OnEndEdit);
    }

    public void OnEndEdit(string inputText)
    {

             switch (questionNum)
        {
            case 0:
                name = inputText;
                questionNum++;
                Debug.Log("Name: " + name + "\n" + questionNum);
                break;
            case 1:
                city = inputText;
                questionNum++;
                Debug.Log("City: " + city + "\n" + questionNum);
                break;
            case 2:
                country = inputText;
                questionNum++;
                Debug.Log("Country: " + country+"\n" + questionNum);
                break;
            case 3:
                hobby = inputText;
                questionNum++;
                Debug.Log("Hobby: " + hobby + "\n" + questionNum);
                // You can potentially do something with the collected data here
                break;
            default:
                Debug.Log("Unexpected question number");
                break;
        }
        bush.DestroyBush();
        
        //Destroy(transform.parent.gameObject);

        //inputField.transform.parent.gameObject.SetActive(true);
    }

    // Update is called once per frame (can be removed if not used)
    void Update()
    {
        switch (questionNum)
        {
            case 0:
                text.text = "Hi, very nice. My name is Bolly.\r\nWhat is your name?";
                break;
            case 1:
                text.text = "Remind me what city do you live in?";
                break;
            case 2:
                text.text = "Is this a city in the Solomon Islands? In which country?";
                break;
            case 3:
                text.text = "I really like to draw what do you like?";
                break;
            default:
                Debug.Log("Unexpected question number");
                break;

        }
        //questionNum++;
    }

    public void GetIDCharacter(int ID)
    {
        IDCharacter = ID;
        Debug.Log(ID);
    }



}
