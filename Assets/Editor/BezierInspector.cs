using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Bezier))]
public class BezierInspector : Editor
{
    public override void OnInspectorGUI () {
        DrawDefaultInspector();
        var spline = target as Bezier;
        if (GUILayout.Button("Add Curve")) {
            Undo.RecordObject(spline, "Add Curve");
            spline.AddCurve();
            EditorUtility.SetDirty(spline);
        }
    }
}
