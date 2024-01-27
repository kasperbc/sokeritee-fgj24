using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDecrease : MonoBehaviour
{
    public float timeDecrease = 5f;
    [SerializeField] private AudioSource chopstickTrapAudio;

   

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Player touched Chopstick");

            GameManager gameManager = FindObjectOfType<GameManager>();

            if (gameManager != null)
            {

                gameManager.DecreaseTimer(timeDecrease);
               // chopstickTrapAudio.Play();
            }
        }
    }
}
