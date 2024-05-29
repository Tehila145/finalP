using System;
using System.Numerics;
using System.Security.Cryptography;
using UnityEngine;

public class RSAManager : MonoBehaviour
{
    private RSAParameters publicKey;
    private RSAParameters privateKey;

    void Start()
    {
        GenerateKeys();
    }

    public void GenerateKeys()
    {
        using (var rsa = new RSACryptoServiceProvider(512)) // Smaller key size for simplicity and performance in a game
        {
            publicKey = rsa.ExportParameters(false);
            privateKey = rsa.ExportParameters(true);
        }
    }

    public BigInteger EncryptData(string dataToEncrypt)
    {
        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.ImportParameters(publicKey);
            var dataToByte = System.Text.Encoding.UTF8.GetBytes(dataToEncrypt);
            var encryptedData = rsa.Encrypt(dataToByte, false);
            return new BigInteger(encryptedData);
        }
    }

    public string DecryptData(BigInteger dataToDecrypt)
    {
        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.ImportParameters(privateKey);
            byte[] decryptedData = rsa.Decrypt(dataToDecrypt.ToByteArray(), false);
            return System.Text.Encoding.UTF8.GetString(decryptedData);
        }
    }
}
