using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class AnimationGirl : MonoBehaviour
{
    private Animator _anim;
    private Rigidbody2D rb;
    [SerializeField]private float jumpForce = 10f;
    [SerializeField] private List<RuntimeAnimatorController> _controls = new List<RuntimeAnimatorController>();

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
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
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _anim.runtimeAnimatorController = _controls[3];
        }
        else if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            _anim.runtimeAnimatorController = _controls[4];
        }
    }
}
