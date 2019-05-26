using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyPathFinding : MonoBehaviour
{ 
    public Transform agent;
    public Arrive movementBehaviour;
    public float speed;
    public float rotationSpeed;
    public Graph graph;
    public Transform currentNode;
    public Transform goal;

    MovementData currentMovement;
    List<Transform> path;
    bool followingPath = false;
    int currentIndexOnPath;

    public void GoTo(Transform goal)
    {
        path = Dijkstra.FindPath(graph, currentNode, goal);
        followingPath = true;
        currentIndexOnPath = 0;
        movementBehaviour.target = path[0];
    }

    private void Awake()
    {
        currentMovement.velocity = Vector2.zero;
        currentMovement.angle = transform.up;
    }

    void Update()
    {
        if(goal != null)
        {
            GoTo(goal);
            goal = null;
        }

        if (followingPath)
        {
            Transform nextPoint = path[currentIndexOnPath];
            
            // Get the desired velocity and angle
            MovementData desiredMovement = movementBehaviour.GetMovement(currentMovement);

            // Apply the desired 
            currentMovement = Apply(desiredMovement);

            if (Vector2.Distance(agent.position, nextPoint.position) < 0.01f)
            {
                currentIndexOnPath++;
                if (currentIndexOnPath == path.Count)                
                    followingPath = false;
                else
                    movementBehaviour.target = path[currentIndexOnPath];
            }           
        }    
    }

    private MovementData Apply(MovementData desiredMovement)
    {
        /*
         * This class assumes we have a vehicle that can only drive forward and rotate in the desired rotation at a maximum rotationSpeed. 
         */

        MovementData newMovement = new MovementData();

        // Calculate and apply rotationAngle;
        if (desiredMovement.angle != Vector2.zero)
        {
            float desiredAngleInDegrees = Vector2.SignedAngle(currentMovement.angle, desiredMovement.angle);
            newMovement.angle = VectorUtilities.Rotate(currentMovement.angle, Mathf.Clamp(desiredAngleInDegrees, -rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime));
            agent.rotation = Quaternion.LookRotation(Vector3.forward, newMovement.angle);
        }
        else
        {
            newMovement.angle = currentMovement.angle;
        }

        // Calculate and apply velocity
        newMovement.velocity = newMovement.angle * desiredMovement.velocity.magnitude * speed;
        agent.position += (Vector3)newMovement.velocity * Time.deltaTime;

        return newMovement;
    }
}
