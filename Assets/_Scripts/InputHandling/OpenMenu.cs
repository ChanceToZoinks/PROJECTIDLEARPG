using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommandPattern;

public class OpenMenu : Command
{
    public override void Execute(Rigidbody2D playerRigid, Command command)
    {
        //players jumps by using velocity applied to their rigidbody.
        PauseGame();

        //Save the command
        InputHandler.oldCommands.Add(command);
    }

    public override void PauseGame()
    {
        Debug.Log("Game Paused");
        //open pause menu here
        GlobalTriggerables.Instance.OpenCloseMenu();
    }
}
