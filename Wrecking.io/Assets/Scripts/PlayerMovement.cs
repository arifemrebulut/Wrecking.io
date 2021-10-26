using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float rotationSpeed;

    private Rigidbody rigidbody;
    private bool isGameStart = false;

    private void OnEnable()
    {
        EventManager.OnDragEvent += RotateWithDrag;
    }

    private void OnDisable()
    {
        EventManager.OnDragEvent -= RotateWithDrag;
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isGameStart && Input.GetMouseButtonDown(0))
        {
            isGameStart = true;
        }   
    }

    private void FixedUpdate()
    {
        if (isGameStart)
        {
            MoveForward();
        }
    }

    private void MoveForward()
    {
        rigidbody.velocity = transform.forward * (forwardSpeed * Time.fixedDeltaTime);
    }

    private void RotateWithDrag(float xDelta)
    {
        transform.Rotate(Vector3.up * xDelta * ((rotationSpeed * Time.deltaTime)));
    }
}
