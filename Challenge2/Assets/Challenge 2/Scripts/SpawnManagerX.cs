/*
 Devun Schneider
 Challenge 2
 Controls the spawning of balls
 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{

    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;


    private float spawnInterval = 5.0f;

    public HealthSystem healthSystem;
   
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
           // SpawnRandomBall();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //get a reference to the health system script
        healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
        
        StartCoroutine(SpawnRandomBallWithCoroutine());

    }
    IEnumerator SpawnRandomBallWithCoroutine()
    {
        yield return new WaitForSeconds(3f);
        while (!healthSystem.gameOver )
        {
            SpawnRandomBall();
            //spawn ball every 3-5 sec
            float randomDelay = Random.Range(3f, spawnInterval);
            
            yield return new WaitForSeconds(randomDelay);
        }
    }
    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        //pick a random spawn point
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        //generate spawn pos
        int prefabIndex = Random.Range(0, ballPrefabs.Length);
        //spawn
        Instantiate(ballPrefabs[prefabIndex], spawnPos, ballPrefabs[prefabIndex].transform.rotation);
    }

}
