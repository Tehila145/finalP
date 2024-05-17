using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float walkSpeed = 1f;
    [SerializeField] float moveSpeed = 0.01f;
    void Start()
    {
       // transform.Rotate(0, 0, 0);
    }

    void Update()
    {
        float walkAmount = Input.GetAxis("Horizontal") * walkSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -walkAmount);
        transform.Translate(0, moveAmount, 0);

    }
}
