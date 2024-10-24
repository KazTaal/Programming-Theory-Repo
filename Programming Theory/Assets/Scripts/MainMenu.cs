using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    public void StartAgain()
    {
        gameManager.ResetLevel();
        SceneManager.LoadScene(1);
    }
}
