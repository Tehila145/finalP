using UnityEngine;

public class Coin : MonoBehaviour
{
    public KeyCode collectKey = KeyCode.E;  // Key to press to collect the coin
    private bool isPlayerNear = false;      // Flag to check if the player is near the coin

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(collectKey))
        {
            CollectCoin();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;  // Set the flag when the player enters the trigger area
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false; // Clear the flag when the player exits the trigger area
        }
    }

    private void CollectCoin()
    {
        // Assuming there's a central game manager to handle the coin collection logic
        GCDGameControl gameControl = FindObjectOfType<GCDGameControl>();
        if (gameControl != null)
        {
            gameControl.CollectCoin();
        }
        gameObject.SetActive(false);  // Deactivate the coin after collection
    }
}
