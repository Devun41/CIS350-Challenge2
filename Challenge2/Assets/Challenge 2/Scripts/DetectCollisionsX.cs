using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollisionsX : MonoBehaviour
{
    
    private DisplayScore displayScoreScript;

    public int scoreTrack = 0;
    public bool win = false;
    public Text winText;

    private void Start()
    {
        displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>();
        winText = GetComponent<Text>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dog"))
        {
            scoreTrack++;
            displayScoreScript.score++;
            Destroy(other.gameObject);
            Destroy(gameObject);
            if (scoreTrack >= 5)
            {
                win = true;
                
            }
        }
       
       
        
    }
    public void Update()
    {
        //Checks if you win, shows text, and allows restart
        if (win)
        {
            winText.text = "You Win! \nPress R to Restart!";
            if (Input.GetKeyDown(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
                winText.text = "";
            }
        }
    }
}
