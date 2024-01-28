using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollider : MonoBehaviour
{
    public AudioClip[] clips;

    public AudioSource voiceSource;
    public AudioSource fallSource;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            StartCoroutine(PlayRandomClip());
            PlayRandomFallSound();
            PlayParticle();
        }
    }

    IEnumerator PlayRandomClip()
    {
        yield return new WaitForSeconds(Random.Range(0, 2f));

        if (voiceSource.isPlaying == true || GameStart.instance.gameStarted == false)
        {
            yield break;
        }

        voiceSource.clip = clips[Random.Range(0, clips.Length)];

        voiceSource.Play();

    }

    void PlayRandomFallSound()
    {
        fallSource.pitch = Random.Range(0.9f, 1.1f);

        fallSource.Play();
    }

    void PlayParticle()
    {
        ParticleSystem system = GetComponent<ParticleSystem>();
        if (system != null)
        {
            system.Play();
        }
    }
}
