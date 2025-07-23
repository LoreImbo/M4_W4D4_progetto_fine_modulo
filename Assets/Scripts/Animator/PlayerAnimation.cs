using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private string _paramNameForward = "forward";
    [SerializeField] private float _paramRangeForward = 2;

    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");

        _anim.SetFloat(_paramNameForward, v * _paramRangeForward);
    }
}
