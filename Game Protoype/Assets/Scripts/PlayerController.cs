using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private bool canmove = true;
    private bool isMoving = false;
    public bool dashActive = false;
    public bool slideActive = false;
    private bool resetGravity = true;
    public bool gameOver;

    private float targetX = 0;
    public float speed;
    public int dashDuration = 3;
    private new Renderer renderer;
    private Rigidbody2D rigidb;

    public AudioClip jumpSound;
    public AudioClip dashSound;
    private AudioSource playerAudio;

    void Start()
    {
        speed = 30.0f; //speedfor the player object to move
        renderer = GetComponent<Renderer>(); //get the renderer component of player
        playerAudio = GetComponent<AudioSource>();
        rigidb = gameObject.GetComponent<Rigidbody2D>();

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
    IEnumerator DashCooldown()
    {
        Debug.Log("Called");
        yield return new WaitForSeconds(dashDuration);
        dashActive = false;
        renderer.material.color =Color.white; // change the color back to white to indicate the players no longer dashing
    }

    IEnumerator AirDashCooldown()
    {
        Debug.Log("AirDashing");
        yield return new WaitForSeconds(dashDuration);
        dashActive = false;
        if (resetGravity)
        {
            rigidb.gravityScale = 1; // turn on gravity
        }
        renderer.material.color = Color.white; // change the color back to white to indicate the players no longer dashing
        /*float elasped = Time.deltaTime;
        if(elasped < dashDuration - 1)
        {
            StartCoroutine(ShakeObject(0.5f, 0.1f));
        }*/
    }

    void checkInputs()
    {

        if (!isMoving && (transform.position.x == -10f || transform.position.x == 10f))
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && canmove) // left arrow will make target position to be x= - 10
            {
                renderer.material.color = Color.white;
                playerAudio.PlayOneShot(jumpSound, 1.0f);
                targetX = -10f;
                canmove = false; // to ensure the player can't change direction mid transitioning to target position
                isMoving = true;
                
                
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && canmove) // left arrow will make target position to be x= 10
            {
                renderer.material.color = Color.white;
                playerAudio.PlayOneShot(jumpSound, 1.0f); // plays the jump sound effect
                targetX = 10f;
                canmove = false;
                isMoving = true;
                
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                playerAudio.PlayOneShot(dashSound, 1.0f); // plays the dash sound effect
                dashActive = true;
                Debug.Log("dash active!");
                renderer.material.color = Color.blue; // make player blue to indicate they are currently dashing
                StartCoroutine(DashCooldown()); // start the dashing count down for 3 seconds
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && !slideActive) // sliding when down arrow pressed
            {
                slideActive = true;
                renderer.material.color = Color.green;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow) && slideActive) // no longer sliding when down arrow is no longer pressed
            {
                slideActive = false;
                renderer.material.color = Color.white;  
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && canmove)
            {
                renderer.material.color = Color.white;
                resetGravity = false;
                rigidb.gravityScale = 0; // Reset the gravity scale to 0 when player moves left or right in mid-air
                playerAudio.PlayOneShot(jumpSound, 1.0f);
                targetX = -10f;
                canmove = false;
                isMoving = true;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && canmove)
            {
                renderer.material.color = Color.white;
                resetGravity = false;
                rigidb.gravityScale = 0; // Reset the gravity scale to 0 when player moves left or right in mid-air
                playerAudio.PlayOneShot(jumpSound, 1.0f);
                targetX = 10f;
                canmove = false;
                isMoving = true;
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow)) // will make the player stop moving and allows movement again. This will act as the mid-air dash
            {
                resetGravity = true;
                playerAudio.PlayOneShot(dashSound, 1.0f);
                canmove = true;
                isMoving = false;
                Debug.Log("Up pressed");
                renderer.material.color = Color.yellow; // indicate that player is currently dashing mid-air
                StartCoroutine(AirDashCooldown());
            }

        }
    }
    /*IEnumerator ShakeObject(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.position;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = UnityEngine.Random.Range(-1f, 1f) * magnitude;
            float y = UnityEngine.Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPosition;
    }*/
}
