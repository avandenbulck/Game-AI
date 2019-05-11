using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flee : Seek
{
   
    public override MovementData GetMovement(MovementData currentSteering)
    {
        MovementData result = base.GetMovement(currentSteering);

        result.velocity *= -1;
        result.angle *= -1;

        return result;
    } 
}
