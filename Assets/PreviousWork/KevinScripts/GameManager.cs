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
            
            if (timer <= 0f)
            {
                LoseGame();
            }
            else
            {
               
                timer -= Time.deltaTime;
                UpdateTimerText();
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
        Invoke("RestartLevel", 2f);
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

}
