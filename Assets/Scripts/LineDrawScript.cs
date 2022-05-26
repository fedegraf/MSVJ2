using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawScript : MonoBehaviour
{
    Vector3 mousePressDownPos;
    Vector3 mousePos;
    bool isShoot;



    LineRenderer line;
    Vector3 direction;
    bool drawLine;
    Vector3 aimDot;
    void Start()
    {
        isShoot = false;
        drawLine = false;
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = transform.position - worldMousePosition;

        DrawLine();    // show trajectory line
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
        drawLine = true;
    }

    private void OnMouseDrag()
    {
        mousePos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        drawLine = false;
        isShoot = true;
    }

    public void DrawLine()
    {
        if (drawLine && !isShoot)
        {
            
            Vector3 force = mousePressDownPos - mousePos;
            int segmentCount = 6;     // lenght of line
            Vector2[] segments = new Vector2[segmentCount];
            
            
            segments[0] = transform.position;


            Vector2 segVelocity = new Vector2(Mathf.Clamp(force.x, force.x, 350), Mathf.Clamp(force.y, force.y, 350)) / 16f;

            for (int i = 1; i < segmentCount; i++)
            {
                float time = i * Time.fixedDeltaTime * 5;
                segments[i] = segments[0] + segVelocity * time + 0.5f * Physics2D.gravity * Mathf.Pow(time, 2);
            }

            line.positionCount = segmentCount;
            for (int i = 0; i < segmentCount; i++)
                line.SetPosition(i, segments[i]);

            //line.SetPosition(0, transform.position);         
            //line.SetPosition(1, direction);         
            line.enabled = true;
        }
        else
        {
            line.enabled = false;
        }
    }
}
