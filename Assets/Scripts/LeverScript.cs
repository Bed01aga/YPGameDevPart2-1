using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public bool leverState = false;
    private bool _isInRange;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isInRange = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _isInRange)
        {
            //TODO: Do Something
            leverState = !leverState;
        }
    }
}
