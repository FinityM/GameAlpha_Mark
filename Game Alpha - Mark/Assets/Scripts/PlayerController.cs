using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    private float verticalInput;
    private float upperLimit = 16;
    private float lowerLimit = 2;
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

        // Key presses for up and down the y axis of the position 
        transform.position = transform.position + new Vector3(0, verticalInput * speed * Time.deltaTime, 0);

        // Limit the value the player can move within the y axis for position
        Mathf.Clamp(transform.position.y, lowerLimit, upperLimit);


    }
}
