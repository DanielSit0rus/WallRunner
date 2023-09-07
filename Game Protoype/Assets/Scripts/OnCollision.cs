using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{

    private PlayerController player;
    public AudioClip hitSound;
    public AudioClip deathSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>(); // get the player object
        playerAudio = GetComponent<AudioSource>();
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
            playerAudio.PlayOneShot(deathSound, 1.0f);
        }
        if (gameObject.CompareTag("Box")) // regular box
        {
            

            bool isDashActive = player.dashActive; 
            if (isDashActive)
            {
                playerAudio.PlayOneShot(hitSound, 1.0f);
                Destroy(gameObject); // if player is dashing, the box will get destroyed
            }
            else
            {
               
                playerAudio.PlayOneShot(deathSound, 1.0f);
                Destroy(other.gameObject); // if not, the player will die
                player.gameOver = true;
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        playerAudio.PlayOneShot(hitSound, 1.0f);
        Destroy(gameObject); // destroy the powerup
    }

}
