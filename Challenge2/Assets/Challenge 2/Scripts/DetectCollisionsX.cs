/*
 Devun Schneider
 Challenge 2
 Checks if Dog objects collide with ball objects, if true then adds 1 to score and destroys objects
 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollisionsX : MonoBehaviour
{
    
    private DisplayScore displayScoreScript;

    public int scoreTrack = 0;


    private void Start()
    {
        displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dog"))
        {
            
            displayScoreScript.score++;
            Destroy(other.gameObject);
            Destroy(gameObject);
           
        }
       
       
        
    }

}
