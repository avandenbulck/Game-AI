using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra
{
    public static List<Transform> FindPath(Graph graph, Transform start, Transform end)
    {
        NodeRecord startRecord = new NodeRecord();
        startRecord.nodes.Add(start);
        startRecord.costSoFar = 0;

        List<NodeRecord> open = new List<NodeRecord>();
        List<Transform> closed = new List<Transform>();
        open.Add(startRecord);

        NodeRecord currentRecord = null;

        while (open.Count > 0)
        {
            currentRecord = GetSmallestElement(open);
            Transform currentNode = currentRecord.GetLastNode();
            if (currentRecord.GetLastNode() == end)
                break;

            List<Transform> connectedNodes = graph.GetConnections(currentNode);
            foreach (Transform connectedNode in connectedNodes)
            {
                if (!closed.Contains(connectedNode))
                {
                    float newCostSoFar = currentRecord.costSoFar + Vector2.Distance(currentNode.position, connectedNode.position);
                    NodeRecord newNodeRecord = new NodeRecord();
                    newNodeRecord.nodes = new List<Transform>(currentRecord.nodes);
                    newNodeRecord.nodes.Add(connectedNode);
                    newNodeRecord.costSoFar = newCostSoFar;
                    open.Add(newNodeRecord);
                }
            }

            open.Remove(currentRecord);
            closed.Add(currentNode);
        }

        if (currentRecord == null || currentRecord.GetLastNode() == end)
            return currentRecord.nodes;
        else
            throw new Exception("Did not find a valid path!");
    }

    private static NodeRecord GetSmallestElement(List<NodeRecord> open)
    {
        NodeRecord smallest = open[0];

        for (int i = 1 ; i < open.Count; i++)
        {
            NodeRecord currentNode = open[i];
            if (smallest.costSoFar > currentNode.costSoFar)
                smallest = currentNode;
        }

        return smallest;
    }

    private class NodeRecord
    {
        public List<Transform> nodes = new List<Transform>();
        public float costSoFar;

        public Transform GetLastNode()
        {
            return nodes[nodes.Count-1];
        }
    }
}


