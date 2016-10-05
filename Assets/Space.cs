using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using System.Collections;

public class Space : MonoBehaviour
{
    private Camera _camera;

    public Vector3 Acceleration = new Vector3(0, -9.8f, 0);
    public Vector3 Window = new Vector3(400, 250, 0);
    public float SpeedWorldTime = 1f;
    public float MyTime = 0f;

    void Start()
    {
        _camera = FindObjectOfType<Camera>();
    }
    void Update()
    {
        MyTime += Time.deltaTime*SpeedWorldTime;
    }
    public Vector3 CalcPos(Vector3 pos, Vector3 speed, float dTime)
    {
        dTime *= SpeedWorldTime;
        return pos + speed*dTime + Acceleration*dTime*dTime/2;
    }
    public Vector3 CalcSpeed(Vector3 speed, float dTime)
    {
        dTime *= SpeedWorldTime;
        return speed + Acceleration * dTime;
    }
    public Vector3 CalcWindowPos(Vector3 pos)
    {
        Vector3 p;
        p.x = pos.x / Window.x;
        p.y = pos.y / Window.y;
        p.z = 0;

        //Debug.Log(p.ToString());
       p.x -= 0.5f;
         p.y -= 0.5f;
          p.x *= 20f;
         p.y *= 9f;
        //p = Camera.main.WorldToScreenPoint(p);
        return p;
    }
}

