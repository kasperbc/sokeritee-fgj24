using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChopstickSpawner : MonoBehaviour
{
    public GameObject chopstickPrefab;
    public float spawnRadius = 5f;
    public float spawnRate = 5f;
    public float timeOnGround = 10f;

    private void Start()
    {
        Invoke(nameof(StartChopstickSpawning), 10f);
    }

    void StartChopstickSpawning()
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
        Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-spawnRadius, spawnRadius), transform.position.y, Random.Range(-spawnRadius, spawnRadius));
        
        GameObject chopstick = Instantiate(chopstickPrefab, spawnPosition, Quaternion.identity);

        ChopstickBehavior chopstickBehavior = chopstick.AddComponent<ChopstickBehavior>();
        chopstickBehavior.SetGroundTime(timeOnGround);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0, 0, 0.25f);
        Gizmos.DrawCube(transform.position, new Vector3(spawnRadius * 2, 1f, spawnRadius * 2));
    }
}
