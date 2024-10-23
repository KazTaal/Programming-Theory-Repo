using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private float speed = 6;
    private Vector3 startPos;
    private float bottomOffscreen = -18;
    private float repeatHeight = 36.4818763518f;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.levelPaused && !gameManager.levelEnded)
        {
        transform.Translate(Vector3.forward * Time.deltaTime * -speed); 
        }


        if (transform.position.z <= startPos.z - repeatHeight && CompareTag("Background"))
        {
            transform.position = startPos;
        }
 

        if (transform.position.z <= bottomOffscreen && CompareTag("LevelEnd"))
        {
            Destroy(gameObject);
        }
        if (transform.position.z <= bottomOffscreen && CompareTag("Particle"))
        {
            Destroy(gameObject);
        }
    }
}
