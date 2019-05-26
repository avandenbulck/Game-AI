using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    public ApplyPathFinding pathFindingAgent;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 positionClicked = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pathFindingAgent.GoTo(positionClicked);
        }
    }
}
