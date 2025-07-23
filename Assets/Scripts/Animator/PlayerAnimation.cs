using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private string _paramNameForward = "forward";
    [SerializeField] private float _paramRangeForward = 2;

    private Animator _anim;
    private PlayerControllerCameraRelative _movement;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _movement = GetComponent<PlayerControllerCameraRelative>();
    }

    // Update is called once per frame
    void Update()
    {
        //_anim.SetFloat(_paramNameForward, v * _paramRangeForward);
        _anim.SetFloat("speed", _movement.CurrentSpeed);
    }
}
