using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : Seek
{
    public float radius;

    public override SteeringOutput GetSteering()
    {
        if(DistanceVectorToTarget().magnitude <= radius)
        {
            return new SteeringOutput();
        }else
        {
            return base.GetSteering();
        }
    }
}
