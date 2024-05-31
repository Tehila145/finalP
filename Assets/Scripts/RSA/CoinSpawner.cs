using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Assign the coin prefab in the inspector
    public int maxCoins; // Set dynamically or statically, depending on your game's logic
    private int coinsSpawned = 1;

    void Start()
    {
        SpawnCoin(); // Initial spawn
    }
    public void SetMaxCoins(int max)
    {
        maxCoins = max;
        SpawnCoin(); // Spawn the first coin after setting the max
    }

    public void SpawnCoin()
    {
        while (coinsSpawned < maxCoins)
        {
            Instantiate(coinPrefab, GenerateRandomPosition(), Quaternion.identity);
            coinsSpawned++;
            Debug.Log($"Updating Coins Spawned: Numbers = {coinsSpawned}");
        }
    }

    private Vector3 GenerateRandomPosition()
    {
        // Assuming a 2D game, generate a position within screen bounds
        // Adjust the values according to your game's design
        float x = Random.Range(-8f, 8f);
        float y = Random.Range(-4f, 4f);
        return new Vector3(x, y, 0);
    }
}