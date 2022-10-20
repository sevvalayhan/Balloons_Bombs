using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver = true;


    public float floatForce = 30;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound;


    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();


    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);

            gameOver = false;
            Debug.Log("Game Over!");

            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            playerAudio.PlayOneShot(bounceSound, 1.0f);
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }

    }

}
