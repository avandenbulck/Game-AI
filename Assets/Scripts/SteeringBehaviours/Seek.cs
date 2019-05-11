using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Seek : MovementBehaviour
{
    public Transform agent;
    public Transform target;
    public float speed;
   
    public override MovementData GetMovement(MovementData currentSteering)
    {
        MovementData result = new MovementData();

        Vector2 distanceVector = DistanceVectorToTarget();
       
        distanceVector.Normalize();
        result.velocity = distanceVector * speed;
        result.angle = distanceVector;
     
        return result;
    } 

    public Vector2 DistanceVectorToTarget()
    {
        return target.position - agent.position;
    }
}
