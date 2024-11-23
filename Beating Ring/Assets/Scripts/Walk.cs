using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    [SerializeField]private float _moveSpeed = 5f;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb;
    private Vector2 _movement;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = _rb.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * _moveSpeed * Time.fixedDeltaTime);
        if(Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }

    
}
