using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class BookInteractionClosed : MonoBehaviour
{
    public GameObject pillarPrefab;
    public RectTransform spawnPoint;
    public float spacing = 200f;

    private List<int> pillarNumbers = new List<int>();
    private bool bookOpened = false;

    void OnEnable()
    {
        BookInteraction.OnBookClosed += GenerateAndDisplayPillars;  // Correctly subscribe to the event
    }

    void OnDisable()
    {
        BookInteraction.OnBookClosed -= GenerateAndDisplayPillars;  // Correctly unsubscribe from the event
    }

    
    private void GenerateAndDisplayPillars()
    {
        StartCoroutine(WaitForPhiAndGenerateNumbers());
    }

    private IEnumerator WaitForPhiAndGenerateNumbers()
    {
        // Wait until phi is calculated (phi is not 0)
        while (BookInteraction.CurrentPhi == 0)
        {
            Debug.Log("Waiting for phi to be calculated...");
            yield return null; // Wait for the next frame and check again
        }
        yield return new WaitUntil(() => BookInteraction.CurrentPhi != 0);

        Debug.Log("Phi is ready, generating unique numbers.");
        GenerateUniqueNumbers();
        SpawnPillars();
    }

    void GenerateUniqueNumbers()
    {
        pillarNumbers.Clear();
        int phi = BookInteraction.CurrentPhi; // Assume phi is calculated and available here
        Debug.Log("Phi value retrieved for pillars: " + phi);
        pillarNumbers.Add(phi); // Add phi first

        // Generate two other unique numbers
        while (pillarNumbers.Count < 3)
        {
            int num = Random.Range(1, 100);
            if (!pillarNumbers.Contains(num) && num != phi)
            {
                pillarNumbers.Add(num);
                Debug.Log("Added unique number: " + num);
            }
        }

        Debug.Log("Final numbers for pillars: " + string.Join(", ", pillarNumbers));
    }

    void SpawnPillars()
    {
        Vector3 centerPosition = spawnPoint.position;
        for (int i = 0; i < 3; i++)
        {
            GameObject pillar = Instantiate(pillarPrefab, centerPosition + Vector3.right * (i - 1) * spacing, Quaternion.identity);
            pillar.transform.SetParent(spawnPoint, false);
            pillar.transform.localScale = Vector3.one;

            TextMeshProUGUI textComponent = pillar.GetComponentInChildren<TextMeshProUGUI>();
            if (textComponent != null)
            {
                textComponent.text = pillarNumbers[i].ToString();
                Debug.Log($"Pillar {i} set with number: {pillarNumbers[i]}");
            }
        }
    }
}
