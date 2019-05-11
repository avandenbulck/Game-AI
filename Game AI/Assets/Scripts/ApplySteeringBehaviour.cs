using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplySteeringBehaviour : MonoBehaviour
{
    public Transform agent;
    public SteeringBehaviour steeringBehaviour;
    public bool useRotationAngle;

    void Update()
    {
        SteeringOutput output = steeringBehaviour.GetSteering();

        // Change position according to velocity
        Vector3 velocity = output.velocity;
        agent.position += velocity * Time.deltaTime;

        // Change orientation to look at the direction of the velocity
        if(velocity.magnitude > 0 && !useRotationAngle)
        {
            agent.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(-velocity.x, velocity.y) * Mathf.Rad2Deg);
        }else if (useRotationAngle)
        {
            agent.Rotate(Vector3.forward * output.rotationAngle * Time.deltaTime);
        }
    }

}
