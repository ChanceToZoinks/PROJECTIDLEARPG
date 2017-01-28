using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace LevelEditor.Editors
{
    [CustomEditor(typeof(TilePainter)), CanEditMultipleObjects]
    public class LevelEditor : Editor
    {
        public SerializedProperty
            type_Prop,
            valForBlockOne_Prop,
            valForCameraDepth_Prop,
            valForPrefabHolder_Prop,
            valForLevelPieceParent_Prop;

        private void OnEnable()
        {
            type_Prop = serializedObject.FindProperty("type");
            valForBlockOne_Prop = serializedObject.FindProperty("valForBlockOne");
            valForCameraDepth_Prop = serializedObject.FindProperty("valForCameraDepth");
            valForPrefabHolder_Prop = serializedObject.FindProperty("valForPrefabHolder");
            valForLevelPieceParent_Prop = serializedObject.FindProperty("valForLevelPieceParent");

            tilePainter = (TilePainter)target;

            SceneView.onSceneGUIDelegate = EventUpdate;
        }

        TilePainter tilePainter;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(type_Prop);

            tilePainter.type = (TilePainter.BlockType)type_Prop.enumValueIndex;

            tilePainter.valForCameraDepth = EditorGUILayout.Slider("Block Placement Depth", tilePainter.valForCameraDepth, -2.0f, 10.0f); //the depth you will be placing the block at. can be used for some interesting stuff with splines eventually

            switch (tilePainter.type)
            {
                case TilePainter.BlockType.Block:
                    tilePainter.valForBlockOne = EditorGUILayout.Toggle("Basic Block x3", tilePainter.valForBlockOne); //when this is toggled ON you create a 3x3 square of cubes at once centered on mouse
                    EditorGUILayout.PropertyField(valForPrefabHolder_Prop, true);
                    EditorGUILayout.PropertyField(valForLevelPieceParent_Prop);
                    break;
                case TilePainter.BlockType.Trigger:
                    EditorGUILayout.LabelField("Max 10 Per Scene For Now");
                    EditorGUILayout.LabelField("Teleporters: " + GlobalsManager.Instance.TELEPORTER_TRANSFORMS.Count.ToString());
                    EditorGUILayout.PropertyField(valForPrefabHolder_Prop, true);
                    EditorGUILayout.PropertyField(valForLevelPieceParent_Prop);
                    break;
            }

            serializedObject.ApplyModifiedProperties();
        }

        void EventUpdate(SceneView sceneView)
        {
            Event e = Event.current;
        }
    }
}
