using UnityEngine;

public class BouncyBall : MonoBehaviour
{
    public int bounceCount = 0;
    public float distanceToFloor = 0f;
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        bounceCount++;
        Debug.Log("Відскок: " + bounceCount);
    }
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            distanceToFloor = hit.distance - 0.5f;
            if (distanceToFloor < 0) distanceToFloor = 0;
        }
    }
}
