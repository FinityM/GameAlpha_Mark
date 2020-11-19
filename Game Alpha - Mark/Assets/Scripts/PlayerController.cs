using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    private float verticalInput;
    private float horizontalInput;
    private float xBound = 16;
    private float yBound = 11;
    public bool gameOver;

    private GameObject rudolphObject;
    private Rigidbody playerRB;
    private AudioSource playerAudio;
    public AudioClip goodiesSound;
    public AudioClip explosionSound;
    public ParticleSystem pickedItemParticle;
    public ParticleSystem explodeParticle;

    // Start is called before the first frame update
    void Start()
    {
        rudolphObject = GameObject.Find("Rudolph");
        playerRB = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        
    }

    // Method for movement
    void movement()
    {
        // Get the vertical input 
        verticalInput = Input.GetAxis("Vertical");

        //Get the horizontal input
        horizontalInput = Input.GetAxis("Horizontal");

        if (!gameOver)
        {
            // Move around the screen
            transform.position = transform.position + new Vector3(0, verticalInput * speed * Time.deltaTime, 0);
            transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);


            //Limit the x and y axis movement won't work will return to this later   
            if (transform.position.x > xBound)
            {
                transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
            }

            else if (transform.position.x < -xBound)
            {
                transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
            }

            if (transform.position.y > yBound)
            {
                transform.position = new Vector3(transform.position.x, yBound, transform.position.z);
            }

            else if (transform.position.y < -yBound)
            {
                transform.position = new Vector3(transform.position.x, -yBound, transform.position.z);
            }

        }
       

    }

    private void OnCollisionEnter(Collision other)
    {
        //Will make power up functional in beta will act like goodie for now
        if (other.gameObject.CompareTag("Powerup"))
        {
            playerAudio.PlayOneShot(goodiesSound, 1.0f); //Causing issues for me because it's using a default value of null which I have no clue why
            pickedItemParticle.Play();
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("Goodies"))
        {
            playerAudio.PlayOneShot(goodiesSound, 1.0f);
            pickedItemParticle.Play();
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("Obstacle"))
        {
            playerAudio.PlayOneShot(explosionSound, 1.0f);
            explodeParticle.Play();    
            gameOver = true;
            rudolphObject.SetActive(false);
            Debug.Log("Game Over");
            Destroy(other.gameObject);
        }
        
        else if (other.gameObject.CompareTag("Missile"))
        {
            playerAudio.PlayOneShot(explosionSound, 1.0f);
            explodeParticle.Play();      
            gameOver = true;
            rudolphObject.SetActive(false);
            Debug.Log("Game Over");
            Destroy(other.gameObject);
        }
    }
}
