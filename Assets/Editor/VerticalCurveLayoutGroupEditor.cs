using UnityEngine;
using UnityEngine.UI;

namespace UnityEditor.UI
{
    [CustomEditor(typeof(VerticalCurveLayoutGroup), true)]
    [CanEditMultipleObjects]
    class VerticalCurveLayoutGroupEditor : HorizontalOrVerticalLayoutGroupEditor
    {
        SerializedProperty m_viewPortProperty;       
        SerializedProperty m_CurveProperty;

        protected override void OnEnable()
        {
            base.OnEnable();
            m_viewPortProperty = serializedObject.FindProperty("viewPort");           
            m_CurveProperty = serializedObject.FindProperty("curve");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();
            EditorGUILayout.PropertyField(m_viewPortProperty, true);            
            EditorGUILayout.PropertyField(m_CurveProperty, true);
            serializedObject.ApplyModifiedProperties();
        }

    }
}
