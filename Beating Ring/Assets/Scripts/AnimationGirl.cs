using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class AnimationGirl : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] private List<RuntimeAnimatorController> _controls = new List<RuntimeAnimatorController>();

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.anyKey == false)
        {
            _anim.runtimeAnimatorController = _controls[0];
        }
        else if (Input.GetKey(KeyCode.E))
        {
            _anim.runtimeAnimatorController = _controls[2];
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            _anim.runtimeAnimatorController = _controls[1];
        }
    }
}
