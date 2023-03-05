using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Serialization;

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
    private bool _isFalling;


    private int _amountOfJumpsLeft;
    public int amountOfJumps = 1;
    private int _counter = 0;

    public float movementSpeed = 10.0f;
    public float jumpForce = 40.0f;
    public float fallMultiplier = 3.2f;
    public float lowJumpMultiplier = 5f;
    public float groundCheckRadius;
    public float movementForceInAir;
    public float airDragMultiplier;

    [SerializeField] private AudioSource standUpSoundEffect;
    [SerializeField] private AudioSource fallSoundEffect;
    [SerializeField] private AudioClip fallSound;
    [SerializeField] private AudioSource walkSoundEffectFirst;
    [SerializeField] private AudioClip walkSoundFirst;
    [SerializeField] private AudioSource walkSoundEffectSecond;
    [SerializeField] private AudioClip walkSoundSecond;

    public Transform groundCheck;

    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        _isFalling = false;
        _сheckGhostWakeUp = false;
        _counter = 0;
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _amountOfJumpsLeft = amountOfJumps;
    }

    // Update is called once per frame
    void Update()
    {
        CheckFalling();
        FreezePlayer();
        CheckGhostStatus();
        if (!GhostController.IsDisplayed)
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
        if (!GhostController.IsDisplayed)
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
        if (!ButtonControllerESC.IsPaused)
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
            standUpSoundEffect.Play();
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            _amountOfJumpsLeft--;
        }
        
    }

    void CheckGhostStatus()
    {
        
        if (GhostController.IsDisplayed)
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
    
    
    void CheckFalling()
    {
        if (_isGrounded)
        {
            _isFalling = false;
        }
        else if (!_isFalling)
        {
            // если персонаж не на земле и не падает, запускаем корутину, чтобы проверять падение
            StartCoroutine(CheckFall());
        }
    }
    
    private IEnumerator CheckFall()
    {
        _isFalling = true;
        float startHeight = transform.position.y;
        yield return new WaitForSeconds(0.3f);

        while (_isGrounded)
        {
            float currentHeight = transform.position.y;

            if (currentHeight < startHeight - 0.001f)
            {
                fallSoundEffect.PlayOneShot(fallSound);
                break;
            }
            yield return null;
        }
        _isFalling = false;
    }
    
    void PlayStepSoundFirst() {
        walkSoundEffectFirst.PlayOneShot(walkSoundFirst);
    }
    void PlayStepSoundSecond() {
        walkSoundEffectSecond.PlayOneShot(walkSoundSecond);
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
