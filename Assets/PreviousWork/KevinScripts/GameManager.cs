using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float timeLimit = 30f;
    private float timer;
    private bool isPaused = false;

    public TextMeshProUGUI timerText;
    public Button pauseButton;

    public GameObject endSceneChopstickPrefab;
    public Transform playerTransform;
    
    public float endChopTimeOnGround = 5f;
    public float PlayerUpwardSpeed = 1f;

    private bool hasEndChopsticksSpawned = false;


    void Start()
    {
        timer = timeLimit;
        UpdateTimerText();

        
        pauseButton.onClick.AddListener(TogglePause);
    }

    void Update()
    {
        if (!isPaused)
        {
            if (timer <= 0f && !hasEndChopsticksSpawned)
            {
                EndSceneChopsticks();
                hasEndChopsticksSpawned = true; 

                Invoke("LoseGame", 2f);
            }
            else
            {
                timer -= Time.deltaTime;
                UpdateTimerText();
            }

            if (hasEndChopsticksSpawned)
            {
                playerTransform.Translate(Vector3.up * PlayerUpwardSpeed * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                timer = 0;
            }
        }
    }


    void UpdateTimerText()
    {
        
        timerText.text = "Time: " + Mathf.Ceil(timer).ToString();
    }

    void TogglePause()
    {
        
        isPaused = !isPaused;

       
        Time.timeScale = isPaused ? 0f : 1f;
    }

    void LoseGame()
    {
       timerText.text = "Out Of Time";
        Invoke("RestartLevel", 1f);
    }

   
    public void WinGame()
    {
       
        isPaused = true;

       
        Debug.Log("You Win!");
        timerText.text = "Win!";
       

        Invoke("NextLevel", 2f);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncreaseTimer(float amount)
    {
        timer += amount;
        UpdateTimerText();
    }

    public void DecreaseTimer(float amount)
    {
        timer -= amount;
        UpdateTimerText();
    }

    public void EndSceneChopsticks()
    {
        if (endSceneChopstickPrefab != null)
        {
            Vector3 spawnPosition = playerTransform.position + new Vector3(0f, 1f, 0f);
            GameObject endSceneChopstick = Instantiate(endSceneChopstickPrefab, spawnPosition, Quaternion.identity);

            if (endSceneChopstick != null)
            {
                ChopstickBehavior endChopstickBehavior = endSceneChopstick.GetComponent<ChopstickBehavior>();
                if (endChopstickBehavior != null)
                {
                    endChopstickBehavior.SetGroundTime(endChopTimeOnGround);

                    // Set the playerTransform for the endChopstickBehavior
                    endChopstickBehavior.SetPlayerTransform(playerTransform);

                    // Make the endChopstick a child of the player object
                    endSceneChopstick.transform.parent = playerTransform.gameObject.transform;

                    // Optionally, adjust the local position of the endChopstick
                    endSceneChopstick.transform.localPosition = new Vector3(0f, 1f, 0f);
                }
                else
                {
                    Debug.LogError("ChopstickBehavior component not found on endSceneChopstick.");
                }
            }
            else
            {
                Debug.LogError("endSceneChopstick instantiation failed.");
            }
        }
        else
        {
            Debug.LogError("endSceneChopstickPrefab is not assigned in the GameManager.");
        }
    }





}
