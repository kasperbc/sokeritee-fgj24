using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverLine : MonoBehaviour
{
    public AudioClip[] clips;
    
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public IEnumerator PlayRandomLine()
    {
        source.clip = clips[Random.Range(0, clips.Length)];

        yield return new WaitForSeconds(2f);

        source.Play();
    }
}
