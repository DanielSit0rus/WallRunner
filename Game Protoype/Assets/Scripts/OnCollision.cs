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
        if (gameObject.CompareTag("Lethal") && other.gameObject.CompareTag("Player")) // lethal box
        {
            Debug.Log("Player collided with LethalBox. Player dies!");
            player.gameOver = true;
            PlaySoundAndDestroy(other.gameObject, deathSound);
        }
        if (gameObject.CompareTag("Box") && other.gameObject.CompareTag("Player")) // regular box
        {
            bool isDashActive = player.dashActive;
            if (isDashActive)
            {
                PlaySoundAndDestroy(gameObject, hitSound); // if player is dashing, the box will get destroyed
            }
            else
            {
                PlaySoundAndDestroy(other.gameObject, deathSound);
                player.gameOver = true;
            }

        }
        if (gameObject.CompareTag("Projectile") && other.gameObject.CompareTag("Player")) // when fireball hits player
        {
            Debug.Log("Projecile collisioned");
            PlaySoundAndDestroy(other.gameObject, deathSound);
            player.gameOver = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlaySoundAndDestroy(gameObject, hitSound);
    }

    private void PlaySoundAndDestroy(GameObject obj, AudioClip sound)
    {
        // Instantiate a new GameObject for playing the sound
        GameObject audioGameObject = new GameObject("AudioPlayer");

        // Add the AudioPlayer script to the new GameObject
        AudioPlayer audioPlayer = audioGameObject.AddComponent<AudioPlayer>();

        // Use the AudioPlayer script to play the sound
        audioPlayer.PlaySound(sound, 1.0f);

        // Destroy the original object (e.g., the player or obstacle)
        Destroy(obj);
    }

}
