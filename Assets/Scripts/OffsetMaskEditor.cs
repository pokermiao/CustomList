using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

[CustomEditor(typeof(OffsetMask))]
public class OffsetMaskEditor : ImageEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        OffsetMask customMask = (OffsetMask)target;
        /*customMask.leftTop = EditorGUILayout.Vector3Field("leftTop", customMask.leftTop);
        customMask.rightTop = EditorGUILayout.Vector3Field("rightTop", customMask.rightTop);
        customMask.leftDown = EditorGUILayout.Vector3Field("leftDown", customMask.leftDown);
        customMask.rightDown = EditorGUILayout.Vector3Field("rightDown", customMask.rightDown);*/
        customMask.color = EditorGUILayout.ColorField("color", customMask.color);
        customMask.offsetValue = EditorGUILayout.FloatField("offsetValue", customMask.offsetValue);
    }
}
