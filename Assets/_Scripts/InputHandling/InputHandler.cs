using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommandPattern
{
    public class InputHandler : MonoBehaviour
    {
        //keys we need, find better way to do this later and add more
        private Command buttonLeft, buttonRight, buttonA;
        //stores commands for replay later (add cool time travel or something)
        public static List<Command> oldCommands = new List<Command>();        

        void Start()
        {
            //Bind keys with commands
            buttonLeft = new MoveLeft();
            buttonRight = new MoveRight();
            buttonA = new Attack();         
        }

        void Update()
        {
            HandleInput();
        }

        //Check if we press a key, if so do what the key is binded to 
        public void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                buttonA.Execute(PlayerGlobalsManager.Instance.PLAYER_RIGIDBODY, buttonA);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                buttonLeft.Execute(PlayerGlobalsManager.Instance.PLAYER_RIGIDBODY, buttonLeft);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                buttonRight.Execute(PlayerGlobalsManager.Instance.PLAYER_RIGIDBODY, buttonRight);
            }          
        }
    }
}
