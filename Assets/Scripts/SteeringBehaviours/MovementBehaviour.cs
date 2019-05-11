using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementBehaviour : MonoBehaviour
{
    public abstract MovementData GetMovement(MovementData currentMovement);
}

public struct MovementData
{
    public Vector2 velocity;
    public Vector2 angle;
}

