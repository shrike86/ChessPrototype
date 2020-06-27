using ChessPrototype.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.AI
{
    [CreateAssetMenu(menuName = "Behaviour/AI/Conditions/Piece Arrived")]
    public class PieceArrivedCondition : Condition
    {
        public override bool CheckCondition(AIManager ai)
        {
            bool arrived = false;
            if (ai.agent.hasPath || ai.agent.velocity.sqrMagnitude > 0)
                return arrived;

            if (ai.agent.remainingDistance <= ai.agent.stoppingDistance)
            {
                if (!ai.agent.hasPath || ai.agent.velocity.sqrMagnitude == 0)
                {
                    ai.isStoppedMoving = true;
                    ai.targetDestination = Vector3.zero;
                    AfterMovingFaceOriginalDirection(ai);
                    arrived = true;
                    ai.EndTurn();
                }
            }

            return arrived;
        }

        private void AfterMovingFaceOriginalDirection(AIManager ai)
        {
            float angle = Vector3.Angle(ai.originalFacingDirection, ai.transform.forward);

            if (angle >= 5f)
            {
                ai.transform.rotation = Quaternion.Slerp(ai.transform.rotation, Quaternion.Euler(ai.originalFacingDirection.x, ai.originalFacingDirection.y, ai.originalFacingDirection.z), 1);
            }
        }
    }
}