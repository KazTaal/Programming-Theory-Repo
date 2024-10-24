using UnityEngine;
using TMPro;

public class LevelEndManager : MonoBehaviour
{
    // Singleton instance
    public static LevelEndManager Instance;

    // Reference to the Fire object
    public GameObject fireObject;

    // Reference to the TextMeshProUGUI for displaying result
    public TextMeshProUGUI resultText;

    // Threshold to control the fire
    public float controlThreshold = 70f;

    void Awake()
    {
        // Implement Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject); // If needed
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to handle level end
    public void HandleLevelEnd(float currentPower)
    {
        // Show the fire
        fireObject.SetActive(true);
        
           
        // Check if extinguish power is sufficient
        if (currentPower >= controlThreshold)
        {
            // Control the fire
            FireControlled(true);
            resultText.text = "Fire Controlled! Well Done!";
            resultText.color = Color.green;
        }
        else
        {
            // Fire is uncontrolled
            FireControlled(false);
            resultText.text = "Fire Escaped! Try Again!";
            resultText.color = Color.red;
        }

        // Optionally, show UI elements for level completion
    }

    void FireControlled(bool isControlled)
    {
        if (isControlled)
        {
            // Play fire extinguished animation/effects
            //fireObject.GetComponent<Animator>().SetTrigger("Extinguish");
            // Or disable fire visual
            // fireObject.SetActive(false);
        }
        else
        {
            // Play fire uncontrolled animation/effects
            //fireObject.GetComponent<Animator>().SetTrigger("Uncontrolled");
            // Or keep fire active with animations
        }
    }
}
