using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstaclePrefabs; // array to store the obstacles
    public GameObject powerupPrefab;
    float spawnRangeX = 10;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObstacles", 2, 1.5f); // repeats every 2 seconds
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPowerup();
    }
    Vector3 GenerateSpawnPosition ()
    {
        float xPos = Random.Range(-spawnRangeX+1, spawnRangeX-1);
        float yPos = 6;

    return new Vector3(xPos, yPos, 0); // generate random x and y position
    }

    void SpawnRandomObstacles()
    {
        float[] xPositions = new float[2] { -spawnRangeX, spawnRangeX }; // possible x positions for the objects
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length); 
        int positionIndex = Random.Range(0, xPositions.Length);
        Vector3 spawnPos = new Vector3(xPositions[positionIndex], 6, 0); // initial spawn position

        Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation); // spawning the obstacles
    }

    void SpawnPowerup()
    {
        if(GameObject.FindGameObjectsWithTag("Powerup").Length == 0)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); // spawning the power up
        }
    }
}
