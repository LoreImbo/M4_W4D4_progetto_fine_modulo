using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _initialSpeed = 3;
    [SerializeField] private GroundCheck _groundCheck;
    [SerializeField] private float _jumpForce = 5f;
    private bool _canDoubleJump = false;
    private Rigidbody _rb;

    private float _speed;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }




    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0, v).normalized;

        if (direction.sqrMagnitude > 0.05f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
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
            }
            else if (_canDoubleJump)
            {
                // Doppio salto
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _canDoubleJump = false;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = _initialSpeed;
            _speed *= 2;
        }
        else
        {
            _speed = _initialSpeed;
        }

        _rb.MovePosition(_rb.position + direction * (_speed * Time.deltaTime));
    }
}
