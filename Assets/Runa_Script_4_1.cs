using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Runa_Script_4_1 : MonoBehaviour
{
    public GameObject toDestroy;
    public GameObject player;
    public GameObject ghost;
    private bool ghostState;
    private PlayerController playerController;

    public static bool IsTriggered;

    public void Start()
    {
        IsTriggered = false;
        playerController = player.GetComponent<PlayerController>();
    }
    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ghost"))
        {
            ghostState = true;
        }
        
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ghost"))
        {
            ghostState = false;
        }
        
    }
    public void Update()
    {
        if (ghostState && Input.GetKeyDown(KeyCode.E))
        {
            toDestroy.gameObject.SetActive(false);
            IsTriggered = true;
            
            if (playerController.GetTriggered())
            {
                player.transform.position = new Vector2(28.0f, 36.8f);
            }
        }
    }
}
