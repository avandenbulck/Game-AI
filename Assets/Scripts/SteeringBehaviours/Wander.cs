using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : SteeringBehaviour
{
    public Transform agent;
    public float maxAngleDelta;
    public float rotatingSpeed;
    public float timeBetweenDirections;
    public float speed;

    public Vector2 targetDirection;
    float timeToChooseNewDirectionOn;

    void Start()
    {
        timeToChooseNewDirectionOn = Time.time;
    }

    public override SteeringData GetSteering(SteeringData currentSteering)
    {
        if(Time.time >= timeToChooseNewDirectionOn)
        {
            ChooseNewDirection(currentSteering.angle);
            timeToChooseNewDirectionOn = Time.time + timeBetweenDirections;
        }

        SteeringData result = new SteeringData();
        float angleToTargetDirection = Vector2.SignedAngle(currentSteering.angle, targetDirection);
        result.angle = Rotate(currentSteering.angle, Mathf.Clamp(angleToTargetDirection,-rotatingSpeed * Time.deltaTime, rotatingSpeed * Time.deltaTime));

        result.velocity = result.angle * speed;

        Debug.DrawRay(agent.position, targetDirection);
        return result;
    }

    private void ChooseNewDirection(Vector2 currentVelocity)
    {
        float rotationAngle = RandomBinomial() * maxAngleDelta;
        targetDirection = Rotate(currentVelocity, rotationAngle);
        targetDirection.Normalize();
    }

    public static Vector2 Rotate(Vector2 vector, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = vector.x;
        float ty = vector.y;
        vector.x = (cos * tx) - (sin * ty);
        vector.y = (sin * tx) + (cos * ty);
        return vector;
    }

    public float RandomBinomial()
    {
        return Random.Range(0, 1f) - Random.Range(0, 1f);
    }

}
