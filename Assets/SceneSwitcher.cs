using System.Collections;
using UnityEngine;
public class SceneSwitcher : MonoBehaviour
{
    private float timeToWait = 25.0f; // ��� ������ ���� ����� ��������

    void Update()
    {
        // ����� ��� ������ ��� �����
        timeToWait -= Time.deltaTime;

        // ����� �� ��� ��� ������
        if (timeToWait <= 0.0f)
        {
            // ����� ��������
            Destroy(gameObject);
        }
    }
}
