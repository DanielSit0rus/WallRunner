using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    
    bool canmove = true;
    float targetX = 0;
    bool isMoving = false;
    public float speed;

    void Start()
    {
        speed = 30.0f; //speedfor the player object to move
    }

    void Update()
    {
        
        movePlayer();
        checkInputs();
    }

    void movePlayer()
    {
        Vector3 pos = gameObject.transform.position;

        if (isMoving)
        {
            // Move towards the target X position
            if (!Mathf.Approximately(pos.x, targetX)) // check if players current position is equal to target position. 
            {
                float newX = Mathf.MoveTowards(pos.x, targetX, speed * Time.deltaTime);// Calculates the next postion that moves from current positon to target position.
                gameObject.transform.position = new Vector3(newX, pos.y, pos.z);
            }
            else
            {
                isMoving = false;
                canmove = true;
            }
        }
    }

    void checkInputs()
    {

        if(!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && canmove) // left arrow will make target position to be x= - 10
            {
                targetX = -10f;
                canmove = false; // to ensure the player can't change direction mid transitioning to target position
                isMoving = true;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && canmove) // left arrow will make target position to be x= 10
            {
                targetX = 10f;
                canmove = false;
                isMoving = true;
            }
            
        }

        else
        {
            if (Input.GetKeyUp(KeyCode.UpArrow)) // will make the player stop moving and allows movement again. This will act as the mid-air dash
            {
                canmove = true;
                isMoving = false;
            }
        }

    }
}
