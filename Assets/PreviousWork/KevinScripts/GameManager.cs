using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float timeLimit = 30f;
    public float timer {get; private set;}
    private float totalTime;
    private bool isPaused = false;

    public TextMeshProUGUI timerText;
    public Button pauseButton;

    public GameObject endUI;

    public GameObject endSceneChopstickPrefab;
    private Transform playerTransform;
    
    public float endChopTimeOnGround = 5f;
    public float PlayerUpwardSpeed = 1f;

    private bool hasEndChopsticksSpawned = false;

    [SerializeField] private AudioSource chopstickTrapSound;
    [SerializeField] private AudioSource endChopstickTrapSound;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        timer = timeLimit;
        UpdateTimerText();
                
        pauseButton.onClick.AddListener(TogglePause);
        playerTransform = GameObject.FindWithTag("Player").transform;

        endUI.SetActive(false);

        
    }

    void Update()
    {
        if (!isPaused || GameStart.instance.gameStarted == false)
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
                totalTime += Time.deltaTime;
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
        timerText.text = "Time: " + Mathf.Clamp(Mathf.Ceil(timer), 0, int.MaxValue).ToString();
    }

    void TogglePause()
    {
        
        isPaused = !isPaused;

       
        Time.timeScale = isPaused ? 0f : 1f;
    }

    void LoseGame()
    {
        timerText.text = "Out Of Time";
        GameStart.instance.gameStarted = false;
        Invoke(nameof(ShowEndScreen), 1f);
    }

   
    public void WinGame()
    {
       
        //isPaused = true;

       
        Debug.Log("You Win!");
        timerText.text = "Win!";
       

        Invoke("NextLevel", 2f);
    }

    public void ShowEndScreen()
    {
        endUI.SetActive(true);
        GameObject.Find("SurviveTime").GetComponent<TextMeshProUGUI>().text = $"You survived {Mathf.CeilToInt(totalTime)} seconds";
        GameObject.Find("MusicLoop").GetComponent<AudioSource>().Stop();
        StartCoroutine(GameObject.Find("GameOverLine").GetComponent<GameOverLine>().PlayRandomLine());
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MenuScene");
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
        chopstickTrapSound.Play();
    }

    public void EndSceneChopsticks()
    {
        if (endSceneChopstickPrefab != null)
        {
            Vector3 spawnPosition = playerTransform.position + new Vector3(1f, 3f, 0f);
            GameObject endSceneChopstick = Instantiate(endSceneChopstickPrefab, spawnPosition, Quaternion.identity);
            endChopstickTrapSound.Play();

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
                    endSceneChopstick.transform.localPosition = new Vector3(0f, 2f, 0f);
                    endSceneChopstick.transform.rotation = Quaternion.Euler(0f, 0f, 45f); // Adjust the rotation angles as needed
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
