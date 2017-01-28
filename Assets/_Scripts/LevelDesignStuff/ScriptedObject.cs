using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor
{
    public class ScriptedObject : MonoBehaviour
    {
        //this class is the "trigger class" it allows me to use my custom editor that's very much WIP still to create teleporters and goals easily.
        //settings are set in the custom editor that allow me to link teleporters via channels and eventually to have a generic trigger that just makes something happen
        //think "step on this pressure pad and an explosion" or something
        public enum TriggerType { EndLevelTrigger, Teleporter, FloatyAir }

        public TriggerType scriptedObjectType = TriggerType.Teleporter;

        public int valForEndLevel;
        public int valForTeleporter; //channel
        public int valForFloatyAir;

        public bool controllable;
        public bool walkIn;

        private bool playerInRange = false;
        private bool justTeleported = false;

        void Awake()
        {
            if (!GlobalsManager.Instance.TELEPORTER_TRANSFORMS.Contains(this.transform))
            {
                GlobalsManager.Instance.TELEPORTER_TRANSFORMS.Add(this.transform);
            }
        }

        void Update()
        {
            switch (scriptedObjectType)
            {
                case TriggerType.Teleporter:
                    if (playerInRange && this.controllable)
                    {
                        if (this.walkIn && !justTeleported)
                        {
                            Teleport(GlobalsManager.Instance.PLAYER_TRANSFORM, GlobalsManager.Instance.TELEPORTER_TRANSFORMS[valForTeleporter]);
                        }
                        else if (Input.GetKeyUp(KeyCode.UpArrow) && !this.walkIn)
                        {
                            Teleport(GlobalsManager.Instance.PLAYER_TRANSFORM, GlobalsManager.Instance.TELEPORTER_TRANSFORMS[valForTeleporter]);
                        }
                    }
                    break;
                case TriggerType.EndLevelTrigger:
                    if (playerInRange && this.controllable)
                    {
                        Debug.Log("You beat the level!");
                        //eventually add an animation and stuff here and switch to the next level not just quit
                        GlobalTriggerables.Instance.Quit();
                    }
                    break;
                case TriggerType.FloatyAir:
                    if (playerInRange && this.controllable)
                    {
                        GlobalsManager.Instance.PLAYER_ON_FLOATY_AIR = true;
                        FloatyAir(GlobalsManager.Instance.PLAYER_RIGIDBODY);
                    }
                    break;
            }

        }

        void Teleport(Transform transToMove, Transform to)
        {
            Debug.Log("Teleport");
            transToMove.position = to.position;
            GlobalsManager.Instance.TELEPORTER_MOST_RECENT = to; //this line makes it impossible to get stuck in a chain of teleporting back and forth in combo with the stuff in OnTriggerExit2D
            justTeleported = true;
        }

        void FloatyAir(Rigidbody2D playerRB)
        {
            playerRB.AddForce(Vector2.up * valForFloatyAir * 1.0f / Mathf.Abs(GlobalsManager.Instance.PLAYER_TRANSFORM.position.y - this.transform.position.y) * Time.deltaTime, ForceMode2D.Force);
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                playerInRange = true;
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                playerInRange = false;
                if (GlobalsManager.Instance.TELEPORTER_MOST_RECENT == this.transform)
                {
                    justTeleported = false;
                }
            }
            GlobalsManager.Instance.PLAYER_ON_FLOATY_AIR = false;
        }
    }
}
