using UnityEngine;
using System.Collections;
using CommandPattern;

public class Attack : Command
{
    //Called when we press a key
    public override void Execute(Rigidbody2D playerRigid, Command command)
    {
        //Nothing will happen if we press this key
        AttackTarget();
    }

    //attacks the target from a list using the index passed to it
    public override void AttackTarget()
    {
        //put attack here.
        Debug.Log("Player attacked");
    }
}
