using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveProjectile : MonoBehaviour
{
    protected float speed = 12.0f;

    // Virtual method for movement (polymorphism)
    protected virtual void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    // Method to destroy the entity (abstraction)
    public void DestroyEntity()
    {
        Destroy(gameObject);
    }

    // Common method to check if the object is off-screen (encapsulation)
    protected bool IsOffScreen(float boundary)
    {
        return transform.position.z > boundary;
    }
}
