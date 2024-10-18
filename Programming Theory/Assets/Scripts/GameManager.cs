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

    // Method to end the level
    public void EndLevel()
    {
        levelEnded = true;
        // Trigger LevelEndManager or other end-of-level logic
        LevelEndManager.Instance.HandleLevelEnd(extinguishPower);
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
