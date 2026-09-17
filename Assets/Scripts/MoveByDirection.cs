using UnityEngine;

public class MoveByDirection : MonoBehaviour
{
    public Vector3 direction = new Vector3 (1, 0, 1);
    public float speed = 5f;
    void Start()
    {
        
    }

    void Update()
    {
        // нормалізація -> довжина буде 1
        Vector3 normalizedDirection = direction.normalized;
        // зміщення для кадру
        Vector3 step = normalizedDirection * speed * Time.deltaTime;
        transform.position += step;
    }
}
