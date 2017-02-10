using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Line))]
public class LineInspector : Editor
{

	void OnSceneGUI()
    {
        Line line = target as Line;
        Transform handleTransform = line.transform;
        Quaternion handleRotation = Tools.pivotRotation == PivotRotation.Local ? handleTransform.rotation : Quaternion.identity;
        Vector3 point0 = handleTransform.TransformPoint(line.point0);
        Vector3 point1 = handleTransform.TransformPoint(line.point1);

        Handles.color = Color.white;
        Handles.DrawLine(line.point0, line.point1);
        Handles.DoPositionHandle(point0, handleRotation);
        Handles.DoPositionHandle(point1, handleRotation);

        EditorGUI.BeginChangeCheck();
        point0 = Handles.DoPositionHandle(point0, handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(line, "Move Point");
            EditorUtility.SetDirty(line);
            line.point0 = handleTransform.InverseTransformPoint(point0);
        }
        EditorGUI.BeginChangeCheck();
        point1 = Handles.DoPositionHandle(point1, handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(line, "Move Point");
            EditorUtility.SetDirty(line);
            line.point1 = handleTransform.InverseTransformPoint(point1);
        }
    }
}
