using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.AI
{
    [CreateAssetMenu(menuName = "Behaviour/AI/Actions/Update Movement Action")]
    public class UpdateMovementAction : AIStateActions
    {
        public override void Execute(AIManager ai)
        {
            ai.moveAmount = Mathf.Clamp01(Mathf.Abs(ai.agent.velocity.z) + Mathf.Abs(ai.agent.velocity.x));
            ai.anim.SetFloat("forward", ai.moveAmount);
            ai.isMoving = ai.moveAmount > 0;
        }
    }
}