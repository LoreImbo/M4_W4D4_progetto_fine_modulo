using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private PlayerControllerCameraRelative _movement;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _movement = GetComponent<PlayerControllerCameraRelative>();
    }

    void Update()
    {
        _anim.SetFloat("speed", _movement.CurrentSpeed);
    }
}
