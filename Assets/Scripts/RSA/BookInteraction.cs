using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Numerics;


public class BookInteraction : MonoBehaviour
{
    public static event Action OnPhiCalculated;
	public static event Action OnBookClosed;
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI eDisplay;

    public static int CurrentPhi { get; private set; }
    public static int P { get; private set; }
    public static int Q { get; private set; }
	public static int EncryptedMessage { get; private set; }
    public static int PublicExponent { get; private set; }
    public static int Modulus { get; private set; }
    private static int PrivateExponent { get; set; }

    private List<int> primes = new List<int>();
    private bool valuesGenerated = false;

	public RSAInfoUpdater rsaInfoUpdater;

    void Start()
    {
        CurrentPhi = 0;
        P = 0;
        Q = 0;
		PublicExponent = 0;
		
		GenerateRandomNumbers();
		CalculatePhi();
		SetRSA();

        if (textDisplay != null)
            textDisplay.gameObject.SetActive(false);
		if (eDisplay != null)
            eDisplay.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!valuesGenerated)
            {
                GenerateRandomNumbers();
                CalculatePhi();
				SetRSA();
                DisplayNumbersAndPhi();
                valuesGenerated = true; // Ensure values are generated only once
				OnBookClosed?.Invoke();
            }
            else
            {
                DisplayNumbersAndPhi(); // If already generated, just display them
            }
        }
    }

    void GenerateRandomNumbers()
    {
        P = GetRandomPrimeNumber();
        do
        {
            Q = GetRandomPrimeNumber();
        } while (P == Q);
		valuesGenerated = true;
		Debug.Log($"valuesGenerated: {valuesGenerated}");
		CurrentPhi = (P - 1) * (Q - 1);
        Debug.Log($"Generated primes: p = {P}, q = {Q}");
    }

    void CalculatePhi()
    {
        CurrentPhi = (P - 1) * (Q - 1);
        Debug.Log($"Calculated phi: {CurrentPhi} (p: {P}, q: {Q})");

        Level5GameController controller = FindObjectOfType<Level5GameController>();

//		KeypadManager keypadManager = FindObjectOfType<KeypadManager>();
//        if (controller != null)
//        {
//        	controller.SetCorrectCode(CurrentPhi.ToString());  // Convert to string here
//        }
//        else
//        {
//            Debug.LogError("Level5GameController not found.");
//        }
//
//        if (keypadManager != null)
//        {
//        	keypadManager.SetCorrectCode(CurrentPhi.ToString());  // Convert to string here
//        }
//		else
//    	{
//        	Debug.LogError("KeypadController not found.");
//    	}
        OnPhiCalculated?.Invoke();
    }

	void SetRSA()
    {
//        PublicExponent = 65537;
        PublicExponent = ChoosePublicExponent();
        Modulus = P * Q;
        PrivateExponent = CalculatePrivateExponent(PublicExponent, CurrentPhi);
		int secret = UnityEngine.Random.Range(1, 200);
		EncryptedMessage = EncryptMessage(secret, PublicExponent, Modulus);
        if (rsaInfoUpdater != null)
        {
            rsaInfoUpdater.RevealDecryptionClueAndMethod(PrivateExponent);
        }
		var controller = FindObjectOfType<Level5GameController>();
        if (controller)
			controller.SetCorrectCode(DecryptMessage(EncryptedMessage).ToString());
        Debug.Log($"Secret: {secret}, Encrypted: {EncryptedMessage}");
		
//		KeypadManager keypadManager = FindObjectOfType<KeypadManager>();
//    	if (keypadManager != null)
//    	{
//        	keypadManager.SetCorrectCode(EncryptedMessage.ToString());  // Convert to string here
//    	}
	}

	int EncryptMessage(int message, int e, int n)
	{
    	return (int)BigInteger.ModPow(message, e, n);
	}

//	int DecryptMessage(int encryptedMessage, int d, int n)
//	{
//    	return (int)BigInteger.ModPow(encryptedMessage, d, n);
//	}
    int DecryptMessage(int encryptedMessage)
    {
        return (int)BigInteger.ModPow(encryptedMessage, PrivateExponent, Modulus);
    }


    void DisplayNumbersAndPhi()
    {
        if (textDisplay != null)
        {
            textDisplay.text = $"p = {P}\nq = {Q}";//\nphi = {CurrentPhi}";
            textDisplay.gameObject.SetActive(true);
        }
		if (eDisplay != null)
        {
            eDisplay.text = $"e {PublicExponent}\nn {Modulus}";
            eDisplay.gameObject.SetActive(true);
        }
    }

    int GetRandomPrimeNumber()
    {
        int number = UnityEngine.Random.Range(10, 50); // Explicitly specify UnityEngine.Random
        while (!IsPrime(number) || primes.Contains(number))
        {
            number++;
            if (number > 50) number = 10;
        }
        primes.Add(number);
        return number;
    }

    bool IsPrime(int n)
    {
        if (n <= 1) return false;
        if (n <= 3) return true;
        if (n % 2 == 0 || n % 3 == 0) return false;
        for (int i = 5; i * i <= n; i += 6)
            if (n % i == 0 || n % (i + 2) == 0)
                return false;
        return true;
    }

    int ChoosePublicExponent()
	{
		int e = 3;
    	while (BigInteger.GreatestCommonDivisor(new BigInteger(e), new BigInteger(CurrentPhi)) != 1)
        {
            e += 2;
        }
        return e;
	}
	int CalculatePrivateExponent(int e, int phi)
	{
		Debug.Log($"Calculating private exponent for e = {e} and phi = {phi}");
        Debug.Log($"Calculation of Private Exponent:  {(int)new BigInteger(e).ModInverse(new BigInteger(phi))}");
//    	return (int)BigInteger.ModPow(e, phi - 1, phi);  // Simplified, might need actual modular inverse calculation
        return (int)new BigInteger(e).ModInverse(new BigInteger(phi));
	}


}
