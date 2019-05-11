using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Seek : SteeringBehaviour
{
    public Transform agent;
    public Transform target;
    public float maxSpeed;
   
    public override SteeringOutput GetSteering()
    {
        SteeringOutput result = new SteeringOutput();
        if (target == null)
            Debug.LogError("Can not seek without target");
        else if (agent == null)
            Debug.LogError("Can not seek without knowing own position");
        else
        {
            Vector2 newVelocity = DistanceVectorToTarget();
            newVelocity.Normalize();
            newVelocity *= maxSpeed;
            result.velocity = newVelocity;
        }

        return result;
    } 

    public Vector2 DistanceVectorToTarget()
    {
        return target.position - agent.position;
    }
}
