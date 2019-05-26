using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyPathFinding : MonoBehaviour
{
    public Arrive arrive;
    public ApplyMovementBehaviour applyMovement;
    public Graph graph;
    public bool applyPathSmoothing;
    public LayerMask wallMask;

    MovementData currentMovement;
    List<Transform> path;
    bool followingPath = false;
    int currentIndexOnPath;

    public void GoTo(Vector3 goalPosition)
    {
        Transform closestNodeToGoal = graph.GetClosestNode(goalPosition);
        GoTo(closestNodeToGoal);
    }

    public void GoTo(Transform goal)
    {
        Transform currentNode = graph.GetClosestNode(arrive.agent.position);
        path = Dijkstra.FindPath(graph, currentNode, goal);
        if (applyPathSmoothing)
        {
            path = SmoothPath(arrive.agent.position, path);
        }
        followingPath = true;
        applyMovement.enabled = true;
        currentIndexOnPath = 0;
        arrive.target = path[0];
    }

    private void Awake()
    {
        currentMovement.velocity = Vector2.zero;
        currentMovement.angle = transform.up;
        applyMovement.enabled = false;
    }

    void Update()
    {
        if (followingPath)
        {
            Transform nextPoint = path[currentIndexOnPath];
            
            if (Vector2.Distance(applyMovement.agent.position, nextPoint.position) <= 0.1f)
            {
                currentIndexOnPath++;
                if (currentIndexOnPath == path.Count)
                {
                    followingPath = false;
                    applyMovement.enabled = false;
                }                                 
                else
                    arrive.target = path[currentIndexOnPath];
            }

            // Debug            
            if (applyPathSmoothing && currentIndexOnPath < path.Count)
            {
                Debug.DrawLine(arrive.agent.position, path[currentIndexOnPath].position, Color.yellow);
                for (int i = currentIndexOnPath; i < path.Count - 1; i++)
                {
                    Debug.DrawLine(path[i].position, path[i + 1].position, Color.yellow);
                }
            }               
            else
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Debug.DrawLine(path[i].position, path[i + 1].position, Color.red);
                }
        }    
    }

    private List<Transform> SmoothPath(Vector3 startPosition, List<Transform> path)
    {
        if (path.Count <= 1)
            return path;

        Vector3 currentPosition = startPosition;
        Transform bestNextPointSoFar = path[0];
        List<Transform> newPath = new List<Transform>();

        for (int i = 1; i < path.Count; i++)
        {
            Transform nextPointToCheck = path[i];
            RaycastHit2D hit;
            hit = Physics2D.Linecast(currentPosition, nextPointToCheck.position, wallMask);

            if(hit.collider == null)
            {
                // We don't need the previous point. Replace it with the new point.
                bestNextPointSoFar = nextPointToCheck;
            }
            else
            {
                // We need the previous point.
                newPath.Add(bestNextPointSoFar);
                currentPosition = bestNextPointSoFar.position;
                bestNextPointSoFar = nextPointToCheck;
            }

            if (i >= (path.Count - 1))
                newPath.Add(nextPointToCheck);
        }

        return newPath;
    }
}
