using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Positions for Kunoichi Y
    public float topPos;
    public float middlePos;
    public float bottomPos;
    private string currentPos;

    // Start is called before the first frame update
    void Start()
    {
        currentPos = "middle";
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()        //These four ifs handle the movement of the kunoichi based on which arrow key is pressed

    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentPos == "middle")
        {
            transform.position = new Vector3(-7, topPos, 0);
            currentPos = "top";
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentPos == "bottom")
        {
            transform.position = new Vector3(-7, middlePos, 0);
            currentPos = "middle";
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && currentPos == "middle")
        {
            transform.position = new Vector3(-7, bottomPos, 0);
            currentPos = "bottom";
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && currentPos == "top")
        {
            transform.position = new Vector3(-7, middlePos, 0);
            currentPos = "middle";
        }
    }
}
