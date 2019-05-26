using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    Connection[] connections;

    private void Awake()
    {
        connections = GetComponentsInChildren<Connection>();
    }

    public List<Transform> GetConnections(Transform node)
    {
        List<Transform> connectedNodes = new List<Transform>();

        foreach (Connection connection in connections)
        {
            if (connection.fromNode == node)
                connectedNodes.Add(connection.toNode);
            else if (connection.toNode == node)
                connectedNodes.Add(connection.fromNode);
        }

        return connectedNodes;
    }

    public Transform GetClosestNode(Vector3 goalPosition)
    {
        Transform closestNode = connections[0].fromNode;
        float closestDistance = Vector2.Distance(closestNode.position, goalPosition);

        foreach (Connection connection in connections)
        {
            if (Vector2.Distance(connection.fromNode.position, goalPosition) < closestDistance)
            {
                closestNode = connection.fromNode;
                closestDistance = Vector2.Distance(closestNode.position, goalPosition);
            } else if (Vector2.Distance(connection.toNode.position, goalPosition) < closestDistance)
            {
                closestNode = connection.toNode;
                closestDistance = Vector2.Distance(closestNode.position, goalPosition);
            }               
        }

        return closestNode;
    }
}
