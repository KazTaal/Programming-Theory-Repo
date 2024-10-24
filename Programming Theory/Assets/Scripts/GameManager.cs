using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance;

    // Current level number
    public int currentLevel = 1;

    // Extinguish power variable
    public float extinguishPower = 0f;

    // Maximum extinguish power required to control the fire
    public float maxExtinguishPower = 100f;

    // Reference to SquadManager
    public SquadManager squadManager;

    // Flag to check if the level has ended
    public bool levelEnded = false;
    public bool levelPaused = false;

    public GameObject[] objectPrefabs;
    private float spawnDelay = 0;
    private float spawnInterval = 1.5f;

    void Awake()
    {
        // Implement Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes if needed
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
     //   playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
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
        // Reset other components as needed
    }
}
