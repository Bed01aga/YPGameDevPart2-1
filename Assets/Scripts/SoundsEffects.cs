using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundsEffects : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
        audioSource.Play();
        
    }
}
