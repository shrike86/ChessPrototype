using ChessPrototype.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.AI
{
    [CreateAssetMenu(menuName = "Behaviour/AI/Conditions/Piece Movement")]
    public class PieceMovementCondition : Condition
    {
        public override bool CheckCondition(AIManager ai)
        {
            return ai.isStartedMoving && !ai.isStoppedMoving;
        }
    }
}