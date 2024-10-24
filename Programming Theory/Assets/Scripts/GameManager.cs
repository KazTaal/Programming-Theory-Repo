using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Current level number
    public int currentLevel = 1;

    // Extinguish power variable
    public float extinguishPower = 0f;

    // Maximum extinguish power required to control the fire
    public float maxExtinguishPower = 100f;

    // Reference to SquadManager
    public SquadManager squadManager;

    // Flag to check if the level has ended or paused
    public bool levelEnded = false;
    public bool levelPaused = false;

    // Object spawning
    public GameObject[] objectPrefabs;
    private float spawnDelay = 0f;
    private float spawnInterval = 1.5f;

    public static GameManager Instance { get; private set; } // Singleton instance

    private void Awake()
    {
        // Singleton Pattern implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: keeps the GameManager persistent across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate instances of GameManager
        }
    }

    void Start()
    {
        // Repeatedly spawn objects at intervals
        InvokeRepeating(nameof(SpawnObjects), spawnDelay, spawnInterval);
    }

    // Increase extinguish power
    public void IncreaseExtinguishPower(float amount)
    {
        extinguishPower += amount;
        if (extinguishPower > maxExtinguishPower)
            extinguishPower = maxExtinguishPower;

        // Update the fireman squad accordingly
        squadManager.UpdateSquad(extinguishPower, maxExtinguishPower);
    }

    // Decrease extinguish power
    public void DecreaseExtinguishPower(float amount)
    {
        extinguishPower -= amount;
        if (extinguishPower < 0f)
            extinguishPower = 0f;

        // Update the fireman squad accordingly
        squadManager.UpdateSquad(extinguishPower, maxExtinguishPower);
    }

    // Spawn objects at random positions if level is not paused or ended
    private void SpawnObjects()
    {
        if (!levelPaused && !levelEnded)
        {
            Vector3 spawnLocation = new Vector3(Random.Range(-12, 12), 0, 18);
            int index = Random.Range(0, objectPrefabs.Length);

            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        }
    }

    // End the level and show results
    public void EndLevel()
    {
        levelEnded = true;
        LevelEndManager.Instance.HandleLevelEnd(extinguishPower);
    }

    // Pause the level
    public void PauseLevel()
    {
        levelPaused = true;
        // Additional logic for pausing the game (e.g., stopping time, freezing objects)
    }

    // Resume the level
    public void ResumeLevel()
    {
        levelPaused = false;
        // Additional logic for resuming the game (e.g., restarting time)
    }

    // Reset the level and extinguish power, firemen squad, etc.
    public void ResetLevel()
    {
        extinguishPower = 0f;
        levelEnded = false;
        squadManager.UpdateSquad(extinguishPower, maxExtinguishPower);
        // Reset other components as needed (e.g., reposition objects, reset scores)
    }
}
