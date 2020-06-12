using ChessPrototype.AI;
using UnityEngine;

namespace ChessPrototype.Base
{
    [CreateAssetMenu(menuName = "Behaviour/AI/Conditions/Animation End")]
    public class PieceAnimationEndCondition : Condition
    {
        public string targetBool = "isAttacking";

        public override bool CheckCondition(AIManager ai)
        {
            ai.isAttacking = false;
            bool returnValue = !ai.anim.GetBool(targetBool);
            return returnValue;
        }
    }
}