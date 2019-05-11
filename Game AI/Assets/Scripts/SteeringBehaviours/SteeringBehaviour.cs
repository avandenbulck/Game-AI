using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SteeringBehaviour : MonoBehaviour
{
    public abstract SteeringOutput GetSteering();
}

public struct SteeringOutput
{
    public Vector2 velocity;
    public float rotationAngle;
}

