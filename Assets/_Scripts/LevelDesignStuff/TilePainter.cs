using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LevelEditor
{
    [ExecuteInEditMode]
    public class TilePainter : MonoBehaviour
    {
        protected TilePainter() { }

        public List<GameObject> valForPrefabHolder;
        public Transform valForLevelPieceParent;

        public enum BlockType { Block, Trigger }
        public BlockType type;

        public bool valForBlockOne;
        public float valForCameraDepth;

        private Ray ray;
        private RaycastHit hit;

        void Awake()
        {
            ray = new Ray();
            hit = new RaycastHit();
        }

        void Update()
        {
            ray = Camera.current.ScreenPointToRay(new Vector3(Camera.current.transform.position.x, Camera.current.transform.position.y, valForCameraDepth));
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                PlaceBlock(type);
            }
        }

        private void PlaceBlock(BlockType _type)
        {
            switch(_type)
            {
                case BlockType.Block:
                    GameObject go = PrefabUtility.InstantiatePrefab(valForPrefabHolder[0]) as GameObject;
                    go.transform.position = ray.GetPoint(valForCameraDepth);
                    break;
                case BlockType.Trigger:
                    Instantiate(valForPrefabHolder[1]);
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
