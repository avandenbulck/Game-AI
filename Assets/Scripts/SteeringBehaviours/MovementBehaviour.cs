using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementBehaviour : MonoBehaviour
{
    public abstract MovementData GetMovement(MovementData currentMovement);

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
}

public struct MovementData
{
    public Vector2 velocity;
    public Vector2 angle;
}

