using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor
{
    public class ScriptedObject : MonoBehaviour
    {
        public enum TriggerType { EndLevelTrigger, Teleporter}

        public TriggerType scriptedObjectType;

        public int valForEndLevel;
        public int valForTeleporter;
        public ScriptedObject linkedTeleporter;

        public bool controllable;

        void Start()
        {
            
        }

        void Update()
        {
            
        }
    }
}
