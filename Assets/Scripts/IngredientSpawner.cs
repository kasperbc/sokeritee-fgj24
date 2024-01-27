using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public GameObject[] spawnableIngredients;
    public Vector2 spawnArea;
    public float spawnTime;
    public float spawnTimeVariability;
    private float timeSinceLastSpawn;
    private float nextSpawnTime;
    void Start()
    {
        PickNewSpawnTime();
    }
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn > nextSpawnTime)
        {
            PickNewSpawnTime();
            SpawnIngredient();
        }
    }

    void PickNewSpawnTime()
    {
        timeSinceLastSpawn = 0;
        nextSpawnTime = spawnTime + Random.Range(spawnTimeVariability, -spawnTimeVariability);
    }

    void SpawnIngredient()
    {
        GameObject randomIngredient = spawnableIngredients[Random.Range(0, spawnableIngredients.Length - 1)];

        GameObject instantiatedIngr = Instantiate(randomIngredient);

        instantiatedIngr.transform.position = new Vector3(Random.Range(-spawnArea.x, spawnArea.x), transform.position.y, Random.Range(-spawnArea.y, spawnArea.y));
    }

    void OnDrawGizmos()
    {
        // draw spawn area as a rectangle
        Gizmos.color = new Color(1, 0.75f, 0, 0.25f);
        Gizmos.DrawCube(transform.position, new Vector3(spawnArea.x * 2, 1, spawnArea.y * 2));
    }
}
