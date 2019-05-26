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
}
