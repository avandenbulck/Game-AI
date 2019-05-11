using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flee : Seek
{
   
    public override SteeringOutput GetSteering()
    {
        SteeringOutput result = base.GetSteering();

        result.velocity = -result.velocity;

        return result;
    } 
}
