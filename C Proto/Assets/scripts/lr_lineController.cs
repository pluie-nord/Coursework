using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lr_lineController : MonoBehaviour
{
    private LineRenderer lr;
    private Transform[] points;

    private Transform endPos;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void SetLine(Transform[] points)
    {
        this.points = points;
        lr.positionCount = points.Length+1;
        
    }

    private void Update()
    {
        for(int i=0; i<points.Length; i++)
        {
            lr.SetPosition(i, points[i].position);
        }

    }

}
