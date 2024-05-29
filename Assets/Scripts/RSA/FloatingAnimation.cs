using UnityEngine;

public class FloatingAnimation : MonoBehaviour
{
    public float amplitude = 0.5f;    // Set the amplitude of the float
    public float frequency = 1f;      // Set the frequency of the float

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Floating animation using a sine wave for smooth vertical movement
        float tempPosY = startPos.y + amplitude * Mathf.Sin(frequency * Time.time);
        transform.position = new Vector3(startPos.x, tempPosY, startPos.z);
    }
}