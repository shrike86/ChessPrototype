using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.AI
{
    [CreateAssetMenu(menuName = "Behaviour/AI/Actions/Disable Attack Collider Action")]
    public class DisableAttackColliderAction : AIStateActions
    {
        public override void Execute(AIManager ai)
        {
            ai.attackCol.gameObject.SetActive(false);
        }
    }
}