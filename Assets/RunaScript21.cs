using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunaScript21 : MonoBehaviour
{
    private bool ghostState = false;
    public GameObject toDestroy;
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
            toDestroy.gameObject.SetActive(false);
        }
    }
}
