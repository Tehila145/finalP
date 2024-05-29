using UnityEngine;
using UnityEngine.UI;

public class GCDGameControl : MonoBehaviour
{
    public int numberA;
    public int numberB;
    public int gcd;
    public Text numberDisplay;
    public Text gcdDisplay;
    public Text collectedDisplay;

    private int coinsCollected = 0;

    void Start()
    {
        GenerateNumbers();
        gcd = CalculateGCD(numberA, numberB);
        UpdateUI();
    }

    void GenerateNumbers()
    {
        numberA = Random.Range(1, 101);
        numberB = Random.Range(1, 101);
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
            Debug.Log("Level Complete!");
            // Optionally reset or go to the next level
        }
    }

    void UpdateUI()
    {
        numberDisplay.text = "Numbers: " + numberA + " & " + numberB;
        gcdDisplay.text = "GCD: " + gcd;
        collectedDisplay.text = "Coins Collected: " + coinsCollected + " / " + gcd;
    }
}