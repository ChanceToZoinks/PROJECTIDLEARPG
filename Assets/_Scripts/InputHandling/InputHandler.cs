using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommandPattern
{
    public class InputHandler : MonoBehaviour
    {
        //this class handles input. for now it just recieves move/jump/attack hotkeys that can be customized
        //when it sees input calls are made to the corresponding logic class to handle what is supposed to happen.
         
        //keys we need, find better way to do this later and add more
        //MUST MAINTAIN THE ENUM AND THE INDIVIDUAL KEYS
        public enum Key
        {
            MoveLeft, MoveRight, Jump, Attack, OpenMenu
        }
        //key to get name as string for inspector and eventually player GUI hotkey changing
        public Key _buttonLeft, _buttonRight, _buttonA, _buttonSpace, _buttonEscape;
        //possible commands
        private Command buttonLeft, buttonRight, buttonA, buttonSpace, buttonEscape;
        //stores commands for replay later (add cool time travel or something)
        public static List<Command> oldCommands = new List<Command>();        

        void Start()
        {
            AllKeySetup();
        }

        //this method just constructs all the keys. use this to "save" player hotkey changes through a GUI
        public void AllKeySetup()
        {
            buttonLeft = CreateCommandInstanceFromEnumName(_buttonLeft);
            buttonRight = CreateCommandInstanceFromEnumName(_buttonRight);
            buttonA = CreateCommandInstanceFromEnumName(_buttonA);
            buttonSpace = CreateCommandInstanceFromEnumName(_buttonSpace);
            buttonEscape = CreateCommandInstanceFromEnumName(_buttonEscape);
        }

        //this method returns an object of type command given the name of a Key
        //this method functions by extracting the name of the passed key as a string and using Activator.CreateInstance and System.Type.GetType to instantiate
        private Command CreateCommandInstanceFromEnumName(Key _keyName)
        {
            return System.Activator.CreateInstance(System.Type.GetType(System.Enum.GetName(typeof(Key), _keyName))) as Command;
        }

        void FixedUpdate()
        {
            //checks in a small circle around the players feets to see if the player is on the ground and sets the appropriate flags -- used for jumping logic
            GlobalsManager.Instance.IS_GROUNDED = Physics2D.OverlapCircle(GlobalsManager.Instance.GROUND_CHECK.position, GlobalsManager.Instance.GROUND_RADIUS, GlobalsManager.Instance.GROUND_LAYER);
            
            HandleMovement();
        }

        void Update()
        {
            HandleJumping();
        }

        //Check if we press a key, if so do what the key is binded to 
        private void HandleMovement()
        {
            if (Input.GetKey(KeyCode.A))
            {
                buttonA.Execute(GlobalsManager.Instance.PLAYER_RIGIDBODY, buttonA);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                buttonLeft.Execute(GlobalsManager.Instance.PLAYER_RIGIDBODY, buttonLeft);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                buttonRight.Execute(GlobalsManager.Instance.PLAYER_RIGIDBODY, buttonRight);
            }
            else if (Input.GetKeyUp(KeyCode.Escape))
            {
                buttonEscape.Execute(GlobalsManager.Instance.PLAYER_RIGIDBODY, buttonEscape);
            }     
        }

        //check if the jump key is pressed
        public void HandleJumping()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                buttonSpace.Execute(GlobalsManager.Instance.PLAYER_RIGIDBODY, buttonSpace);
            }
        }
    }
}
