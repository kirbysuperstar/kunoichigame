using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 3;
    private PlayerController playerControllerScript;
    private float leftBound = -4;


    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Set the speed based on the spawn speed
        if (SpawnHandler.spawnSpeed == "slow")
        {
            speed = 3;
        }
        if (SpawnHandler.spawnSpeed == "medium")
        {
            speed = 4.5f;
        }
        if (SpawnHandler.spawnSpeed == "fast")
        {
            speed = 6;
        }
        //Move left if the game isn't over
        if (playerControllerScript.isGameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        //if an enemy hits the goal, destroy it and subtract a life
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacles"))
        {
            Destroy(gameObject);
            LivesHandler.livesValue -= 1;
        }
    }
}
