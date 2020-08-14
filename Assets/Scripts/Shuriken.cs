using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public float speed;
    private float rightBound = 4.44f;
    public AudioClip shurikenHitNoise;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //as long as the game isn't over, move on off to the right
        if (playerControllerScript.isGameOver == false)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        //if a shuriken hits the right wall, destroy it
        if (transform.position.x > rightBound && gameObject.CompareTag("Projectiles"))
        {
            Destroy(gameObject);
            PlayerController.shotCount -= 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            AudioSource.PlayClipAtPoint(shurikenHitNoise, new Vector3(0, 0, 0), 2f);
            Debug.Log("Shuriken hit an enemy!");
            Destroy(gameObject);
            Destroy(collision.collider.gameObject);
            ScoreHandler.scoreValue += 1;
            PlayerController.shotCount -= 1;
        }
    }
}
