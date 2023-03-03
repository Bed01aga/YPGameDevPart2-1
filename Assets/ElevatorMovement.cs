using System;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    private bool _move;
    private float _speed = 2f;
    
    
    private bool _playerOnPlatform;

    private void Start()
    {
        _playerOnPlatform = false;
    }

    private void FixedUpdate()
    {
        if (_playerOnPlatform)
        {
            ElevatorMoving();
        }

    }
    
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            _playerOnPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            _playerOnPlatform = false;
        }
    }

    private void ElevatorMoving()
    {
        if(transform.position.y > 3.5f)
        {
            _move = false;
        }
        if(transform.position.y < -3.5f)
        {
            _move = true;
        }

        if (_move)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + _speed * Time.deltaTime);
        }

        if (!_move)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - _speed * Time.deltaTime);
        }
    }
}
