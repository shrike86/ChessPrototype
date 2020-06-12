using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.AI
{
    [CreateAssetMenu(menuName = "Behaviour/AI/Actions/Enable Attack Collider Action")]
    public class EnableAttackColliderAction : AIStateActions
    {
        public override void Execute(AIManager ai)
        {
            ai.attackCol.gameObject.SetActive(true);
        }
    }
}