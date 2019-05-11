using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SteeringBehaviour : MonoBehaviour
{
    public abstract SteeringData GetSteering(SteeringData currentSteering);
}

public struct SteeringData
{
    public Vector2 velocity;
    public Vector2 angle;
}

