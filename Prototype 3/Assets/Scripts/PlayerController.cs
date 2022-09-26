/*
 Devun Schneider
 Prototype 3

 Controls player movement, visual and audio effects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    


    private Rigidbody rb;
    public float jumpForce;
    public ForceMode jumpForceMode;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;

    public Animator playerAnimator;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        //animation reference
        playerAnimator = GetComponent<Animator>();
        //set rigid body reference
        rb = GetComponent<Rigidbody>();

        

        playerAudio = GetComponent<AudioSource>();
        //start running animation
        playerAnimator.SetFloat("Speed_f", 1.0f);

        jumpForceMode = ForceMode.Impulse;
        //modify gravity
        //Physics.gravity *= gravityModifier;
        if(Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //press space key to jump
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, jumpForceMode);
            isOnGround = false;
            //jump animation
            playerAnimator.SetTrigger("Jump_trig");
            
            //stop dirt particle
            dirtParticle.Stop();
            //play jump sound
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            
            Debug.Log("Game Over");
            gameOver = true;

            //play death sound
            playerAudio.PlayOneShot(crashSound, 1.0f);
            //Play death animation
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            //explosion animation
            explosionParticle.Play();
        }
    }
}
