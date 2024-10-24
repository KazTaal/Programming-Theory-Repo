using UnityEngine;

public class Projectile : GameEntity
{
    protected override void Move()
    {
        base.Move();
        if (IsOffScreen(10))  // ENCAPSULATION
        {
            DestroyEntity();
        }
    }

    // ABSTRACTION
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
