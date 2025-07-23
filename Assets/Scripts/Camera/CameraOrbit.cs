using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector2 _mouseSensitivity = new Vector2(3f, 1.5f);
    [SerializeField] private float _distanceFromTarget = 5f;
    [SerializeField] private Vector2 _verticalPitchLimits = new Vector2(-20f, 80f);

    private float _yaw = 0f; // Angolo di rotazione orizzontale
    private float _pitch = 20f; // Angolo di rotazione verticale

    void LateUpdate()
    {
        if (_target == null) return;

        // Input del mouse
        _yaw += Input.GetAxis("Mouse X") * _mouseSensitivity.x;
        _pitch -= Input.GetAxis("Mouse Y") * _mouseSensitivity.y;
        _pitch = Mathf.Clamp(_pitch, _verticalPitchLimits.x, _verticalPitchLimits.y);

        // Calcola la rotazione
        Quaternion rotation = Quaternion.Euler(_pitch, _yaw, 0f);

        // Calcola la posizione della camera
        Vector3 offset = rotation * new Vector3(0f, 0f, -_distanceFromTarget);
        transform.position = _target.position + offset;

        // Ruota il rig verso il player
        transform.LookAt(_target);
    }
}

