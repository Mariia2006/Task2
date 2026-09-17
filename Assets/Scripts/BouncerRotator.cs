using UnityEngine;

public class BouncerRotator : MonoBehaviour
{
    private float rotationspeed;
    private float bounceSpeed;
    private Vector3 startPos;
    private float randomOffset;

    void Start()
    {
        startPos = transform.position;
        rotationspeed = Random.Range(30f, 100f);
        bounceSpeed = Random.Range(2f, 5f);
        randomOffset = Random.Range(0f, Mathf.PI * 2);
    }

    void Update()
    {
        transform.Rotate(Vector3.up * rotationspeed * Time.deltaTime);

        // стрибки за допомогою синусоїди
        float newY = startPos.y + Mathf.Sin(Time.time * bounceSpeed * randomOffset) * 2f;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
