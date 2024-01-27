using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private bool isFinished = false;


    void Start()
    {
      
    }
    private void OnTriggerEnter(Collider collision)
    {
      
        if (collision.gameObject.name == "Player" && !isFinished)
        {
            Debug.Log("Player reached the checkpoint!");
           
            GameManager gameManager = FindObjectOfType<GameManager>();

            if (gameManager != null)
            {
                gameManager.WinGame();
            }
        }
    }
}
