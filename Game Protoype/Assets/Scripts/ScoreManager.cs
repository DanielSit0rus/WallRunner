using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreValueText;
    private PlayerController player;
    public float scoreValue = 0f;
    public float pointPersecond = 1f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.gameOver == false)
        {
            scoreValueText.text = "Score: " + ((int)scoreValue).ToString(); // updates the score text
            scoreValue += pointPersecond * Time.fixedDeltaTime; // increase the score by every second the game runs
        }
        
    }
}
