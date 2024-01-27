using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public static GameStart instance;

    public bool gameStarted;

    public float timeBeforeGameStart = 6f;
    public TextMeshProUGUI startTimer;
    public GameObject gameUI;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (!gameStarted)
        {
            gameUI.SetActive(false);
        }

        timeBeforeGameStart -= Time.deltaTime;
        startTimer.text = (Mathf.Ceil(timeBeforeGameStart * 10) / 10).ToString();

        if (timeBeforeGameStart < 0 && !gameStarted)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        gameStarted = true;
        GameObject.FindWithTag("Player").GetComponent<Rigidbody>().isKinematic = false;
        startTimer.gameObject.SetActive(false);
        gameUI.SetActive(true);
    }
}
