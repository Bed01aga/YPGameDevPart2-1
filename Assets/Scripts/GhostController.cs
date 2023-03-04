using Unity.VisualScripting;
using UnityEngine;

public class GhostController : MonoBehaviour
{

    
    public GameObject player;
    public GameObject ghost;
    public Cinemachine.CinemachineBrain cmBrain;
    public Cinemachine.CinemachineVirtualCamera playerCamera;
    public Cinemachine.CinemachineVirtualCamera ghostCamera;
    public float ghostSpeed;
    public static bool _isDisplayed;
    public Vector3 offset = new Vector2(2f,0f);
    
    private float _distancePlayerAndGhost;
    
    private Rigidbody2D _rb2d;


    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        // Hide the second character at the start of the game
        ghost.SetActive(false);
        _isDisplayed = false;
        cmBrain = FindObjectOfType<Cinemachine.CinemachineBrain>();
        SetDefaultCamera();
    }

    void Update()
    {
        if (!_isDisplayed)
        {
            FollowPlayer();
        }
        CheclDistance();
        SwapCamera();
        
    }
    
    void SwapCamera()
    {

        if (_distancePlayerAndGhost < 3f)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _isDisplayed = !_isDisplayed;
                ghost.SetActive(_isDisplayed);

                if (!_isDisplayed)
                {
                    playerCamera.Priority = 10;
                    ghostCamera.Priority = 0;
                }
                else
                {
                    playerCamera.Priority = 0;
                    ghostCamera.Priority = 10;
                }
                if (_isDisplayed)
                {
                    ghost.transform.position = player.transform.position + offset;
                }
            }
        }
    }
    
    void CheclDistance()
    {
        _distancePlayerAndGhost = Vector2.Distance(player.transform.position, ghost.transform.position);
    }
    
    void FollowPlayer()
    {
        ghost.transform.position = player.transform.position + offset;
    }
    
    public void SetDefaultCamera()
    {
        playerCamera.Priority=10;
        ghostCamera.Priority=0;
    }
}