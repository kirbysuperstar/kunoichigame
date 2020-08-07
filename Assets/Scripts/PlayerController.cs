﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootShuriken();
        }
    }

    public void MovePlayer()        //These four ifs handle the movement of the kunoichi based on which arrow key is pressed

    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentPos == "middle")
        {
            transform.position = new Vector3(-3.78f, topPos, 0);
            currentPos = "top";
            Debug.Log("Moving from middle to top.");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentPos == "bottom")
        {
            transform.position = new Vector3(-3.78f, middlePos, 0);
            currentPos = "middle";
            Debug.Log("Moving from bottom to middle.");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && currentPos == "middle")
        {
            transform.position = new Vector3(-3.78f, bottomPos, 0);
            currentPos = "bottom";
            Debug.Log("Moving from middle to bottom.");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && currentPos == "top")
        {
            transform.position = new Vector3(-3.78f, middlePos, 0);
            currentPos = "middle";
            Debug.Log("Moving from top to middle.");
        }
    }
    public void ShootShuriken() //The method of attack
    {
        if (currentPos == "top")
        {
            Debug.Log("Firing on top row.");
        }
        if (currentPos == "middle")
        {
            Debug.Log("Firing on middle row.");
        }
        if (currentPos == "bottom")
        {
            Debug.Log("Firing on bottom row.");
        }
    }
    public void UpButton()
    {
        if (currentPos == "middle")
        {
            transform.position = new Vector3(-3.78f, topPos, 0);
            currentPos = "top";
            Debug.Log("Moving from middle to top.");
        }
        if (currentPos == "bottom")
        {
            transform.position = new Vector3(-3.78f, middlePos, 0);
            currentPos = "middle";
            Debug.Log("Moving from bottom to middle.");
        }
        
        
    }
    public void DownButton()
    {
        if (currentPos == "middle")
        {
            transform.position = new Vector3(-3.78f, bottomPos, 0);
            currentPos = "bottom";
            Debug.Log("Moving from middle to bottom.");
        }
        if (currentPos == "top")
        {
            transform.position = new Vector3(-3.78f, middlePos, 0);
            currentPos = "middle";
            Debug.Log("Moving from top to middle.");
        }
    }

}
