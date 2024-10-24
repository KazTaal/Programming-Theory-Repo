using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
       private float speed = 15.0f;
       private float topOffscreen = 10;


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