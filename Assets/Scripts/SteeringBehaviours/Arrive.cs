using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : Seek
{
    public float radius;

    public override MovementData GetMovement(MovementData currentSteering)
    {
        if(DistanceToTarget(target.position) <= radius)
        {
            return new MovementData();
        }else
        {
            return base.GetMovement(currentSteering);
        }
    }
}
