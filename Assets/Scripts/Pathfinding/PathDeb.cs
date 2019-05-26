using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDeb : MonoBehaviour
{
    public Graph graph;
    public Transform startNode;
    public Transform endNode;

    List<Transform> path;
    
    [ContextMenu("Calculate path")]
    public void CallDijkstra()
    {
        path = Dijkstra.FindPath(graph, startNode, endNode);
    }

    void Update()
    {
        if(path != null)
        {
            for (int i = 0; i < path.Count - 1; i++)
            {
                Debug.DrawLine(path[i].position, path[i+1].position, Color.red);
            }
        }      
    }
}
