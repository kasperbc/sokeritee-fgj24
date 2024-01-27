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
            //fallSource.Play();
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
}
