using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDecrease : MonoBehaviour
{
    public float timeDecrease = 5f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Car")
        {
            Debug.Log("Player touched Ingredient");

            GameManager gameManager = FindObjectOfType<GameManager>();

            if (gameManager != null)
            {

                gameManager.DecreaseTimer(timeDecrease);
            }
        }
    }
}
