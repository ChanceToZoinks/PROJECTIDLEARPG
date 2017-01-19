using UnityEngine;
using System.Collections;

namespace CommandPattern
{
    public abstract class Command
    {
        //this class is inherited from allowing customizable commands to be created easily

        //Move and maybe save command
        public abstract void Execute(Rigidbody playerRigid, Command command);

        //Undo an old command
        public virtual void Undo(Rigidbody playerRigid) { }

        //Move
        public virtual void Move(Rigidbody playerRigid) { }

        //Flip the sprite
        public virtual void FlipCharacter(Transform playerTransform) { }

        //Jump
        public virtual void PlayerJump(Rigidbody playerRigid) { }

        //attack
        public virtual void AttackTarget() { }
    }
}

