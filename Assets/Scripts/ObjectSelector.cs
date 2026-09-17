using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectSelector : MonoBehaviour
{
    public Transform cube;
    public Transform sphere;
    public Transform capsule;

    public float speed = 5f;

    private Transform currentSelected;
    private InputSystem_Actions controls;

    void Start()
    {
        SelectObject(cube);
    }

    void Update()
    {
        if (currentSelected != null)
        {
            Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();
            Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y);

            currentSelected.Translate(moveDir * speed * Time.deltaTime, Space.World);
        }
    }

    void Awake()
    {
        controls = new InputSystem_Actions();

        // події вибору об'єктів
        controls.Player.SelectCube.performed += ctx => SelectObject(cube);
        controls.Player.SelectSphere.performed += ctx => SelectObject(sphere);
        controls.Player.SelectCapsule.performed += ctx => SelectObject(capsule);
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void SelectObject(Transform obj)
    {
        currentSelected = obj;
    }

    void OnDrawGizmos()
    {
        if (currentSelected != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(currentSelected.position, Vector3.one * 2f);
        }
    }
}