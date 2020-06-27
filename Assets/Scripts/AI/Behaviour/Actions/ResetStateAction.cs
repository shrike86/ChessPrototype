using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.AI
{
    [CreateAssetMenu(menuName = "Behaviour/AI/Actions/Reset State Action")]
    public class ResetStateAction : AIStateActions
    {
        public override void Execute(AIManager ai)
        {
            ai.moveAmount = 0;
            ai.isMoving = false;
            ai.isStartedMoving = false;
            ai.isStoppedMoving = false;
            ai.anim.SetFloat("forward", 0);
        }
    }
}