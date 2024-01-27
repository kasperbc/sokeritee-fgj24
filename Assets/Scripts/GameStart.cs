using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(StartGame), 6);
    }

    void StartGame()
    {
        GameObject.FindWithTag("Player").GetComponent<Rigidbody>().isKinematic = false;
    }
}
