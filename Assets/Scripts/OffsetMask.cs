using UnityEngine.Sprites;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.UI;
using UnityEditor;
[ExecuteInEditMode]
public class OffsetMask : Image
{
    public Vector3 leftTop;
    public Vector3 rightTop;
    public Vector3 leftDown;
    public Vector3 rightDown;
    public float offsetValue;//偏移值
    public PolygonCollider2D polygonCollider2D;//点击区域
    protected override void Awake()
    {
        base.Awake();
        RectTransform rectTransform = GetComponent<RectTransform>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        float width = rectTransform.sizeDelta.x;
        float heigh = rectTransform.sizeDelta.y;
        
        leftDown = new Vector3(-width / 2, -heigh / 2);//A
        leftTop = new Vector3(-width / 2 + offsetValue, heigh / 2);//B
        rightTop = new Vector3(width / 2, heigh / 2);//D   
        rightDown = new Vector3(rightTop.x - leftTop.x + leftDown.x, -heigh / 2);//C             

        polygonCollider2D.points = new Vector2[4]
        {
            leftDown,leftTop,rightTop,rightDown
        };
    }
    protected override void OnPopulateMesh(VertexHelper toFill)
    {
        base.OnPopulateMesh(toFill);
        toFill.Clear();

        toFill.AddVert(leftDown, Color.white, Vector2.zero);
        toFill.AddVert(leftTop, Color.white, Vector2.zero);
        toFill.AddVert(rightTop, Color.white, Vector2.zero);
        toFill.AddVert(rightDown, Color.white, Vector2.zero);

        toFill.AddTriangle(0, 1, 2);
        toFill.AddTriangle(0, 2, 3);
    }

    public override bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
    {       
        Vector3[] ver = workerMesh.vertices;
        Vector3 point;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, screenPoint, eventCamera,out point);
        return polygonCollider2D.OverlapPoint(point);        
    }
}

