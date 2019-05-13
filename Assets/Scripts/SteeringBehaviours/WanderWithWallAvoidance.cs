using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderWithWallAvoidance : MovementBehaviour
{
    public Transform agent;
    public Transform largeWhisker;
    public Transform smallWhiskers1;
    public Transform smallWhiskers2;
    public LayerMask wallLayers;
    public float normalRatio;
    public Seek seek;
    public Wander wander;

    bool seeking;
    Vector3 target;

    void Start()
    {
        seeking = false;
    }

    void Update()
    {
        if (seeking)
        {
            Debug.DrawLine(agent.position, largeWhisker.position, Color.red);
            Debug.DrawLine(agent.position, smallWhiskers1.position, Color.red);
            Debug.DrawLine(agent.position, smallWhiskers2.position, Color.red);
            Debug.DrawLine(agent.position, target, Color.green);
        }
        else
        {
            Debug.DrawLine(agent.position, largeWhisker.position, Color.green);
            Debug.DrawLine(agent.position, smallWhiskers1.position, Color.green);
            Debug.DrawLine(agent.position, smallWhiskers2.position, Color.green);
        }
    }

    public override MovementData GetMovement(MovementData currentMovement)
    {
        RaycastHit2D largeWhiskersHit = Physics2D.Linecast(agent.position, largeWhisker.position, wallLayers);
        RaycastHit2D smallWhiskersHit1 = Physics2D.Linecast(agent.position, smallWhiskers1.position, wallLayers);
        RaycastHit2D smallWhiskersHit2 = Physics2D.Linecast(agent.position, smallWhiskers2.position, wallLayers);

        RaycastHit2D closestHit = new RaycastHit2D();
        float distanceToClosestHit = float.MaxValue;

        if(largeWhiskersHit.collider != null && largeWhiskersHit.distance < distanceToClosestHit)
        {
            closestHit = largeWhiskersHit;
            distanceToClosestHit = largeWhiskersHit.distance;
        }
        if (smallWhiskersHit1.collider != null && smallWhiskersHit1.distance < distanceToClosestHit)
        {
            closestHit = smallWhiskersHit1;
            distanceToClosestHit = smallWhiskersHit1.distance;
        }
        if (smallWhiskersHit2.collider != null && smallWhiskersHit2.distance < distanceToClosestHit)
        {
            closestHit = smallWhiskersHit2;
            distanceToClosestHit = smallWhiskersHit2.distance;
        }

        if (closestHit.collider != null)
        {
            return GetSeekingData(currentMovement, closestHit);
        }

        seeking = false;
        return wander.GetMovement(currentMovement);
    }

    private MovementData GetSeekingData(MovementData currentMovement, RaycastHit2D hit)
    {
        seeking = true;
        target = hit.point + hit.normal * normalRatio;
        return seek.GetMovement(currentMovement, target);
    }
}
