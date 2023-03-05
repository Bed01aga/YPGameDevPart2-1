using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GhostController : MonoBehaviour
{
    public AudioSource audioSource;

    public GameObject player;
    public GameObject ghost;
    public Cinemachine.CinemachineBrain cmBrain;
    public Cinemachine.CinemachineVirtualCamera playerCamera;
    public Cinemachine.CinemachineVirtualCamera ghostCamera;
    public static bool IsDisplayed;
    public Vector3 offset = new Vector2(2f, 0f);

    public static float DistancePlayerAndGhost;
    
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            ghost.SetActive(true);
            IsDisplayed = true;
            playerCamera.Priority = 0;
            ghostCamera.Priority = 10;
        }
        else
        {
            ghost.SetActive(false);
            IsDisplayed = false;
            cmBrain = FindObjectOfType<Cinemachine.CinemachineBrain>();
            SetDefaultCamera();
        }
        
    }

    void Update()
    {
        if (!IsDisplayed)
        {
            FollowPlayer();
        }

        if (KillPlayer.PlayerIsDead)
        {
            audioSource.Stop();
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
                    audioSource.Stop();
                }
                else
                {
                    playerCamera.Priority = 0;
                    ghostCamera.Priority = 10;
                    audioSource.Play();
                    
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