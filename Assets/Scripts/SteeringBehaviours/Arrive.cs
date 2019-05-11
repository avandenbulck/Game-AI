using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : Seek
{
    public float radius;

    public override SteeringData GetSteering(SteeringData currentSteering)
    {
        if(DistanceVectorToTarget().magnitude <= radius)
        {
            return new SteeringData();
        }else
        {
            return base.GetSteering(currentSteering);
        }
    }
}
