using UnityEngine;
using TMPro;

public class LevelEndManager : MonoBehaviour
{
    // Singleton ENCAPSULATION
    public static LevelEndManager Instance { get; private set; }

    public GameObject fireObject;
    public TextMeshProUGUI resultText;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ABSTRACTION
    public void HandleLevelEnd(float extinguishPower)
    {
        fireObject.SetActive(true);

        // Check if fire was controlled
        if (extinguishPower >= 70f)
        {
            resultText.text = "Fire Controlled!";
            resultText.color = Color.green;
        }
        else
        {
            resultText.text = "Fire Escaped!";
            resultText.color = Color.red;
        }
    }
}
