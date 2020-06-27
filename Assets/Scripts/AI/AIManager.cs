using ChessPrototype.Base;
using ChessPrototype.Pieces;
using Mirror;
using UnityEngine;
using UnityEngine.AI;

namespace ChessPrototype.AI
{
    public class AIManager : NetworkBehaviour
    {
        public NavMeshAgent agent;
        public Animator anim;
        public AttackCollider attackCol;
        public NetworkGameManager network;

        public bool isStartedMoving;
        public bool isMoving;
        public bool isStoppedMoving;
        public bool isAttacking;
        public bool canAttack;
        public bool hasAttacked;

        [SyncVar]
        public float moveAmount;
        public Vector3 targetDestination;
        public Vector3 originalFacingDirection;

        public State currentState;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponentInChildren<Animator>();
            attackCol = GetComponentInChildren<AttackCollider>(true);
            network = FindObjectOfType<NetworkGameManager>();

            isMoving = false;
            isAttacking = false;
            canAttack = false;
            hasAttacked = false;
            isStartedMoving = false;
            isStoppedMoving = false;

        }

        private void Update()
        {
            if (currentState != null)
                currentState.Tick(this);

            if (moveAmount == 0 && anim.GetFloat("forward") > 0)
            {
                anim.SetFloat("forward", 0);
            }
        }

        public void SubscribeOnDeathEvent(Piece dyingPiece)
        {
            dyingPiece.OnDeath += ResumeMovementAfterCombat;
        }

        public void EndTurn()
        {
            if (!isServer)
                return;

            network.turnManager.IncrementTurn();
        }

        private void ResumeMovementAfterCombat(Piece dyingPiece)
        {
            agent.isStopped = false;
            isStartedMoving = true;
            dyingPiece.OnDeath -= ResumeMovementAfterCombat;
        }

        [ClientRpc]
        public void RpcSetDestination(Vector3 targetDestination)
        {
            originalFacingDirection = transform.eulerAngles;
            isStartedMoving = true;
            this.targetDestination = targetDestination;
            agent.SetDestination(targetDestination);
        }
    }
}