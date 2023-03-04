using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _movementInputDirection;

    private Rigidbody2D _rb;
    private Animator _anim;

    private bool _isFacingRight = true;
    private bool _running;
    private bool _isGrounded;
    private bool _canJump;
    private bool _isGhost;
    private bool _сheckGhostWakeUp;


    private int _amountOfJumpsLeft;
    public int amountOfJumps = 1;
    private int _counter;

    public float movementSpeed = 10.0f;
    public float jumpForce = 40.0f;
    public float fallMultiplier = 3.2f;
    public float lowJumpMultiplier = 5f;
    public float groundCheckRadius;
    public float wallCheckDistance;
    public float wallSlideSpeed;
    public float movementForceInAir;
    public float airDragMultiplier;
    
    

    public Transform groundCheck;

    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        _сheckGhostWakeUp = false;
        _counter = 0;
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _amountOfJumpsLeft = amountOfJumps;
    }

    // Update is called once per frame
    void Update()
    {
        FreezePlayer();
        CheckGhostStatus();
        if (!GhostController._isDisplayed)
        {
            CheckInput();
            CheckMovementDirection();
            UpdateAnimations();
            CheckIfCanJump();
            Fall();
        }
    }

    private void FixedUpdate()
    {
        if (!GhostController._isDisplayed)
        {
            ApplyMovenent();
            CheckSurroundings();
        }
    }

    private void CheckSurroundings()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

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
        _anim.SetBool("GhostWakeUp", _сheckGhostWakeUp);
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
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
            else if (!_isGrounded && _movementInputDirection != 0)
            {
                Vector2 forceToAdd = new Vector2(movementForceInAir * _movementInputDirection, 0);
                _rb.AddForce(forceToAdd);

                if (Mathf.Abs(_rb.velocity.x) > movementSpeed)
                {
                    _rb.velocity = new Vector2(movementSpeed * _movementInputDirection, _rb.velocity.y);
                }
            }
            else if (!_isGrounded && _movementInputDirection == 0)
            {
                _rb.velocity = new Vector2(_rb.velocity.x * airDragMultiplier, _rb.velocity.y);
            }

    }

    private void Jump()
    {
        if (_canJump)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            _amountOfJumpsLeft--;
        }
        
    }

    void CheckGhostStatus()
    {
        
        if (GhostController._isDisplayed)
        {
            _counter++;
            _isGhost = true;
            _anim.SetBool("GhostSwap", _isGhost);
        }
        else
        {
            _isGhost = false;
            if (_counter > 0 && !_isGhost)
            {
                _сheckGhostWakeUp = true;
                _anim.SetBool("GhostSwap", _isGhost);
                StartCoroutine(DelayMethod());

            }
        }
    }
    
    
    
    IEnumerator DelayMethod()
    {
        yield return new WaitForSeconds(1f);
        _сheckGhostWakeUp = false;
        _counter = 0;
    }
    
    
    
    void FreezePlayer()
    {
        if (_isGhost || _сheckGhostWakeUp)
        {
            _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            _rb.gravityScale = 2f;
        }
        else
        {
            _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        
    }
    



    private void Fall()
    {
        if (_rb.velocity.y < -0.1f)
        {
            _rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (_rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            _rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
