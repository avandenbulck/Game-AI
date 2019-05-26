using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyMovementBehaviour : MonoBehaviour
{
    public Transform agent;
    public MovementBehaviour movementBehaviour;
    public float speed;
    public float rotationSpeed;

    MovementData currentMovement;

    private void Awake()
    {
        currentMovement.velocity = Vector2.zero;
        currentMovement.angle = transform.up;
    }

    void Update()
    {
        // Get the desired velocity and angle
        MovementData desiredMovement = movementBehaviour.GetMovement(currentMovement);


        // Apply the desired 
        currentMovement = Apply(desiredMovement);
        
    }

    private MovementData Apply(MovementData desiredMovement)
    {
        /*
         * This class assumes we have a vehicle that can only drive forward and rotate in the desired rotation at a maximum rotationSpeed. 
         */

        MovementData newMovement = new MovementData();

        // Calculate and apply rotationAngle;
        if (desiredMovement.angle != Vector2.zero)
        {
            float desiredAngleInDegrees = Vector2.SignedAngle(currentMovement.angle, desiredMovement.angle);
            newMovement.angle = VectorUtilities.Rotate(currentMovement.angle, Mathf.Clamp(desiredAngleInDegrees, -rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime));
            agent.rotation = Quaternion.LookRotation(Vector3.forward, newMovement.angle);
        }
        else
        {
            newMovement.angle = currentMovement.angle;
        }

        // Calculate and apply velocity
        newMovement.velocity = newMovement.angle * desiredMovement.velocity.magnitude * speed;
        agent.position += (Vector3)newMovement.velocity * Time.deltaTime;
 
        return newMovement;
    }
}
