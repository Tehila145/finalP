using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusCamera : MonoBehaviour
{
    public Transform target; // ������ ������� ���� ���� �� ������
    public float smoothSpeed = 0.125f;
    public GameObject SceneSwitcher;

    void Start()
    {
        Focus();
    }
    void Focus()
    {
        SceneSwitcher func = SceneSwitcher.GetComponent<SceneSwitcher>();
        transform.position = Vector3.Lerp(transform.position, target.position, smoothSpeed * Time.deltaTime);
    }
}
