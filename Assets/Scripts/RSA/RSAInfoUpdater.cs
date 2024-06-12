using UnityEngine;
using TMPro;

public class RSAInfoUpdater : MonoBehaviour
{
    public TextMeshProUGUI clueForDText;
    public TextMeshProUGUI dValueText;
    public TextMeshProUGUI decryptionMethodText;

    private void Start()
    {
        // Initial hints or hidden
        clueForDText.text = "Find the silent partner that when multiplied by e gives remainder 1 with phi.";
        dValueText.text = "";  // Initially empty
        decryptionMethodText.text = "";
    }

    public void UpdateDValue(int d)
    {
        dValueText.text = $"Decryption key (d): {d}";
    }

    public void ShowDecryptionMethod()
    {
        decryptionMethodText.text = "Use d to decrypt: Message = (EncryptedMessage ^ d) % n";
    }

    // Call this method when the player discovers 'd'
    public void RevealDecryptionClueAndMethod(int d)
    {
        UpdateDValue(d);
        ShowDecryptionMethod();
    }
}