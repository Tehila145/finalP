using UnityEngine;

public class RSAGameManager : MonoBehaviour
{
    public static RSAGameManager Instance;
    private int score = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void CoinCollected()
    {
        // Increment score or perform other actions when a coin is collected
        score++;
        Debug.Log("Coin collected! Current score: " + score);

        // You can add more complex game logic related to the RSA theme here
    }
}