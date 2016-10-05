
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using System.Collections;

public class PhysicalParticle : MonoBehaviour
{
    public Color MyColor;
    public Vector3 StartPos;
    public Vector3 StartSpeed;
    public Vector3 CurPos;
    public Vector3 CurSpeed;

    public LineRenderer MyLine;
    private List<Vector3> _points;
 
    public Space MySpace;

    public float stepTime;
    private float dTime;

    private bool _isStop;
    public bool IsStart = false;

    void Start()
    {
        MyColor.r = Random.Range(0f, 1f);
        MyColor.g = Random.Range(0f, 1f);
        MyColor.b = Random.Range(0f, 1f);
        
        //MyLine.SetColors(MyColor, MyColor);
        stepTime = 0.07f;
        _isStop = false;
        _points = new List<Vector3>();
        CurPos = StartPos;
        CurSpeed = StartSpeed;
        NextRender();
    }
    void Update()
    {
        if (!IsStart && _isStop) return;
        dTime += Time.deltaTime;
        if (stepTime < dTime)
        {
            dTime -= stepTime;
            CurPos = MySpace.CalcPos(CurPos, CurSpeed, stepTime);
            CurSpeed = MySpace.CalcSpeed(CurSpeed, stepTime);
            NextRender();
        }
        
    }
    void NextRender()
    {
        _points.Add(MySpace.CalcWindowPos( CurPos));
        MyLine.SetVertexCount(_points.Count);
        MyLine.SetPositions(_points.ToArray());
    }
    public void Stop()
    {
        _isStop = true;
    }
}

