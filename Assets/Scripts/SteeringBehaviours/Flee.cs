using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flee : Seek
{
   
    public override SteeringData GetSteering(SteeringData currentSteering)
    {
        SteeringData result = base.GetSteering(currentSteering);

        result.velocity *= -1;
        result.angle *= -1;

        return result;
    } 
}
