using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDistanceForStone : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource audioSource;
    public Transform player;
    public float maxDistance = 40f;
    public float minDistance = 1f;
    public float volume = 1f;

    private int counter;
    private float distance;
    

    void Start()
    {
        counter = 0;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
        CheckStoneTrigger();
    }

    void CheckStoneTrigger()
    {
        if (Runa_Script_4_1.IsTriggered && counter == 0)
        {
            float volumeDistance = Mathf.Clamp(1f - (distance / maxDistance), 0f, 1f);
            audioSource.volume = volume * volumeDistance;
            StartCoroutine(WaitSeconds());
            counter++;
        }
    }
    
    IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(1.8f);

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(clip);
            
        }
    }
}
