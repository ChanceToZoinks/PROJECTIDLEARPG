using UnityEngine;
using System.Collections;
using CommandPattern;
using System;

public class Jump : Command
{
    public override void Execute(Rigidbody playerRigid, Command command)
    {
        //players jumps by using velocity applied to their rigidbody.
        PlayerJump(playerRigid);

        //Save the command
        InputHandler.oldCommands.Add(command);
    }

    public override void PlayerJump(Rigidbody playerRigid)
    {
        if (GlobalsManager.Instance.IS_GROUNDED)
        {
            Debug.Log("jump");
            playerRigid.AddForce(GlobalsManager.Instance.PLAYER_JUMP_FORCE);
        }
    }
}
