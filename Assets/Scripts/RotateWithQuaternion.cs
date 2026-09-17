using UnityEngine;

public class RotateWithQuaternion : MonoBehaviour
{
    public float rpm = 60f;
    void Start()
    {
        
    }

    void Update()
    {
        float degreesPerSecond = rpm * 6f;
        // Quaternion.Euler - градуси -> кватерніон
        Quaternion rotationThisFrame = Quaternion.Euler(0, degreesPerSecond * Time.deltaTime, 0);
        // множимо поточне обертання на нове
        transform.rotation *= rotationThisFrame;
    }
}
