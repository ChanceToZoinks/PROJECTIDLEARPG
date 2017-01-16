using UnityEngine;
using System.Collections;

namespace CommandPattern
{
    public abstract class Command
    {
        //Move and maybe save command
        public abstract void Execute(Rigidbody2D playerRigid, Command command);

        //Undo an old command
        public virtual void Undo(Rigidbody2D playerRigid) { }

        //Move
        public virtual void Move(Rigidbody2D playerRigid) { }

        //Jump
        public virtual void PlayerJump(Rigidbody2D playerRigid) { }

        //attack
        public virtual void AttackTarget() { }
    }
}

