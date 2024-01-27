using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollider : MonoBehaviour
{
    public AudioClip[] clips;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            PlayRandomClip();
        }
    }

    void PlayRandomClip()
    {
        audioSource.clip = clips[Random.Range(0, clips.Length)];

        audioSource.Play();
    }
}
