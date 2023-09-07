using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreValueText;
    public TextMeshProUGUI gameOverText;
    private PlayerController player;
    public float scoreValue = 0f;
    public float pointPersecond = 1f;

    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>(); // get player object
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.gameOver == false)
        {
            scoreValueText.text = "Score: " + ((int)scoreValue).ToString(); // updates the score text
            scoreValue += pointPersecond * Time.fixedDeltaTime; // increase the score by every second the game runs
        }
        else
        {
            GameOver();
        }
        
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true); // show game over text
        restartButton.gameObject.SetActive(true); // show the restart button
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // reload the game
    }
}
