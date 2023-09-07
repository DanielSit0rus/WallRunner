using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        speed = 6.0f; // set the initial speed to 3
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameOver == false) //only calls if the game is not over
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime); // make the background to scroll down
        }
            
    }
}
