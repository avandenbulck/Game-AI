using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour
{
    public Transform fromNode;
    public Transform toNode;

    public void OnDrawGizmos()
    {
        if(fromNode != null && toNode != null)
            Gizmos.DrawLine(fromNode.position, toNode.position);
    }
}