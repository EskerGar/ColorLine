using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public  class Bezier : MonoBehaviour
{
    [SerializeField] private Transform point;
    [SerializeField] private List<Transform> points;
    

    private int CurveCount => (points.Count - 1) / 3;

    public void AddCurve()
    {
        var lastPoint = points[points.Count - 1];
        for (int i = 0; i < 3; i++)
        {
            var newPoint = Instantiate(point);
            newPoint.position = lastPoint.position + new Vector3(1f, 0);
            points.Add(newPoint);
        }
        EnforceMode(points.Count - 4);
    }
    
    public Vector3 GetMovePoint(float t)
    {
        int i;
        if (t >= 1f) {
            t = 1f;
            i = points.Count - 4;
        }
        else {
            t = Mathf.Clamp01(t) * CurveCount;
            i = (int)t;
            t -= i;
            i *= 3;
        }
        return GetPoint(points[i].position, points[i + 1].position, points[i + 2].position, points[i + 3].position, t);
    }

    public Vector3 GetVelocity(float t)
    {
        int i;
        if (t >= 1f) {
            t = 1f;
            i = points.Count - 4;
        }
        else {
            t = Mathf.Clamp01(t) * CurveCount;
            i = (int)t;
            t -= i;
            i *= 3;
        }

        return GetFirstDerivative(points[i].position, points[i + 1].position, points[i + 2].position,
            points[i + 3].position, t);
    }

    private void EnforceMode(int index)
    {
        var modeIndex = (index + 1) / 3;
        if (modeIndex == 0 || modeIndex == points.Count - 1) return;
        var middleIndex = modeIndex * 3;
        int fixedIndex;
        int enforcedIndex;
        if (index <= middleIndex) 
        {
            fixedIndex = middleIndex - 1;
            enforcedIndex = middleIndex + 1;
        }
        else 
        {
            fixedIndex = middleIndex + 1;
            enforcedIndex = middleIndex - 1;
        }
        var middle = points[middleIndex].position;
        var enforcedTangent = middle - points[fixedIndex].position;
        enforcedTangent = enforcedTangent.normalized * Vector3.Distance(middle, points[enforcedIndex].position);
        points[enforcedIndex].position = middle + enforcedTangent;
    }

    private Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {

        var oneMinusT = 1 - t;
        return
            Mathf.Pow(oneMinusT, 3) * p0 +
            p1 * (3 * Mathf.Pow(oneMinusT, 2) * t) +
            3 * oneMinusT * Mathf.Pow(t, 2) * p2 +
            Mathf.Pow(t, 3) * p3;
    }
    
    private Vector3 GetFirstDerivative(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        var oneMinusT = 1 - t;
        return
            3 * Mathf.Pow(oneMinusT, 2) * (p1 - p0) +
            6 * oneMinusT * t * (p2 - p1) +
            3 * Mathf.Pow(t, 2) * (p3 - p2);
    }
    
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        var p0 = points[0].position;
        for (var i = 1; i < points.Count; i += 3)
        {
            EnforceMode(i);
            var p1 = points[i].position;
            var p2 = points[i + 1].position;
            var p3 = points[i + 2].position;
            Handles.DrawLine(p0, p1);
            Handles.DrawLine(p2, p3);

            Handles.DrawBezier(p0, p3, p1, p2, Color.red, null, 2f);
            p0 = p3;

        }
    }
#endif
}
