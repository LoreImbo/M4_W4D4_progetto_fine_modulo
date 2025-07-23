using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControllerCameraRelative : MonoBehaviour
{
    [SerializeField] private GroundCheck _groundCheck;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _initialSpeed = 3;
    private Animator _animator;

    private bool _canDoubleJump = false;
    public float _speed = 5f;
    public Transform cameraTransform;  // La Main Camera

    private Rigidbody rb;
    private Vector3 moveDirection;
    public float CurrentSpeed { get; private set; }
    private bool wasJumping = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Evita che si ribalti
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
            Debug.Log("Tasto Jump premuto");
            if (_groundCheck.IsGrounded)
            {
                // Primo salto
                Debug.Log("Primo salto");
                rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                //_animator.SetTrigger("JumpTrigger");
                //_animator.SetBool("IsJumping", true);
                _animator.Play("JumpShort", 0);
                wasJumping = true;
                //
            }
            else if (_canDoubleJump)
            {
                // Doppio salto
                rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                //_animator.SetTrigger("JumpTrigger");
                _animator.Play("JumpShort1", 0);
                //_animator.SetBool("IsJumping", true);
                wasJumping = true;
                _canDoubleJump = false;
            }
        }

        _animator.SetBool("IsGrounded", _groundCheck.IsGrounded);

        // Reset salto quando tocchi terra
        if (_groundCheck.IsGrounded && wasJumping)
        {
            wasJumping = false;
            _animator.SetBool("IsJumping", false);
        }

        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.LeftShift)) // Click sinistro del mouse
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
        if (moveDirection != Vector3.zero)
        {
            rb.MovePosition(rb.position + moveDirection * _speed * Time.fixedDeltaTime);
        }
    }
}

