using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    public static bool PlayerOnPlatform;
    private void Start()
    {
        PlayerOnPlatform = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            PlayerOnPlatform = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            PlayerOnPlatform = false;
        }
    }
}
