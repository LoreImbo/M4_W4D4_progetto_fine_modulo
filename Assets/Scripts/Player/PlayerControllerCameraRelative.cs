using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementRigidbody : MonoBehaviour
{
    [SerializeField] private GroundCheck _groundCheck;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _initialSpeed = 3;

    private bool _canDoubleJump = false;
    public float _speed = 5f;
    public Transform cameraTransform;  // La Main Camera

    private Rigidbody rb;
    private Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Evita che si ribalti
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Direzione da input
        Vector3 inputDir = new Vector3(horizontal, 0f, vertical).normalized;

        if (inputDir.magnitude >= 0.1f)
        {
            // Camera-relative direction
            Vector3 camForward = cameraTransform.forward;
            Vector3 camRight = cameraTransform.right;

            camForward.y = 0f;
            camRight.y = 0f;

            moveDirection = (camForward * vertical + camRight * horizontal).normalized;

            // Rotazione verso il movimento
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
        else
        {
            moveDirection = Vector3.zero;
        }
        if (_groundCheck.IsGrounded)
        {
            _canDoubleJump = true;
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            if (_groundCheck.IsGrounded)
            {
                // Primo salto
                rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
            else if (_canDoubleJump)
            {
                // Doppio salto
                rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _canDoubleJump = false;
            }
        }

        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.LeftShift)) // Click sinistro del mouse
        {
            _speed = _initialSpeed * 2; // Raddoppia la velocità
        }
        else
        {
            _speed = _initialSpeed;
        }
    }

    void FixedUpdate()
    {
        if (moveDirection != Vector3.zero)
        {
            rb.MovePosition(rb.position + moveDirection * _speed * Time.fixedDeltaTime);
        }
    }
}

