using ChessPrototype.AI;
using ChessPrototype.Pieces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.Base
{
    public class DamageCollider : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == gameObject)
                return;
            Piece attackingPiece = gameObject.GetComponentInParent<Piece>();
            Piece defendingPiece = other.GetComponentInParent<Piece>();

            if (defendingPiece != null)
            {
                CapsuleCollider col = defendingPiece.GetComponent<CapsuleCollider>();
                col.enabled = false;

                // Later hp and counter attack if not dead.
                AnimHook enemyHook = defendingPiece.GetComponentInChildren<AnimHook>();
                enemyHook.PlayAnimation("Death");

                // If after attack the defending piece did not die.
                // assign the attacking piece back to its origin tile.
                // else set is dead on the defending piece and assign attacking piece to the target tile.

                bool victory = true;

                if (victory)
                {
                    defendingPiece.SetIsDead(true);
                    attackingPiece.AssignAttackingingPiecePosition(victory);
                }
                else
                {
                    attackingPiece.AssignAttackingingPiecePosition(false);
                }

                AIManager ai = GetComponentInParent<AIManager>();
                ai.SubscribeOnDeathEvent(defendingPiece);
            }
        }
    }
}