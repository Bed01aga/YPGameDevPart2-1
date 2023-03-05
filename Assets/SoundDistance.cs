using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDistance : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource audioSource;
    public Transform player;
    public float maxDistance = 30f;
    public float minDistance = 1f;
    public float volume = 1f;

    
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > maxDistance || distance < minDistance)
        {
            audioSource.Stop();
        }
        else
        {
            float volumeDistance = Mathf.Clamp(1f - (distance / maxDistance), 0f, 1f);
            audioSource.volume = volume * volumeDistance;
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(clip);
            }
        }
    }
}
