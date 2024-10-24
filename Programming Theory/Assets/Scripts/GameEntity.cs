using UnityEngine;

public abstract class GameEntity : MonoBehaviour
{
    protected float speed = 5.0f;

    //POLYMORPHISM
    protected virtual void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    //ABSTRACTION
    public void DestroyEntity()
    {
        Destroy(gameObject);
    }

    //ENCAPSULATION
    protected bool IsOffScreen(float boundary)
    {
        return transform.position.z > boundary;
    }
}
