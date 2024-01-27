using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopstickSpawner : MonoBehaviour
{
    public GameObject chopstickPrefab;
    public Transform playerTransform;
    public float spawnRadius = 5f; 
    public float spawnRate = 10f;
    public float timeOnGround = 10f;

    private void Start()
    {
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(6f); 
        StartCoroutine(SpawnChopsticks());
    }

    IEnumerator SpawnChopsticks()
    {
        while (true)
        {
            SpawnChopstick();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    void SpawnChopstick()
    {
        
        Vector3 randomPosition = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = playerTransform.position + new Vector3(randomPosition.x+3,  randomPosition.y + 10, 0f);

        
        GameObject chopstick = Instantiate(chopstickPrefab, spawnPosition, Quaternion.identity);

       
        ChopstickBehavior chopstickBehavior = chopstick.AddComponent<ChopstickBehavior>();
        chopstickBehavior.SetGroundTime(timeOnGround);

    }
}
