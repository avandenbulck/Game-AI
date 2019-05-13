using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Seek : MovementBehaviour
{
    public Transform agent;
    public Transform target;
    public float speed;
    public float rotatingSpeed;
   
    public override MovementData GetMovement(MovementData currentMovement)
    {
        return GetMovement(currentMovement, target.position);
    } 

    public MovementData GetMovement(MovementData currentMovement, Vector3 targetPosition)
    {
        MovementData result = new MovementData();

        Vector2 distanceVector = targetPosition - agent.position;
        distanceVector.Normalize();
        if(distanceVector.magnitude > 0.01)
        {
            result.velocity = distanceVector * speed;
            result.angle = distanceVector;
        }
        else
        {
            result.angle = currentMovement.angle;
        }

        float desiredRotationAngle = Vector2.SignedAngle(currentMovement.angle, result.angle);
        result.angle = Rotate(currentMovement.angle, Mathf.Clamp(desiredRotationAngle, -rotatingSpeed * Time.deltaTime, rotatingSpeed * Time.deltaTime));
        result.velocity = result.angle * speed;

        return result;
    }

    public float DistanceToTarget(Vector3 targetPosition)
    {
        return (targetPosition - agent.position).magnitude;
    }
}
