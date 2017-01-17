using UnityEngine;
using System.Collections;
using CommandPattern;

public class MoveLeft : Command
{
    //Flip command must be tied to move left/right
    Command flip;
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
        if (GlobalsManager.Instance.IS_GROUNDED)
        {
            playerRigid.velocity = -GlobalsManager.Instance.PLAYER_VELOCITY;
        }
        else
        {
            playerRigid.AddForce(-GlobalsManager.Instance.PLAYER_VELOCITY);          
        }
    }

    public override void FlipCharacter(Transform playerTransform)
    {
        if (GlobalsManager.Instance.PLAYER_FACING_RIGHT)
        {
            playerTransform.localScale = new Vector3(playerTransform.localScale.x * -1, playerTransform.localScale.y, playerTransform.localScale.z);
            GlobalsManager.Instance.PLAYER_FACING_RIGHT = !GlobalsManager.Instance.PLAYER_FACING_RIGHT;
        }
    }
}
