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
            valForFloatyAir_Prop,
            controllable_Prop,
            walkIn_Prop;

        void OnEnable()
        {
            //setup serialized properties
            triggerType_Prop = serializedObject.FindProperty("scriptedObjectType");
            valForEndLevel_Prop = serializedObject.FindProperty("valForEndLevel");
            valForTeleporter_Prop = serializedObject.FindProperty("valForTeleporter");
            valForFloatyAir_Prop = serializedObject.FindProperty("valForFloatyAir");
            controllable_Prop = serializedObject.FindProperty("controllable");
            walkIn_Prop = serializedObject.FindProperty("walkIn");
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
                    break;

                case ScriptedObject.TriggerType.Teleporter:
                    EditorGUILayout.PropertyField(controllable_Prop, new GUIContent("Controllable?"));
                    EditorGUILayout.PropertyField(walkIn_Prop, new GUIContent("Walk In?"));

                    EditorGUILayout.IntSlider(valForTeleporter_Prop, 0, 9, new GUIContent("Target"));
                    break;
                case ScriptedObject.TriggerType.FloatyAir:
                    EditorGUILayout.PropertyField(controllable_Prop, new GUIContent("On?"));

                    EditorGUILayout.IntSlider(valForFloatyAir_Prop, 100, 800, new GUIContent("Strength"));
                    break;

            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
