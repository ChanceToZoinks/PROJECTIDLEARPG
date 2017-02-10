using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LevelEditor
{
    //this has to execute in edit mode so it doesn't lose references to GlobalsManager
    [ExecuteInEditMode]
    public class TilePainter : MonoBehaviour
    {
        protected TilePainter() { }

        public List<GameObject> valForPrefabHolder;
        public Transform valForLevelPieceParent;
        public Transform valForTeleParent;

        public enum BlockType { Block, Trigger, Teleporter }
        public BlockType type;

        public bool valForBlockOne;
        public float valForCameraDepth;

        public bool valForEditingWorld;

        public void PlaceBlock(BlockType _type, Vector3 _placementLocation)
        {
            //TODO: add raycasting so objects get placed at mouse position. also deleting/undo
            Debug.Log("Block Placed" + _type);
            GameObject obj;
            switch (_type)
            {
                case BlockType.Block:
                    obj = Instantiate(valForPrefabHolder[0], _placementLocation, Quaternion.identity, valForLevelPieceParent)  as GameObject;
                    if (!GlobalsManager.Instance.TELEPORTER_TRANSFORMS.Contains(obj.transform))
                    {
                        GlobalsManager.Instance.TELEPORTER_TRANSFORMS.Add(obj.transform);
                    }

                    break;
                case BlockType.Teleporter:
                    obj = Instantiate(valForPrefabHolder[1], _placementLocation, Quaternion.identity, valForTeleParent) as GameObject;
                    if (!GlobalsManager.Instance.TELEPORTER_TRANSFORMS.Contains(obj.transform))
                    {
                        GlobalsManager.Instance.TELEPORTER_TRANSFORMS.Add(obj.transform);
                    }

                    break;
                case BlockType.Trigger:
                    obj = Instantiate(valForPrefabHolder[2], _placementLocation, Quaternion.identity, valForLevelPieceParent) as GameObject;
                    if (!GlobalsManager.Instance.TELEPORTER_TRANSFORMS.Contains(obj.transform))
                    {
                        GlobalsManager.Instance.TELEPORTER_TRANSFORMS.Add(obj.transform);
                    }

                    break;
            }
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            for (int i = -5; i <= 5; i++)
            {
                Gizmos.DrawLine(new Vector3(-50.0f, Screen.height, valForCameraDepth), new Vector3(50.0f, 0.0f, valForCameraDepth));
            }
        }
    }
}
