using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundsDead : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourcePlayerDead;
    
    private int counter;

    private void Start()
    {
        counter = 0;
    }

    private void Update()
    {
        if (counter == 0)
        {
            PlayMenuSound();
        }
    }

    void PlayMenuSound()
    {
        if (KillPlayer.PlayerIsDead)
        {
            if (!audioSourcePlayerDead.isPlaying)
            {
                audioSourcePlayerDead.Play();
                counter++;
            }
        }
        else
        {
            audioSourcePlayerDead.Stop();
        }
    }
}
