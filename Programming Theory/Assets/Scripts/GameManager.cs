using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance;

    // Current level number
    public int currentLevel { get; private set; } = 1; // ENCAPSULATION
    
    // Extinguish power variable
    public float extinguishPower { get; private set; } = 0f; // ENCAPSULATION

    // Maximum extinguish power required to control the fire
    public float maxExtinguishPower { get; private set; } = 100f; // ENCAPSULATION


    // Reference to SquadManager
    public SquadManager squadManager; // ABSTRACTION

    // Flag to check if the level has ended
     public bool levelEnded { get; private set; } = false; // ENCAPSULATION
    public bool levelPaused { get; private set; } = false; // ENCAPSULATION

    public GameObject[] objectPrefabs;
    private float spawnDelay = 0;
    private float spawnInterval = 1.5f;

    void Awake()
    {
        // Implement Singleton pattern
        if (Instance == null)
        {
            Instance = this;
          //  DontDestroyOnLoad(gameObject); // Persist across scenes if needed
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        squadManager = FindObjectOfType<SquadManager>();
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
    }

    // Method to increase extinguish power
    public void IncreaseExtinguishPower(float amount)
    {
        extinguishPower += amount;
        if (extinguishPower > maxExtinguishPower)
            extinguishPower = maxExtinguishPower;

        // Update SquadManager
        squadManager.UpdateSquad(extinguishPower, maxExtinguishPower);
    }

    // Method to decrease extinguish power
    public void DecreaseExtinguishPower(float amount)
    {
        extinguishPower -= amount;
        if (extinguishPower < 0f)
            extinguishPower = 0f;

        // Update SquadManager
        squadManager.UpdateSquad(extinguishPower, maxExtinguishPower);
    }

     void SpawnObjects ()
    {
        // Set random spawn location and random object index
        Vector3 spawnLocation = new Vector3(Random.Range(-12, 12), 0, 18);
        int index = Random.Range(0, objectPrefabs.Length);

        // If game is still active, spawn new object
        if (!levelPaused && !levelEnded)
        {
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        }

    }

    // Method to end the level
    public void EndLevel()
    {
        levelEnded = true;
        // Trigger LevelEndManager or other end-of-level logic
        LevelEndManager.Instance.HandleLevelEnd(extinguishPower);
    }

    public void PauseLevel()
    {
        levelPaused = true;
    }
    public void ResumeLevel()
    {
        levelPaused = false;
    }

    // Reset level (optional)
    public void ResetLevel()
    {
        extinguishPower = 0f;
        levelEnded = false;
        squadManager.UpdateSquad(extinguishPower, maxExtinguishPower);
        squadManager.ResetSquad();
        // Reset other components as needed
    }
    
}
