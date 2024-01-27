using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDecrease : MonoBehaviour
{
    public float timeDecrease = 5f;
    [SerializeField] private AudioSource chopstickTrapAudio;

   

    private void OnTriggerEnter(Collider collision)
    {
        string collidedObjectName = collision.gameObject.name;
        if (collision.gameObject.name == "Foot" || collidedObjectName == "Leg" || collidedObjectName == "Rice_ball")
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
