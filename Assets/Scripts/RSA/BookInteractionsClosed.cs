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
    private List<GameObject> instantiatedPillars = new List<GameObject>(); // Store instantiated pillars
    private bool bookOpened = false;

	    void Start()
    {
        // Start by generating numbers and preparing pillars, but do not show them yet
        GenerateUniqueNumbers();
        PreparePillars();
    }

    void OnEnable()
    {
        BookInteraction.OnBookClosed += GenerateAndDisplayPillars;
    }

    void OnDisable()
    {
        BookInteraction.OnBookClosed -= GenerateAndDisplayPillars;
    }

    private void GenerateAndDisplayPillars()
    {
        StartCoroutine(WaitForPhiAndGenerateNumbers());
    }

    private IEnumerator WaitForPhiAndGenerateNumbers()
    {
        while (BookInteraction.CurrentPhi == 0)
        {
            Debug.Log("Waiting for phi to be calculated...");
            yield return null;
        }
        GenerateUniqueNumbers();
        SpawnPillars();
    }

    void GenerateUniqueNumbers()
    {
        pillarNumbers.Clear();
        int phi = BookInteraction.CurrentPhi;
        pillarNumbers.Add(phi);

        while (pillarNumbers.Count < 3)
        {
            int num = Random.Range(1, 500);
            if (!pillarNumbers.Contains(num) && num != phi)
            {
                pillarNumbers.Add(num);
            }
        }
    }

	void SpawnPillars()
    {
        ClearPillars();  // Clear existing pillars first
        Vector3 centerPosition = spawnPoint.position;
        for (int i = 0; i < 3; i++)
        {
            GameObject pillar = Instantiate(pillarPrefab, centerPosition + Vector3.right * (i - 1) * spacing, Quaternion.identity);
            pillar.transform.SetParent(spawnPoint, false);
            pillar.transform.localScale = Vector3.one;
            instantiatedPillars.Add(pillar);

            TextMeshProUGUI textComponent = pillar.GetComponentInChildren<TextMeshProUGUI>();
            if (textComponent != null)
            {
                textComponent.text = pillarNumbers[i].ToString();
            }
        }
    }

    void PreparePillars()  // Replaces SpawnPillars
    {
        ClearPillars();
        Vector3 centerPosition = spawnPoint.position;
        for (int i = 0; i < 3; i++)
        {
            GameObject pillar = Instantiate(pillarPrefab, centerPosition + Vector3.right * (i - 1) * spacing, Quaternion.identity);
            pillar.transform.SetParent(spawnPoint, false);
            pillar.transform.localScale = Vector3.one;
            instantiatedPillars.Add(pillar);

            TextMeshProUGUI textComponent = pillar.GetComponentInChildren<TextMeshProUGUI>();
            if (textComponent != null)
            {
                textComponent.text = pillarNumbers[i].ToString();
            }
        }
        this.gameObject.SetActive(false);  // Initially hide all pillars
    }

    // Public method to deactivate all pillars
    public void ClearPillars()
    {
        foreach (GameObject pillar in instantiatedPillars)
        {
            Destroy(pillar);
        }
        instantiatedPillars.Clear();
    }
}
// using UnityEngine;
// using TMPro;
// using System.Collections;
// using System.Collections.Generic;
//
// public class BookInteractionClosed : MonoBehaviour
// {
//     public GameObject pillarPrefab;
//     public RectTransform spawnPoint;
//     public float spacing = 200f;
//
//     private List<int> pillarNumbers = new List<int>();
//     private List<GameObject> instantiatedPillars = new List<GameObject>(); // Store instantiated pillars
//     private bool bookOpened = false;
//
//     void OnEnable()
//     {
//         BookInteraction.OnBookClosed += GenerateAndDisplayPillars;
//     }
//
//     void OnDisable()
//     {
//         BookInteraction.OnBookClosed -= GenerateAndDisplayPillars;
//     }
//
//     private void GenerateAndDisplayPillars()
//     {
//         StartCoroutine(WaitForPhiAndGenerateNumbers());
//     }
//
//     private IEnumerator WaitForPhiAndGenerateNumbers()
//     {
//         while (BookInteraction.CurrentPhi == 0)
//         {
//             Debug.Log("Waiting for phi to be calculated...");
//             yield return null;
//         }
//
//         GenerateUniqueNumbers();
//         SpawnPillars();
//     }
//
//     void GenerateUniqueNumbers()
//     {
//         pillarNumbers.Clear();
//         int phi = BookInteraction.CurrentPhi;
//         pillarNumbers.Add(phi);
//
//         while (pillarNumbers.Count < 3)
//         {
//             int num = Random.Range(1, 100);
//             if (!pillarNumbers.Contains(num) && num != phi)
//             {
//                 pillarNumbers.Add(num);
//             }
//         }
//     }
//
//     void SpawnPillars()
//     {
//         Vector3 centerPosition = spawnPoint.position;
//         for (int i = 0; i < 3; i++)
//         {
//             GameObject pillar = Instantiate(pillarPrefab, centerPosition + Vector3.right * (i - 1) * spacing,
//                 Quaternion.identity);
//             pillar.transform.SetParent(spawnPoint, false);
//             pillar.transform.localScale = Vector3.one;
//             instantiatedPillars.Add(pillar); // Add to list of instantiated pillars
//
//             TextMeshProUGUI textComponent = pillar.GetComponentInChildren<TextMeshProUGUI>();
//             if (textComponent != null)
//             {
//                 textComponent.text = pillarNumbers[i].ToString();
//             }
//         }
//     }
//
//     // Public method to deactivate all pillars
//     public void ClosePillars()
//     {
//         foreach (var pillar in instantiatedPillars)
//         {
//             if (pillar != null)
//                 Destroy(pillar); // Or pillar.SetActive(false) if you want to reuse them
//         }
//
//         instantiatedPillars.Clear(); // Clear the list
//     }
// }