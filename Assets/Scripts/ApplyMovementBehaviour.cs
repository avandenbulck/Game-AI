using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyMovementBehaviour : MonoBehaviour
{
    public Transform agent;
    public MovementBehaviour steeringBehaviour;

    MovementData currentMovement;

    private void Awake()
    {
        currentMovement.velocity = Vector2.zero;
        currentMovement.angle = transform.up;
    }

    void Update()
    {
        MovementData newSteering = steeringBehaviour.GetMovement(currentMovement);

        // Change position according to velocity
        Vector3 velocity = newSteering.velocity;
        agent.position += velocity * Time.deltaTime;

        if (newSteering.angle.magnitude > 0)
        {
            agent.rotation = Quaternion.LookRotation(Vector3.forward, newSteering.angle);
        }
        currentMovement = newSteering;
    }
}
