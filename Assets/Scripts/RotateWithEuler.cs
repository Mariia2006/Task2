using UnityEngine;

public class RotateWithEuler : MonoBehaviour
{
    public float rpm = 60f;
    void Start()
    {
        
    }

    void Update()
    {
        // 360/60 = 6 degrees per second
        float degreesPerSecond = rpm * 6f;
        // Time.deltaTime - незалежне від FPS
        Vector3 rotationStep = new Vector3(0, degreesPerSecond * Time.deltaTime, 0);
        transform.eulerAngles += rotationStep;
    }
}
