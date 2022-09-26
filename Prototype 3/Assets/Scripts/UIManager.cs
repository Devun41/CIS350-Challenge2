/*
 Devun Schneider
 Prototype 3

 Updates the text on the screen
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    public PlayerController playerControllerScript;

    public bool won = false;
    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null)
        {
            scoreText = FindObjectOfType<Text>();
        }
        if (playerControllerScript == null)
        {
            playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        //update score text
        if (!playerControllerScript.gameOver)
        {
            scoreText.text = "Score: " + score;
        }
        //loss condition
        if(playerControllerScript.gameOver && !won)
        {
            scoreText.text = "You Lose!" + "\n" + "Press R to Try Again!";
        }
        //win condition
        if (score >= 10)
        {
            playerControllerScript.gameOver = true;
            won = true;
            //playerControllerScript.StopRunning();
            scoreText.text = "You Win! " + "\n" + "Press R to Play Again!";
        }
        //R to restart
        if(playerControllerScript.gameOver && Input.GetKeyDown(KeyCode.R)){
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
