using UnityEngine;

public class GhostController : MonoBehaviour
{
    public GameObject player;
    public GameObject ghost;
    public Cinemachine.CinemachineBrain cmBrain;
    public Cinemachine.CinemachineVirtualCamera playerCamera;
    public Cinemachine.CinemachineVirtualCamera ghostCamera;
    public float ghostSpeed;
    private bool _isDisplayed;
    public Vector3 offset = new Vector2(2f,0f);

    void Start()
    {
        // Hide the second character at the start of the game
        ghost.SetActive(false);
        _isDisplayed = false;
        cmBrain = FindObjectOfType<Cinemachine.CinemachineBrain>();
    }

    void Update()
    {
        // Toggle the display of the second character when F is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            _isDisplayed = !_isDisplayed;
            ghost.SetActive(_isDisplayed);
            player.SetActive(!_isDisplayed);

            if (player.activeSelf)
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

        // Move the second character using the arrow keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(horizontal, vertical) * Time.deltaTime * ghostSpeed);
    }
}