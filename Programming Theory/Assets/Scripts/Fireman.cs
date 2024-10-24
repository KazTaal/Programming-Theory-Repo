using UnityEngine;

//INHERITANCE
public class Fireman : GameEntity
{
    private float extinguishPower;
    
    // Override the base movement method for fireman-specific movement
    protected override void Move()
    {
        base.Move();
        // Additional fireman-specific movement code can go here
    }

    // Method to increase fireman's extinguish power
    public void IncreaseExtinguishPower(float amount)
    {
        extinguishPower += amount;
    }
}
