using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video : MonoBehaviour
{

    public GameObject objectToDestroy1;
    private float timeToWait = 25.0f; 

    void Update()
    {
        timeToWait -= Time.deltaTime;

        if (timeToWait <= 0.0f)
        {
            Destroy(objectToDestroy1);
        }
    }
}
