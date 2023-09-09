using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour

    
{
    private float yBound = -7.0f;
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>(); // get the PlayerController script
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Player"))
        {
            if (transform.position.y < yBound) // destroy player when it falls down the map
            {
                player.gameOver = true;
                Destroy(gameObject);

            }
        }
        else
        {
            if (transform.position.y < yBound)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
