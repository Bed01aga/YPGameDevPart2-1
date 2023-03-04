using UnityEngine;

public class GhostController : MonoBehaviour
{
    public GameObject player;
    public GameObject ghost;
    public Cinemachine.CinemachineBrain cmBrain;
    public Cinemachine.CinemachineVirtualCamera playerCamera;
    public Cinemachine.CinemachineVirtualCamera ghostCamera;
    public float ghostSpeed;
    public static bool IsDisplayed;
    public Vector3 offset = new Vector2(2f,0f);
    
    public static float DistancePlayerAndGhost;
    
    private Rigidbody2D _rb2d;


    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        // Hide the second character at the start of the game
        ghost.SetActive(false);
        IsDisplayed = false;
        cmBrain = FindObjectOfType<Cinemachine.CinemachineBrain>();
        SetDefaultCamera();
    }

    void Update()
    {
        if (!IsDisplayed)
        {
            FollowPlayer();
        }
        CheclDistance();
        SwapCamera();
        
    }
    
    void SwapCamera()
    {

        if (DistancePlayerAndGhost < 3f && !ButtonControllerESC.IsPaused)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                IsDisplayed = !IsDisplayed;
                ghost.SetActive(IsDisplayed);

                if (!IsDisplayed)
                {
                    playerCamera.Priority = 10;
                    ghostCamera.Priority = 0;
                }
                else
                {
                    playerCamera.Priority = 0;
                    ghostCamera.Priority = 10;
                }
                if (IsDisplayed)
                {
                    ghost.transform.position = player.transform.position + offset;
                }
            }
        }
    }
    
    void CheclDistance()
    {
        DistancePlayerAndGhost = Vector2.Distance(player.transform.position, ghost.transform.position);
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