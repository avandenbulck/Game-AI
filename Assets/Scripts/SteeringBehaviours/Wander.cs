using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MovementBehaviour
{
    public Transform agent;
    public float maxAngleDelta;
    public float timeBetweenDirections;

    Vector2 targetDirection;
    float timeToChooseNewDirectionOn;

    void Start()
    {
        timeToChooseNewDirectionOn = Time.time;
    }

    public override MovementData GetMovement(MovementData currentMovement)
    {
        if(Time.time >= timeToChooseNewDirectionOn)
        {
            ChooseNewDirection(currentMovement.angle);
            timeToChooseNewDirectionOn = Time.time + timeBetweenDirections;
        }

        MovementData result = new MovementData();

        result.angle = targetDirection;
        result.velocity = targetDirection;

        Debug.DrawRay(agent.position, targetDirection);
        return result;
    }

    private void ChooseNewDirection(Vector2 currentAngle)
    {
        float rotationAngle = RandomBinomial() * maxAngleDelta;
        targetDirection = VectorUtilities.Rotate(currentAngle, rotationAngle);
        targetDirection.Normalize();
    }

    public float RandomBinomial()
    {
        return Random.Range(0, 1f) - Random.Range(0, 1f);
    }

}
