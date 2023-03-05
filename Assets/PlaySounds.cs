using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourcePlayer;

    private void Update()
    {
        PlayMenuSound();
    }

    void PlayMenuSound()
    {
        if (ButtonControllerESC.IsPaused)
        {
            if (!audioSourcePlayer.isPlaying)
            {
                audioSourcePlayer.Play();
            }
        }
        else
        {
            audioSourcePlayer.Stop();
        }
    }
}
