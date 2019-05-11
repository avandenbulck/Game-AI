using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : SteeringBehaviour
{
    public Transform agent;
    public float maxSpeed;
    public float maxRotationAngle;

    public override SteeringOutput GetSteering()
    {
        SteeringOutput result = new SteeringOutput();

        float random = Random.Range(0f, 1f);

        float rotationAngle = RandomBinomial() * maxRotationAngle;

        result.rotationAngle = rotationAngle;

        float angle = transform.rotation.eulerAngles.z;
        Vector2 velocity = new Vector2(-Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad)) * maxSpeed;

        result.velocity = velocity;
        return result;
    }

    public float RandomBinomial()
    {
        return Random.Range(0, 1f) - Random.Range(0, 1f);
    }

}
