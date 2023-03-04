using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    private bool _move;
    private float _speed = 2f;
    

    private void FixedUpdate()
    {
        if (ElevatorTrigger.PlayerOnPlatform)
        {
            ElevatorMoving();
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
