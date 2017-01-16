using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommandPattern
{
    public class InputHandler : MonoBehaviour
    {
        //keys we need, find better way to do this later and add more
        //MUST MAINTAIN THE ENUM AND THE INDIVIDUAL KEYS
        public enum Key
        {
            MoveLeft, MoveRight, Jump, Attack
        };
        //key to get name as string for inspector and eventually player GUI hotkey changing
        public Key _buttonLeft, _buttonRight, _buttonA, _buttonSpace;
        //commands
        private Command buttonLeft, buttonRight, buttonA, buttonSpace;
        //stores commands for replay later (add cool time travel or something)
        public static List<Command> oldCommands = new List<Command>();        

        void Start()
        {
            AllKeySetup();
        }

        public void AllKeySetup()
        {
            buttonLeft = CreateCommandInstanceFromEnum(_buttonLeft);
            buttonRight = CreateCommandInstanceFromEnum(_buttonRight);
            buttonA = CreateCommandInstanceFromEnum(_buttonA);
            buttonSpace = CreateCommandInstanceFromEnum(_buttonSpace);
        }

        private Command CreateCommandInstanceFromEnum(Key _keyName)
        {
            return System.Activator.CreateInstance(System.Type.GetType(System.Enum.GetName(typeof(Key), _keyName))) as Command;
        }

        void Update()
        {
            HandleInput();
        }

        //Check if we press a key, if so do what the key is binded to 
        public void HandleInput()
        {
            if (Input.GetKey(KeyCode.A))
            {
                buttonA.Execute(PlayerGlobalsManager.Instance.PLAYER_RIGIDBODY, buttonA);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                buttonLeft.Execute(PlayerGlobalsManager.Instance.PLAYER_RIGIDBODY, buttonLeft);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                buttonRight.Execute(PlayerGlobalsManager.Instance.PLAYER_RIGIDBODY, buttonRight);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                buttonSpace.Execute(PlayerGlobalsManager.Instance.PLAYER_RIGIDBODY, buttonSpace);
            }          
        }
    }
}
