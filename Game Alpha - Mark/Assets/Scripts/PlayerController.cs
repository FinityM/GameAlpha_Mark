using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    private float verticalInput;
    private float horizontalInput;
    private float xBound = 16;
    private float yBound = 13;
    private Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
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

        // Move around the screen
        transform.position = transform.position + new Vector3(0, verticalInput * speed * Time.deltaTime, 0);
        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);


        /* Limit the x and y axis movement won't work will return to this later   
        if (transform.position.x < xBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        else if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        */
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
    }
}
