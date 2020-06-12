using ChessPrototype.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.AI
{
    [CreateAssetMenu(menuName = "Behaviour/AI/Conditions/Piece Attack")]
    public class PieceAttackCondition : Condition
    {
        public override bool CheckCondition(AIManager ai)
        {
            bool attack = ai.canAttack && !ai.hasAttacked;

            if (attack)
            {
                ai.agent.isStopped = true;
            }

            return attack;
        }
    }
}