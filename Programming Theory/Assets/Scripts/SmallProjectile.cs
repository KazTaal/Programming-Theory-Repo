using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class SmallProjectile : MoveProjectile
{
   private float topOffscreen = 5;
   

    // Update is called once per frame
    void Update()
    {
      
        base.Move();
        if (IsOffScreen(topOffscreen))  // Check if off-screen (encapsulation)
        {
            DestroyEntity();
        }
   
    }
}
