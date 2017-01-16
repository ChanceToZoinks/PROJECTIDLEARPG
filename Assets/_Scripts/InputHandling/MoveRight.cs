using UnityEngine;
using System.Collections;
using CommandPattern;

public class MoveRight : Command
{
    //Called when we press a key
    public override void Execute(Rigidbody2D playerRigid, Command command)
    {
        //Move the box
        Move(playerRigid);

        //Save the command
        InputHandler.oldCommands.Add(command);
    }

    //Move the box
    public override void Move(Rigidbody2D playerRigid)
    {
        playerRigid.velocity = PlayerGlobalsManager.Instance.PLAYER_VELOCITY;
    }
}
