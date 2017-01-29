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
            valForLevelPieceParent_Prop,
            valForTeleParent_Prop,
            valForEditingWorld_Prop;

        private void OnEnable()
        {
            type_Prop = serializedObject.FindProperty("type");
            valForBlockOne_Prop = serializedObject.FindProperty("valForBlockOne");
            valForCameraDepth_Prop = serializedObject.FindProperty("valForCameraDepth");
            valForPrefabHolder_Prop = serializedObject.FindProperty("valForPrefabHolder");
            valForLevelPieceParent_Prop = serializedObject.FindProperty("valForLevelPieceParent");
            valForEditingWorld_Prop = serializedObject.FindProperty("valForEditingWorld");
            valForTeleParent_Prop = serializedObject.FindProperty("valForTeleParent");

            tilePainter = (TilePainter)target;

            SceneView.onSceneGUIDelegate = EventUpdate;
        }

        //this is basically update but for the custom editor. put looping stuff in here.
        void OnSceneGUI()
        {
            //remove all nulls
            GlobalsManager.Instance.TELEPORTER_TRANSFORMS.RemoveAll(item => item == null);

            //ok. so when this bool is active it means we can edit. it will spawn the type of block selected in the editor. it locks the focus of the inspector so we can't lose focus and stop editing.
            //if this isn't true the entire thing doesn't activate
            if (tilePainter.valForEditingWorld)
            {
                Selection.activeGameObject = tilePainter.gameObject;
                ActiveEditorTracker.sharedTracker.isLocked = true;
            }
            else
            {
                ActiveEditorTracker.sharedTracker.isLocked = false;
                return;
            }

            //put other hotkeys and shit here. probably write an input handler? maybe just extend the existing InputHandler?
            if (Event.current.type == EventType.mouseDown)
            {
                tilePainter.PlaceBlock(tilePainter.type);
            }
        }

        TilePainter tilePainter;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            //here the user sets the type then based on this selection different things are displayed for the user.
            EditorGUILayout.PropertyField(type_Prop);

            tilePainter.type = (TilePainter.BlockType)type_Prop.enumValueIndex;

            tilePainter.valForCameraDepth = EditorGUILayout.Slider("Block Placement Depth", tilePainter.valForCameraDepth, -2.0f, 10.0f); //the depth you will be placing the block at. can be used for some interesting stuff with splines eventually

            //toggle the controls when you are editing or not
            EditorGUILayout.PropertyField(valForEditingWorld_Prop, new GUIContent("Level Paint Toggle", "Enable to edit, disable to be able to select things normally"));

            switch (tilePainter.type)
            {
                case TilePainter.BlockType.Block:
                    tilePainter.valForBlockOne = EditorGUILayout.Toggle("Basic Block x3", tilePainter.valForBlockOne); //when this is toggled ON you create a 3x3 square of cubes at once centered on mouse
                    EditorGUILayout.PropertyField(valForPrefabHolder_Prop, true);
                    EditorGUILayout.PropertyField(valForLevelPieceParent_Prop);
                    break;
                case TilePainter.BlockType.Teleporter:
                    EditorGUILayout.LabelField("Max 10 Per Scene For Now");
                    EditorGUILayout.LabelField("Teleporters: " + GlobalsManager.Instance.TELEPORTER_TRANSFORMS.Count.ToString());
                    EditorGUILayout.PropertyField(valForPrefabHolder_Prop, true);
                    EditorGUILayout.PropertyField(valForTeleParent_Prop);
                    break;
                case TilePainter.BlockType.Trigger:
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
