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
        playerRigid.velocity = PlayerGlobalsManager.Instance.PLAYER_JUMP_HEIGHT;
    }
}
