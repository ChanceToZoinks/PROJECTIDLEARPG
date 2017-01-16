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
        //string for inspector and eventually player GUI hotkey changing
        public Key _buttonLeft;
        public Key _buttonRight;
        public Key _buttonA;
        public Key _buttonSpace;   
        //commands
        private Command buttonLeft, buttonRight, buttonA, buttonSpace;
        //stores commands for replay later (add cool time travel or something)
        public static List<Command> oldCommands = new List<Command>();        

        void Start()
        {
            //Bind keys with commands
            //buttonLeft = new MoveLeft();
            //buttonRight = new MoveRight();
            //buttonA = new Attack();
            //buttonSpace = new Jump();

            //here i first let the user pick the type to create an instance of through the use of an enum then convert the string name of the enum to an instance of and object of type command
            buttonLeft = System.Activator.CreateInstance(System.Type.GetType(System.Enum.GetName(typeof(Key), _buttonLeft))) as Command;
            buttonRight = System.Activator.CreateInstance(System.Type.GetType(System.Enum.GetName(typeof(Key), _buttonRight))) as Command;
            buttonA = System.Activator.CreateInstance(System.Type.GetType(System.Enum.GetName(typeof(Key), _buttonA))) as Command;
            buttonSpace = System.Activator.CreateInstance(System.Type.GetType(System.Enum.GetName(typeof(Key), _buttonSpace))) as Command;
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
