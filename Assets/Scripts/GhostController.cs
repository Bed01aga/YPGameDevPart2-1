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
    
    
        

    void Start()
    {
        // Hide the second character at the start of the game
        ghost.SetActive(false);
        _isDisplayed = false;
        cmBrain = FindObjectOfType<Cinemachine.CinemachineBrain>();
        SetDefaultCamera();
    }

    void Update()
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
        

        // Toggle the display of the second character when F is pressed
        

        // Move the second character using the arrow keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(horizontal, vertical) * Time.deltaTime * ghostSpeed);

        
    }

    
    public void SetDefaultCamera()
    {
        playerCamera.Priority=10;
        ghostCamera.Priority=0;
    }
}