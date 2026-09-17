using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastShooter : MonoBehaviour
{
    public Camera mainCamera;
    public float range = 100f;
    public float sphereRadius = 1.5f;

    // змінні для малювання влучань
    private Vector3 lastHitPoint;
    private bool hitSomething = false;

    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            ShootRaycast();
        }

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            ShootSphereRaycast();
        }
    }

    void ShootRaycast()
    {
        // координати курсора
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            Debug.Log("Hit the :" + hit.collider.name);
            Debug.DrawLine(ray.origin, hit.point, Color.red, 8f);

            if (hit.collider.CompareTag("Wall"))
            {
                Debug.Log("Wall!");
            }
        }
    }

    void ShootSphereRaycast()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.SphereCast(ray.origin, sphereRadius, ray.direction, out hit, range))
        {
            Debug.Log("Hit the :" + hit.collider.name);
            Debug.DrawLine(ray.origin, hit.point, Color.blue, 2f);
        }

        lastHitPoint = hit.point;
        hitSomething = true;
    }

    private void OnDrawGizmos()
    {
        if (hitSomething)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(lastHitPoint, sphereRadius);
        }
    }
}
