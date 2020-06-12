using ChessPrototype.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.AI
{
    [CreateAssetMenu(menuName = "Behaviour/AI/Actions/Attack Action")]
    public class AttackAction : AIStateActions
    {
        public override void Execute(AIManager ai)
        {
            AnimHook animHook = ai.GetComponentInChildren<AnimHook>();
            animHook.PlayAnimation("Attack");
            ai.canAttack = false;
        }
    }
}