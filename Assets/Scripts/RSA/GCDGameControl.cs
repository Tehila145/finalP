using UnityEngine;
using TMPro; // Include the TextMeshPro namespace

public class GCDGameControl : MonoBehaviour
{
    public int numberP;
    public int numberQ;
    public int gcd;
    public TextMeshProUGUI statusDisplay; // UI element to display all information
    public GameObject portal;  // Reference to the portal GameObject

    private int coinsCollected = 0;

    void Start()
    {
        GenerateNumbers();
        gcd = CalculateGCD(numberP, numberQ);
        UpdateUI();
        portal.SetActive(false); // Ensure the portal is initially hidden

        // Trigger coin spawning with the calculated GCD as the maximum number
        var coinSpawner = FindObjectOfType<CoinSpawner>();
        if (coinSpawner != null)
        {
            coinSpawner.SetMaxCoins(gcd);
        }
        else
        {
            Debug.LogError("CoinSpawner not found in the scene!");
        }
    }

    void GenerateNumbers()
    {
        numberP = Random.Range(2, 1000);
        numberQ = Random.Range(2, 1000);
    }

    int CalculateGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public void CollectCoin()
    {
        coinsCollected++;
        UpdateUI();
        if (coinsCollected == gcd)
        {
            Debug.Log("All coins collected. Portal activated!");
            portal.SetActive(true); // Activate the portal when all coins are collected
        }
    }

    void UpdateUI()
    {
        if (statusDisplay == null)
        {
            Debug.LogError("Status TextMeshPro component is not assigned!");
            return;
        }

        statusDisplay.text = $"Numbers: p = {numberP}, q = {numberQ} | GCD: {gcd} | Coins: {coinsCollected}/{gcd}";
    }
}
