using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplySteeringBehaviour : MonoBehaviour
{
    public Transform agent;
    public SteeringBehaviour steeringBehaviour;

    SteeringData currentSteering;

    private void Awake()
    {
        currentSteering.velocity = Vector2.zero;
        currentSteering.angle = transform.up;
    }

    void Update()
    {
        SteeringData newSteering = steeringBehaviour.GetSteering(currentSteering);

        // Change position according to velocity
        Vector3 velocity = newSteering.velocity;
        agent.position += velocity * Time.deltaTime;

        if (newSteering.angle.magnitude > 0)
        {
            agent.rotation = Quaternion.LookRotation(Vector3.forward, newSteering.angle);
        }
        currentSteering = newSteering;
    }
}
