using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneNameToLoad;
    public KeyCode activationKey = KeyCode.UpArrow;  

    private bool isPlayerOnTile = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerOnTile = true;
        }
    }
    
    void Update()
    {
        if (isPlayerOnTile && Input.GetKeyDown(activationKey))
        {
            SceneManager.LoadScene(sceneNameToLoad);
            Debug.Log("Up Arrow key was pressed.");
        }
    }
}