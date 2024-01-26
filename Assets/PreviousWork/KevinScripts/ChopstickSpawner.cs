using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopstickSpawner : MonoBehaviour
{
    public GameObject chopstickPrefab;
    public Transform playerTransform;
    public float spawnRadius = 5f; 
    public float spawnRate = 10f;
    public float timeOnGround = 5f;

    private void Start()
    {
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
        // Calculate a random position within the specified radius 
        Vector3 randomPosition = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = playerTransform.position + new Vector3(randomPosition.x,  randomPosition.y, 0f);

        
        GameObject chopstick = Instantiate(chopstickPrefab, spawnPosition, Quaternion.identity);

        // Attach the behavior script and set the ground time
        ChopstickBehavior chopstickBehavior = chopstick.AddComponent<ChopstickBehavior>();
        chopstickBehavior.SetGroundTime(timeOnGround);
    }
}
