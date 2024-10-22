using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    private float spawnDelay = 0;
    private float spawnInterval = 0.3f;
    public GameObject projectilePrefab;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        InvokeRepeating("SprayWater", spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SprayWater()
    {
        if (!gameManager.levelPaused)
        {
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
