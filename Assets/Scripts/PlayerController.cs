using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _movementInputDirection;
    private Rigidbody2D _rigidbody;
    private bool _isFacingRight = true;

    public float movementSpeed = 10.0f;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckMovementDirection();
    }

    private void FixedUpdate()
    {
        ApplyMovenent();
    }

    private void CheckMovementDirection()
    {
        if (_isFacingRight && _movementInputDirection < 0)
        {
            Flip();
        }
        else if (!_isFacingRight && _movementInputDirection > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void CheckInput()
    {
        _movementInputDirection = Input.GetAxisRaw("Horizontal");
    }

    private void ApplyMovenent()
    {
        _rigidbody.velocity = new Vector2(movementSpeed * _movementInputDirection, _rigidbody.velocity.y);
    }
}
