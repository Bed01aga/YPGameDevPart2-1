using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _movementInputDirection;

    private Rigidbody2D _rb;
    private Animator _anim;

    private bool _isFacingRight = true;
    private bool _running;
    private bool _isGrounded;
    private bool _isTouchingWall;
    private bool _isWallSliding;
    private bool _canJump;

    private int _amountOfJumpsLeft;

    public int amountOfJumps = 1;

    public float movementSpeed = 10.0f;
    public float jumpForce = 40.0f;
    public float groundCheckRadius;
    public float wallCheckDistance;
    public float wallSlideSpeed;
    public float movementForceInAir;
    public float airDragMultiplier;

    public Transform groundCheck;
    public Transform wallCheck;

    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _amountOfJumpsLeft = amountOfJumps;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckMovementDirection();
        UpdateAnimations();
        CheckIfCanJump();
        CheckIfWallSliding();
    }

    private void FixedUpdate()
    {
        ApplyMovenent();
        CheckSurroundings();
    }

    private void CheckIfWallSliding()
    {
        if (_isTouchingWall && !_isGrounded && _rb.velocity.y < 0)
        {
            _isWallSliding = true;
        }
        else
        {
            _isWallSliding=false;
        }
    }

    private void CheckSurroundings()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        _isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);
    }
    private void CheckIfCanJump()
    {
        if (_isGrounded && _rb.velocity.y <= 0.01f)
        {
            _amountOfJumpsLeft = amountOfJumps;
        }

        if(_amountOfJumpsLeft > 0)
        {
            _canJump = true;
        }
        else
        {
            _canJump = false;
        }
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

        if ((_rb.velocity.x > 0.1) || (_rb.velocity.x < -0.1))
        {
            _running = true;
        }
        else
        {
            _running = false;
        }
        
    }

    private void UpdateAnimations()
    {
        _anim.SetBool("Running", _running);
        _anim.SetBool("Grounded", _isGrounded);
        _anim.SetFloat("AirSpeedY", _rb.velocity.y);
        _anim.SetBool("WallSlide", _isWallSliding);
    }

    private void Flip()
    {
        if (!_isWallSliding)
        {
            _isFacingRight = !_isFacingRight;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }
    }

    private void CheckInput()
    {
        _movementInputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void ApplyMovenent()
    {
        if (_isGrounded)
        {
            _rb.velocity = new Vector2(movementSpeed * _movementInputDirection, _rb.velocity.y);
        }
        else if (!_isGrounded && !_isWallSliding && _movementInputDirection != 0)
        {
            Vector2 forceToAdd = new Vector2(movementForceInAir * _movementInputDirection, 0);
            _rb.AddForce(forceToAdd);

            if (Mathf.Abs(_rb.velocity.x) > movementSpeed)
            {
                _rb.velocity = new Vector2(movementSpeed * _movementInputDirection, _rb.velocity.y);
            }
        }
        else if (!_isGrounded && !_isWallSliding && _movementInputDirection == 0)
        {
            _rb.velocity = new Vector2(_rb.velocity.x * airDragMultiplier, _rb.velocity.y);
        }

        if (_isWallSliding)
        {
            if (_rb.velocity.y < -wallSlideSpeed)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, -wallSlideSpeed);
            }
        }
    }

    private void Jump()
    {
        if (_canJump)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            _amountOfJumpsLeft--;
            _anim.SetTrigger("Jump");
        }
        
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);

        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
    }
}
