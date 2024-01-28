using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallOffBehaviour : MonoBehaviour
{
    public Vector3 spawnPos;
    public float yPosTreshhold = -10f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < yPosTreshhold && GameStart.instance.gameStarted == true)
        {
            transform.position = spawnPos;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
