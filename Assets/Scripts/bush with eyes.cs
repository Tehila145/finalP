using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushWithEyes : MonoBehaviour
{
    [SerializeField] private GameObject PopUp;
    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        PopUp.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange)
        {
            PopUp.SetActive(true);
        }
        else
        {
            PopUp.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "HeroKnight")
        {
            playerInRange = true;
        }
        //Destroy(transform.parent.gameObject); // Destroying the parent object (the prefab)



    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "HeroKnight")
        {
            playerInRange = false;
        }
    }

    public void ClosePopUp()
    {
        PopUp.SetActive(false);
    }
    public void DestroyBush()
    {
        Destroy(transform.parent.gameObject);
    }
}
