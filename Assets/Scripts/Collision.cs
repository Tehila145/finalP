using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");
    } 
    void OnTruggerEnter2D(Collider2D collider)
    {
        Debug.Log("What was that?");
    }
}
