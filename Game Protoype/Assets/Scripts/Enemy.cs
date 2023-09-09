using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject fireballPrefab;
    private PlayerController player;
    public AudioClip shootSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        playerAudio = GetComponent<AudioSource>();
        StartCoroutine(SpawnFireballEveryThreeSeconds());
    }

    IEnumerator SpawnFireballEveryThreeSeconds() 
    {
        while (true)
        {
            if(player.gameOver)
            {
                yield break; // stop if game is over
            }
            playerAudio.PlayOneShot(shootSound, 1.0f); // plays the shoot sound
            Instantiate(fireballPrefab, transform.position, fireballPrefab.transform.rotation); // create the fireball
            yield return new WaitForSeconds(3);
        }
    }
}
