using System.Collections;
using UnityEngine;
public class SceneSwitcher : MonoBehaviour
{
    private float timeToWait = 25.0f; // זמן ההמתנה לפני מחיקת האובייקט

    void Update()
    {
        // הפחתת זמן ההמתנה בכל פריים
        timeToWait -= Time.deltaTime;

        // בדיקה אם עבר זמן ההמתנה
        if (timeToWait <= 0.0f)
        {
            // מחיקת האובייקט
            Destroy(gameObject);
        }
    }
}
