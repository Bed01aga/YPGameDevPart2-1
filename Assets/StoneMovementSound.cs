using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMovementSound : MonoBehaviour
{
    public AudioSource audioSource;
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }
    
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Stop();
        }
    }
}
