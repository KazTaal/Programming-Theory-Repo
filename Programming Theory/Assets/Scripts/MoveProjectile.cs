using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
       public float speed = 40.0f;
       private float topOffscreen = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
         if (transform.position.z >= topOffscreen)
        {
            Destroy(gameObject);
        }
    }
}
