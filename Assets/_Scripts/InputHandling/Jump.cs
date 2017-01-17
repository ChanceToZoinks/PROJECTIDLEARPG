using UnityEngine;
using System.Collections;
using CommandPattern;
using System;

public class Jump : Command
{
    public override void Execute(Rigidbody2D playerRigid, Command command)
    {
        //players jumps by using velocity applied to their rigidbody.
        PlayerJump(playerRigid);

        //Save the command
        InputHandler.oldCommands.Add(command);
    }

    public override void PlayerJump(Rigidbody2D playerRigid)
    {
        if (GlobalsManager.Instance.IS_GROUNDED)
        {
            playerRigid.AddForce(GlobalsManager.Instance.PLAYER_JUMP_FORCE);
        }
    }
}
