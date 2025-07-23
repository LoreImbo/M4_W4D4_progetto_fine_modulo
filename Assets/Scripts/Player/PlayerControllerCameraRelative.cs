using UnityEngine;

public class PlayerControllerCameraRelative : MonoBehaviour
{
    [SerializeField] private GroundCheck _groundCheck;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _initialSpeed = 3;
    [SerializeField] private Transform _cameraTransform;
    private Animator _animator;

    private bool _canDoubleJump = false;
    private float _speed = 5f;

    private Rigidbody _rb;
    private Vector3 _moveDirection;
    public float CurrentSpeed { get; private set; }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true; // Evita che si ribalti
        _animator = GetComponentInChildren<Animator>();
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
            Vector3 camForward = _cameraTransform.forward;
            Vector3 camRight = _cameraTransform.right;

            camForward.y = 0f;
            camRight.y = 0f;

            _moveDirection = (camForward * vertical + camRight * horizontal).normalized;

            // Rotazione verso il movimento
            Quaternion targetRotation = Quaternion.LookRotation(_moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
        else
        {
            _moveDirection = Vector3.zero;
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
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _animator.Play("JumpShort", 0);
            }
            else if (_canDoubleJump)
            {
                // Doppio salto
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _animator.Play("JumpShort1", 0);
                _canDoubleJump = false;
            }
        }

        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.LeftShift))
        {
            _speed = _initialSpeed * 2; // Raddoppia la velocità
        }
        else
        {
            _speed = _initialSpeed;
        }
        
        float inputAmount = new Vector2(horizontal, vertical).magnitude;
        CurrentSpeed = inputAmount * _speed;
    }

    void FixedUpdate()
    {
        if (_moveDirection != Vector3.zero)
        {
            _rb.MovePosition(_rb.position + _moveDirection * _speed * Time.fixedDeltaTime);
        }
    }
}

