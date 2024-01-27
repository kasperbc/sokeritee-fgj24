using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerIncrease : MonoBehaviour
{
    public float timeIncrease = 5f;

    private void OnTriggerEnter(Collider collision)
    {
        string collidedObjectName = collision.gameObject.name;
        if (collision.gameObject.name == "Foot" || collidedObjectName == "Leg")
        {
            Debug.Log("Player touched Ingredient");

            GameManager gameManager = FindObjectOfType<GameManager>();

            if (gameManager != null)
            {

                gameManager.IncreaseTimer(timeIncrease);
            }
        }
    }
}

       