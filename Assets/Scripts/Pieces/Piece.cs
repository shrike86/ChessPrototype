using ChessPrototype.Base;
using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.Pieces
{
    /// <summary>
    /// Holds all game logic that is only necessary locally.
    /// </summary>
    public abstract class Piece : NetworkBehaviour
    {
        [Header("References")]
        public Material player1Mat;
        public Material player2Mat;
        [Space]
        [SyncVar]
        public int pieceId;
        [SyncVar]
        public PlayerIndex player;
        [SyncVar]
        public bool isDead;

        public GameManager gameManager;

        public event Action<Piece> OnDeath;

        private void Start()
        {
            gameManager = FindObjectOfType<GameManager>();

            isDead = false;
        }

        public abstract bool ValidateMove(TilePositionName originTilePos, TilePositionName targetTilePos, Tile originTile, Tile targetTile);

        public void SetPieceColour(PlayerIndex player)
        {
            RpcSetPieceColour(player);
        }

        public void SetIsDead(bool isDead)
        {
            CmdSetIsDead(isDead);
            StartCoroutine(UnspawnAfterPeriod());
        }

        private IEnumerator UnspawnAfterPeriod()
        {
            yield return new WaitForSeconds(1.5f);
            OnDeath?.Invoke(this);
            NetworkServer.Destroy(this.gameObject);
        }

        [ClientRpc]
        private void RpcSetPieceColour(PlayerIndex player)
        {
            SkinnedMeshRenderer meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();

            switch (player)
            {
                case PlayerIndex.Player1:
                    meshRenderer.material = player1Mat;
                    break;
                case PlayerIndex.Player2:
                    meshRenderer.material = player2Mat;
                    break;
                default:
                    break;
            }
        }

        [Command(ignoreAuthority = true)]
        public void CmdSetIsDead(bool isDead)
        {
            this.isDead = isDead;
        }

        public Piece GetPieceById(int id)
        {
            Piece piece = null;

            if (id == pieceId)
            {
                piece = this;
            }

            return piece;
        }
    }
}