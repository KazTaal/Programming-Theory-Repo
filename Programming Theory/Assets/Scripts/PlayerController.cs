using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement speed
    public float moveSpeed = 5f;

    // Reference to the GameManager
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
    }

    void Update()
    {
        // Automatically move the player forward
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Optionally, add controls to move left/right or jump
    }

    // Example: Trigger end of level when player reaches a certain point
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LevelEnd"))
        {
            gameManager.EndLevel();
        }
    }
}
