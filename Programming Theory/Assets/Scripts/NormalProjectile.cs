using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalProjectile : MoveProjectile
{
    private float topOffscreen = 10;
   

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
