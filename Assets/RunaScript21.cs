using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RunaScript21 : MonoBehaviour
{
    private bool ghostState = false;
    public GameObject toDestroy;

    public static bool IsTriggered;

    private void Start()
    {
        IsTriggered = false;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ghost")
        {
            ghostState = true;
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Ghost")
        {
            ghostState = false;
        }
    }
    public void Update()
    {
        if (ghostState && Input.GetKeyDown(KeyCode.E))
        {
            IsTriggered = true;
            StartCoroutine(WaitSeconds());
        }
    }
    
    IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(3f);

        toDestroy.gameObject.SetActive(false);
    }
}
