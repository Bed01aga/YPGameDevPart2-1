using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunaScript22 : MonoBehaviour
{
    private bool ghostState = false;
    public MoveElevator elevator;
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
            elevator.Do();
        }
    }
}
