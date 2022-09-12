/*
 Devun Schneider
 Challenge 2
 Controls the spacebar cooldown & spawns dog objects
 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public HealthSystem healthSystem;
    public bool isCoolDown = false;

    // Start is called before the first frame update
    void Start()
    {
        healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
    }
    // Update is called once per frame
    void Update()
    {
        
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && !healthSystem.gameOver && !isCoolDown)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

            if (isCoolDown == false)
            {
                Invoke("ResetCooldown", 2f);
                isCoolDown = true;
            }
        }
    }
    void RestDownTime()
    {
        isCoolDown = true;
      
        
    }

}
