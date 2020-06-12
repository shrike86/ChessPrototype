using ChessPrototype.AI;
using ChessPrototype.Pieces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.Base
{
    public class AttackCollider : MonoBehaviour
    {
        public AIManager aIManager;

        private void Start()
        {
            aIManager = GetComponentInParent<AIManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            Piece otherPiece = other.GetComponentInParent<Piece>();

            if (otherPiece != null)
            {
                aIManager.canAttack = true;
            }
        }
    }
}