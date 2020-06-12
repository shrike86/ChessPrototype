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

            Piece defendingPiece = other.GetComponentInParent<Piece>();

            if (defendingPiece != null)
            {
                CapsuleCollider col = defendingPiece.GetComponent<CapsuleCollider>();
                col.enabled = false;

                // Later hp and counter attack if not dead.
                AnimHook enemyHook = defendingPiece.GetComponentInChildren<AnimHook>();
                enemyHook.PlayAnimation("Death");

                defendingPiece.SetIsDead(true);

                AIManager ai = GetComponentInParent<AIManager>();
                ai.SubscribeOnDeathEvent(defendingPiece);
            }
        }


    }
}