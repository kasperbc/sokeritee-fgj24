using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerIncrease : MonoBehaviour
{
    public float timeIncrease = 5f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Foot")
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

       