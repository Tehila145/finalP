using System;
using System.Text;
using System.Security.Cryptography;
using UnityEngine;

public class RSAManager1 : MonoBehaviour
{
    private RSACryptoServiceProvider rsa;

    private void Awake()
    {
        // Initialize RSA and generate keys
        rsa = new RSACryptoServiceProvider(2048); // Using a 2048-bit key size for security
    }

    public string EncryptData(string dataToEncrypt)
    {
        try
        {
            byte[] byteData = Encoding.UTF8.GetBytes(dataToEncrypt);
            byte[] encryptedData = rsa.Encrypt(byteData, true);
            return Convert.ToBase64String(encryptedData);
        }
        catch (Exception e)
        {
            Debug.LogError("Error encrypting data: " + e.Message);
            return null;
        }
    }

    public string DecryptData(string dataToDecrypt)
    {
        try
        {
            byte[] byteData = Convert.FromBase64String(dataToDecrypt);
            byte[] decryptedData = rsa.Decrypt(byteData, true);
            return Encoding.UTF8.GetString(decryptedData);
        }
        catch (Exception e)
        {
            Debug.LogError("Error decrypting data: " + e.Message);
            return null;
        }
    }

    public string GetPublicKey()
    {
        return rsa.ToXmlString(false); // Export only the public key
    }

    public void AssignNewKeys()
    {
        rsa = new RSACryptoServiceProvider(2048);
    }
}