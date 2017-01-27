using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace LevelEditor.Editors
{
    [CustomEditor(typeof(ScriptedObject)), CanEditMultipleObjects]
    public class ScriptedTriggerObjectEditor : Editor
    {
        public SerializedProperty
            triggerType_Prop,
            valForEndLevel_Prop,
            valForTeleporter_Prop,
            controllable_Prop;

        void OnEnable()
        {
            //setup serialized properties
            triggerType_Prop = serializedObject.FindProperty("scriptedObjectType");
            valForEndLevel_Prop = serializedObject.FindProperty("valForEndLevel");
            valForTeleporter_Prop = serializedObject.FindProperty("valForTeleporter");
            controllable_Prop = serializedObject.FindProperty("controllable");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(triggerType_Prop);

            ScriptedObject.TriggerType trigger = (ScriptedObject.TriggerType)triggerType_Prop.enumValueIndex;

            switch (trigger)
            {
                case ScriptedObject.TriggerType.EndLevelTrigger:
                    EditorGUILayout.PropertyField(controllable_Prop, new GUIContent("controllable"));

                    EditorGUILayout.IntSlider(valForEndLevel_Prop, 0, 10, new GUIContent("valForEndLevel"));
                    break;

                case ScriptedObject.TriggerType.Teleporter:
                    EditorGUILayout.PropertyField(controllable_Prop, new GUIContent("Two-Way?"));

                    EditorGUILayout.IntSlider(valForTeleporter_Prop, 0, 9, new GUIContent("Channel"));
                    break;
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
