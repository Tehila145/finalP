using System;
using UnityEngine;
using System.Numerics;
using TMPro;

public class RSACalculator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText;
    private int currentStep = 0;  // 0 for p, 1 for q, 2 for e
    private BigInteger p, q, e, phi, d;
    private string currentInput = "";

    void Start()
    {
        ResetCalculator();
    }

    public void OnKeyPressed(string key)
    {
        if (key == "Enter")
        {
            ProcessCurrentInput();
            return;
        }
        if (key == "*")
        {
            ToggleCurrentStep();
            return;
        }
        if (key == "#")
        {
            FinalizeCalculation();
            return;
        }
        if (key == "C")  // Clear button pressed
        {
            ResetCalculator();
            return;
        }

        // Append number to current input
        if (int.TryParse(key, out int num))
        {
            currentInput += num;
            UpdateDisplay();
        }
    }

    private void ProcessCurrentInput()
    {
        switch (currentStep)
        {
            case 0:  // p input
                p = BigInteger.Parse(currentInput);
                currentStep++;
                displayText.text = "Enter q:";
                break;
            case 1:  // q input
                q = BigInteger.Parse(currentInput);
                currentStep++;
                displayText.text = "Enter e:";
                break;
            case 2:  // e input
                e = BigInteger.Parse(currentInput);
                CalculatePhi();
                break;
        }
        currentInput = "";  // Clear input after processing
    }

    private void ToggleCurrentStep()
    {
        currentStep = (currentStep + 1) % 3;  // Cycle through p, q, e
        switch (currentStep)
        {
            case 0:
                displayText.text = "Enter p:";
                break;
            case 1:
                displayText.text = "Enter q:";
                break;
            case 2:
                displayText.text = "Enter e:";
                break;
        }
    }

    private void CalculatePhi()
    {
        phi = (p - 1) * (q - 1);
        CalculateD();
    }

    private void CalculateD()
    {
        if (BigInteger.GreatestCommonDivisor(e, phi) == 1) // Ensure e and phi are coprime
        {
            d = BigIntegerExtensions.ModInverse(e, phi); // Correctly calculating d using the modular inverse
            displayText.text = $"d: {d}";
        }
        else
        {
            displayText.text = "Error: e and phi(n) must be coprime.";
        }
    }


    private void FinalizeCalculation()
    {
        displayText.text = $"p: {p}, q: {q}, phi: {phi}, d: {d}";
        ResetCalculator();
    }

    private void UpdateDisplay()
    {
        displayText.text = currentInput;
    }

    private void ResetCalculator()
    {
        currentStep = 0;
        p = q = e = phi = d = 0;
        currentInput = "";
        displayText.text = "Enter p:";
    }
}
