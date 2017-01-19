using UnityEngine;
using System.Collections;
using CommandPattern;

public class MoveLeft : Command
{
    //Called when we press a key
    public override void Execute(Rigidbody playerRigid, Command command)
    {
        //Move the character
        Move(playerRigid);

        //Save the command
        InputHandler.oldCommands.Add(command);
    }

    //Move the character
    public override void Move(Rigidbody playerRigid)
    {
        //flip the character
        FlipCharacter(GlobalsManager.Instance.PLAYER_TRANSFORM);

        if (GlobalsManager.Instance.IS_GROUNDED)
        {
            Toolkit.Instance.AddForceAsFunctionOfVelocity(GlobalsManager.Instance.PLAYER_RIGIDBODY);
        }
    }

    public override void FlipCharacter(Transform playerTransform)
    {
        if (GlobalsManager.Instance.PLAYER_FACING_RIGHT && playerTransform.localScale.x > 0)
        {
            if (playerTransform.localScale.x > 0)
            {
                playerTransform.localScale = new Vector3(playerTransform.localScale.x * -1, playerTransform.localScale.y, playerTransform.localScale.z);
            }
            GlobalsManager.Instance.PLAYER_FACING_RIGHT = !GlobalsManager.Instance.PLAYER_FACING_RIGHT;
        }
    }
}
