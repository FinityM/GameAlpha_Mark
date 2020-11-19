using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Will not use for illusion of background moving delete this script
 */
public class RepeatingBackground : MonoBehaviour
{
    private float repeatWidth;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startRepeat();
        

    }

    // Update is called once per frame
    void Update()
    {
        moveBack();
   
    }

    void startRepeat()
    {
        // Starting position
        startPos = transform.position;

        // Repeat width to half of background
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;

    }

    void moveBack()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }

    }
  
}
