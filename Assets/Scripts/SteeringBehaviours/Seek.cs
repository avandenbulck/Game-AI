using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Seek : MovementBehaviour
{
    public Transform agent;
    public Transform target;

    public override MovementData GetMovement(MovementData currentMovement)
    {
        return GetMovement(currentMovement, target.position);
    } 

    public MovementData GetMovement(MovementData currentMovement, Vector3 targetPosition)
    {
        MovementData result = new MovementData();

        Vector2 distanceVector = targetPosition - agent.position;

        result.velocity = distanceVector.normalized;
        result.angle = distanceVector;

        return result;
    }

    public float DistanceToTarget(Vector3 targetPosition)
    {
        return (targetPosition - agent.position).magnitude;
    }

    public float DistanceToTarget()
    {
        return DistanceToTarget(target.position);
    }
}
