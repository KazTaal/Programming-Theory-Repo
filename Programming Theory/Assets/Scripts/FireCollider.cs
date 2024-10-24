using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollider : MonoBehaviour
{
    private GameManager gameManager;
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fireman"))
        {
            gameManager.EndLevel();
        }
        if (other.CompareTag("GameOver"))
        {
            gameManager.EndLevel();
        }
        if (other.CompareTag("Projectile"))
        {
            Instantiate(explosionParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}