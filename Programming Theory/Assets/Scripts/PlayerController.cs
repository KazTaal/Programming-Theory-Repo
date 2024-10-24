using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement speed
    public float horizontalInput;
    private float speed = 15.0f;
    private float xRange = 12.0f;

    // Reference to the GameManager
    private GameManager gameManager;
  

    void Start()
    {
        gameManager = GameManager.Instance;

    }

    void Update()
    {
       if (!gameManager.levelPaused) 
       {
       if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
       }
    }

    
}
