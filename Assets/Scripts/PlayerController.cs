using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private GameManager gameManager;
    private float jumpForce = 1300;
    private float gravityModifier = 5;
    public bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        // Get the component of the player object.
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        // Gives the player a perfect jump.
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Makes the player jump and run the animations, sound and effect.
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && gameManager.active == true)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            isOnGround = false;
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Player is running.
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }

        // Player collides to the obstacle.
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            explosionParticle.Play();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            Debug.Log("Game Over!");
            gameManager.GameOver();
        }
    }
}
