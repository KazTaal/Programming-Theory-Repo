using System.Collections.Generic;
using UnityEngine;

public class SquadManager : MonoBehaviour
{
    public GameObject firemanPrefab;
    public Transform firemanParent;
    private List<GameObject> firemenList = new List<GameObject>();
    private int currentFiremen = 0;
    private int maxFiremen = 10;

    // ABSTRACTION
    public void UpdateSquad(float currentPower, float maxPower)
    {
        int desiredFiremen = Mathf.RoundToInt((currentPower / maxPower) * maxFiremen);

        // Adjust firemen count
        if (desiredFiremen > currentFiremen)
        {
            AddFiremen(desiredFiremen - currentFiremen);
        }
        else if (desiredFiremen < currentFiremen)
        {
            RemoveFiremen(currentFiremen - desiredFiremen);
        }
    }

    // Add firemen to the squad (encapsulation)
    private void AddFiremen(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newFireman = Instantiate(firemanPrefab, firemanParent);
            firemenList.Add(newFireman);
        }
        currentFiremen += count;
    }

    // Remove firemen from the squad (encapsulation)
    private void RemoveFiremen(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Destroy(firemenList[firemenList.Count - 1]);
            firemenList.RemoveAt(firemenList.Count - 1);
        }
        currentFiremen -= count;
    }
}
