using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunaScript : MonoBehaviour
{
    public GameObject[] needToCreate;
    public GameObject[] needToDestroy;
    public MoveElevator moveElevator;
    public GameObject player;
    private PlayerController playerController;
    // Start is called before the first frame update

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();    
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ghost") && Input.GetKeyDown(KeyCode.E))
        {
            if (needToCreate != null)
            {
                foreach (var item in needToCreate)
                {
                    item.gameObject.SetActive(true);
                }
            }
            if (needToDestroy != null)
            {
                foreach (var item in needToDestroy)
                {
                    item.gameObject.SetActive(false);
                }
            }
            if (moveElevator != null)
            { 
                moveElevator.Do();
            }

            Debug.Log(playerController.GetTriggered());
            if (playerController.GetTriggered())
            {
                Debug.Log(124124);
                player.transform.position = new Vector2(42.6f, 38.4f);
            }
        }
    }
    
}
