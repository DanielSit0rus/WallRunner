using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{

    public float speed;
    private Vector3 StartPosition;
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
        speed = 3.0f; // set the initial speed to 3
        player = GameObject.Find("Player").GetComponent<PlayerController>(); // get the PlayerController script
    }

    // Update is called once per frame
    void Update()
    {
        if(player.gameOver == false) //only calls if the game is not over
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime); // make it scroll down


            if (gameObject.CompareTag("Wall"))
            {
                if (transform.position.y < -10)
                {
                    transform.position = StartPosition; // if the object is a wall, repeat it when the position of y < 10 
                }
            }
            else
            {
                if (transform.position.y < -25.39f)
                {
                    transform.position = StartPosition; // if it is not a wall (background), repeat it when y < -25.39
                }
            }
        }
        
        
        
    }
}
