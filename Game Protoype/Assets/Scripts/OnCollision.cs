using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>(); // get the player object
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.CompareTag("Lethal")) // lethal box
        {
            Debug.Log("Player collided with LethalBox. Player dies!");
            Destroy(other.gameObject); // Destroy the player
            player.gameOver = true;
        }
        if (gameObject.CompareTag("Box")) // regular box
        {
            bool isDashActive = player.dashActive; 
            if (isDashActive)
            {
                Destroy(gameObject); // if player is dashing, the box will get destroyed
            }
            else
            {
                Destroy(other.gameObject); // if not, the player will die
                player.gameOver = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject); // destroy the powerup
    }

}
