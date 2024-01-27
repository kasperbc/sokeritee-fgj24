using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource introSource;
    private AudioSource loopSource;
    void Start()
    {
        introSource = GetComponent<AudioSource>();
        loopSource = transform.GetChild(0).GetComponent<AudioSource>();
        loopSource.PlayDelayed(introSource.clip.length);
    }
}
