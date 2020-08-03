using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    // The enemy prefabs
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    // vector3 spawn positions for the enemies. Realistically only the y-axis changes, but having options is never bad.
    public Vector3 enemy1SpawnPos;
    public Vector3 enemy2SpawnPos;
    public Vector3 enemy3SpawnPos;

    // Default timer for adjusting the spawn rate and speed of enemies and a switch to turn it on or off
    public float countdownTimer = 90;
    public bool timerRunning = false;

    private string spawnSpeed = "slow";

    // Start is called before the first frame update
    void Start()
    {
        timerRunning = true;
        Debug.Log("Starting at slow speed.");
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
            }

            if (countdownTimer < 30)
            {
                Debug.Log("Second time threshold reached - increasding speed to fast.");
                spawnSpeed = "fast";
                timerRunning = false;
            }
        }
        //spawn enemies at intervals
    }

    void SpawnEnemy1()
    {
        Instantiate(enemy1, enemy1SpawnPos, enemy1.transform.rotation);
    }

    void SpawnEnemy2()
    {
        Instantiate(enemy2, enemy2SpawnPos, enemy2.transform.rotation);
    }

    void SpawnEnemy3()
    {
        Instantiate(enemy3, enemy3SpawnPos, enemy3.transform.rotation);
    }
}
