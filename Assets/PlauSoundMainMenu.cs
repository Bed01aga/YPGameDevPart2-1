using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlauSoundMainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourcePlayer;

    private void Start()
    {
        audioSourcePlayer.Play();
    }

    private void OnDisable()
    {
        audioSourcePlayer.Stop();
    }

    
    
}
