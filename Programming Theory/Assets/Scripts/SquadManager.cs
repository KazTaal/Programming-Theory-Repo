using System.Collections.Generic;
using UnityEngine;

public class SquadManager : MonoBehaviour
{
    // Prefab for a fireman
    public GameObject firemanPrefab;

    // Parent object to hold firemen
    public Transform firemanParent;

    // Maximum number of firemen
    public int maxFiremen = 10;

    // Current number of firemen
    private int currentFiremen = 0;

    // List to keep track of instantiated firemen
    private List<GameObject> firemenList = new List<GameObject>();

    void Start()
    {
        UpdateSquad(0f, GameManager.Instance.maxExtinguishPower);
    }

    // Method to update the squad based on extinguish power
    public void UpdateSquad(float currentPower, float maxPower)
{
    // Calculate desired number of firemen
    float ratio = currentPower / maxPower;
    int desiredFiremen = Mathf.RoundToInt(ratio * maxFiremen);

    // Clamp the desired number between 0 and maxFiremen
    desiredFiremen = Mathf.Clamp(desiredFiremen, 0, maxFiremen);

    // Adjust the number of firemen
    if (desiredFiremen > currentFiremen)
    {
        // Add firemen with position offset
        for (int i = currentFiremen; i < desiredFiremen; i++)
        {
            // Calculate offset position (you can adjust spacing)
            Vector3 offset = new Vector3(i * 2.0f, 0, 0); // Spacing firemen 2 units apart on x-axis
            GameObject newFireman = Instantiate(firemanPrefab, firemanParent);
            
            // Set the position of the new fireman
            newFireman.transform.localPosition = offset;
            
            firemenList.Add(newFireman);
        }
    }
    else if (desiredFiremen < currentFiremen)
    {
        // Remove firemen
        for (int i = currentFiremen - 1; i >= desiredFiremen; i--)
        {
            Destroy(firemenList[i]);
            firemenList.RemoveAt(i);
        }
    }

    currentFiremen = desiredFiremen;
}
}
