using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    // The enemy prefabs
    //public GameObject enemy1;
    //public GameObject enemy2;
    //public GameObject enemy3;

    public GameObject[] enemyPrefabs;

    // vector3 spawn positions for the enemies. Realistically only the y-axis changes, but having options is never bad.
    public Vector3 enemy1SpawnPos;
    public Vector3 enemy2SpawnPos;
    public Vector3 enemy3SpawnPos;

    // Default timer for adjusting the spawn rate and speed of enemies and a switch to turn it on or off
    public float countdownTimer = 90;
    public bool timerRunning = false;

    public static string spawnSpeed = "slow";

    private int spawnLine;
    // Minimum time between spawns
    public float spawnRate = 1.5f;
    // Maximum spawn time from minimum
    public float spawnRateVariance = 4f;

    // Start is called before the first frame update
    void Start()
    {
        timerRunning = true;
        Debug.Log("Starting at slow speed.");
        RandomSpawnrate();
    }

    // Update is called once per frame
    void Update()
    {
        //awful timer to adjust the spawn speed
        if (timerRunning)
        {
            if (countdownTimer > 0)
            {
                countdownTimer -= Time.deltaTime;
            }

            if (countdownTimer < 61 && countdownTimer > 30 && spawnSpeed == "slow")
            {
                Debug.Log("First time threshold reached - increasing speed to medium.");
                spawnSpeed = "medium";
                spawnRateVariance = 3f;
            }

            if (countdownTimer < 30)
            {
                Debug.Log("Second time threshold reached - increasing speed to fast.");
                spawnSpeed = "fast";
                timerRunning = false;
                spawnRateVariance = 2f;
            }
        }
        //spawn enemies at intervals
        //debug
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomEnemy();
        }
    }

    void SpawnRandomEnemy()
    {
        spawnLine = Random.Range(0, 3);
        Debug.Log("Spawnline is " + spawnLine);
        if (spawnLine == 0)
        {
            Vector3 spawnPos = enemy1SpawnPos;
            int enemyIndex = 0;
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        }
        if (spawnLine == 1)
        {
            Vector3 spawnPos = enemy2SpawnPos;
            int enemyIndex = 1;
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        }
        if (spawnLine == 2)
        {
            Vector3 spawnPos = enemy3SpawnPos;
            int enemyIndex = 2;
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        }
    }
    void RandomSpawnrate()
    {
        //Figure out a spawn time and tell debug
        float nextSpawnTime = Random.Range(spawnRate, spawnRate * spawnRateVariance);
        Debug.Log("Spawning in" + nextSpawnTime + "seconds.");
        //Invoke the spawner with that time
        Invoke("SpawnRandomEnemy", nextSpawnTime);
        //Begin again
        Invoke("RandomSpawnrate", nextSpawnTime);

    }
}
