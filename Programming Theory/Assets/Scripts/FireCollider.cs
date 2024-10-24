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
        else if (other.CompareTag("GameOver"))
        {
            gameManager.EndLevel();
        }
        else if (other.CompareTag("Projectile"))
        {
            TriggerExplosion();
            Destroy(gameObject);
        }
    }
    private void TriggerExplosion() // ABSTRACTION
    {
        Instantiate(explosionParticle, transform.position, transform.rotation);
    }
}
