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
            StartCoroutine(PlayRandomClip());
        }
    }

    IEnumerator PlayRandomClip()
    {
        yield return new WaitForSeconds(Random.Range(0, 2f));

        if (audioSource.isPlaying == true)
        {
            yield return null;
        }

        audioSource.clip = clips[Random.Range(0, clips.Length)];

        audioSource.Play();

    }
}
