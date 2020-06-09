using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineRenderer : MonoBehaviour
{
    public Transform startPoint;
    public Transform Point1;
    public Transform Point2;
    public Transform Point3;
    public Transform Point4;
    public Transform Point5;
    public Transform Point6;
    public Transform Point7;
    public Transform Point8;
    public Transform Point9;
    public Transform Point10;
    public Transform Point11;
    public Transform Point12;
    public Transform Point13;
    public Transform Point14;
    public Transform Point15;
    public Transform Point16;
    public Transform Point17;
    public Transform Point18;
    public Transform Point19;
    public Transform Point20;
    public Transform Point21;
    public Transform Point22;
    public Transform Point23;
    public Transform Point24;
    public Transform Point25;
    public Transform Point26;
    public Transform Point27;
    public Transform Point28;
    public Transform Point29;
    
    // Update is called once per frame
    void Update()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        {
            lineRenderer.SetPosition(0,startPoint.position);
            lineRenderer.SetPosition(1, Point1.position);
            lineRenderer.SetPosition(2, Point2.position);
            lineRenderer.SetPosition(3, Point3.position);
            lineRenderer.SetPosition(4, Point4.position);
            lineRenderer.SetPosition(5, Point5.position);
            lineRenderer.SetPosition(6, Point6.position);
            lineRenderer.SetPosition(7, Point7.position);
            lineRenderer.SetPosition(8, Point8.position);
            lineRenderer.SetPosition(9, Point9.position);
            lineRenderer.SetPosition(10, Point10.position);
            lineRenderer.SetPosition(11, Point11.position);
            lineRenderer.SetPosition(12, Point12.position);
            lineRenderer.SetPosition(13, Point13.position);
            lineRenderer.SetPosition(14, Point14.position);
            lineRenderer.SetPosition(15, Point15.position);
            lineRenderer.SetPosition(16, Point16.position);
            lineRenderer.SetPosition(17, Point17.position);
            lineRenderer.SetPosition(18, Point18.position);
            lineRenderer.SetPosition(19, Point19.position);
            lineRenderer.SetPosition(20, Point20.position);
            lineRenderer.SetPosition(21, Point21.position);
            lineRenderer.SetPosition(22, Point22.position);
            lineRenderer.SetPosition(23, Point23.position);
            lineRenderer.SetPosition(24, Point24.position);
            lineRenderer.SetPosition(25, Point25.position);
            lineRenderer.SetPosition(26, Point26.position);
            lineRenderer.SetPosition(27, Point27.position);
            lineRenderer.SetPosition(28, Point28.position);
            lineRenderer.SetPosition(29, Point29.position);
        }
    }
}
