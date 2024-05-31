using UnityEngine;
using UnityEngine.UI;
using TMPro; // Include the TextMeshPro namespace
public class GCDGameControl : MonoBehaviour
{
    public int numberA;
    public int numberB;
    public int gcd;
    public TextMeshProUGUI numberDisplay;
    public TextMeshProUGUI gcdDisplay;
    public TextMeshProUGUI collectedDisplay;

    private int coinsCollected = 0;

    void Start()
    {
        GenerateNumbers();
        gcd = CalculateGCD(numberA, numberB);
        UpdateUI();
        FindObjectOfType<CoinSpawner>().SetMaxCoins(gcd);
    }

    void GenerateNumbers()
    {
        numberA = Random.Range(1, 500);
        numberB = Random.Range(1, 500);
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
    public int GetGCD()
    {
        return gcd;
    }

    public void CollectCoin()
    {
        coinsCollected++;
        UpdateUI();

        if (coinsCollected == gcd)
        {
            Debug.Log("Level Complete!");
            // Optionally reset or go to the next level
        }
    }

    void UpdateUI()
    {
        Debug.Log($"Updating UI: Numbers = {numberA}, {numberB}; GCD = {gcd}; Coins = {coinsCollected}/{gcd}");
        if (numberDisplay == null || gcdDisplay == null || collectedDisplay == null)
        {
            Debug.LogError("One or more Text components are not assigned!");
            return;
        }

        numberDisplay.text = $"Numbers: {numberA} & {numberB}";
        gcdDisplay.text = $"GCD: {gcd}";
        collectedDisplay.text = $"Coins Collected: {coinsCollected} / {gcd}";
    }
}

