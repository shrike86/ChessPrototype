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
        public TilePositionName currentTile;
        [SyncVar]
        public TilePositionName previousTile;
        [SyncVar]
        public TilePositionName newTile;
        [SyncVar]
        public bool isDead;

        public GameManager gameManager;

        public event Action<Piece> OnDeath;

        private void Start()
        {
            gameManager = FindObjectOfType<GameManager>();

            isDead = false;
        }

        public abstract bool ValidateMove(TilePositionName originTilePos, TilePositionName targetTilePos, Tile originTile, Tile targetTile, bool isHighlightValidation);

        public void SetPieceColour(PlayerIndex player)
        {
            RpcSetPieceColour(player);
        }

        public void SetIsDead(bool isDead)
        {
            if (!isServer)
                return;

            TargetClearHighlightedTilesOnDeath(GetComponent<NetworkIdentity>().connectionToClient);

            this.isDead = true;
            StartCoroutine(InvokeDeathAfterPeriod());
        }

        public void AssignAttackingingPiecePosition(bool isWinner)
        {
            StartCoroutine(AssignNewPositionAfterPeriod(isWinner));
        }

        [TargetRpc]
        private void TargetClearHighlightedTilesOnDeath(NetworkConnection conn)
        {
            // Clear the tile highlights for that piece when it dies.
            Tile tile = gameManager.boardManager.GetTileByPositionName(currentTile);
            gameManager.boardManager.HighlightValidTiles(tile, false);
        }

        private IEnumerator InvokeDeathAfterPeriod()
        {
            yield return new WaitForSeconds(1.5f);

            OnDeath?.Invoke(this);
            RpcInvokeDeathOnClient();
            NetworkServer.Destroy(this.gameObject);
            //StartCoroutine(DestroyAfterPeriod());

        }

        private IEnumerator DestroyAfterPeriod()
        {
            yield return new WaitForSeconds(0.5f);

        }


        [ClientRpc]
        private void RpcInvokeDeathOnClient()
        {
            OnDeath?.Invoke(this);
        }

        private IEnumerator AssignNewPositionAfterPeriod(bool isVictor)
        {
            yield return new WaitForSeconds(0.3f);

            NetworkGameManager network = NetworkManager.singleton as NetworkGameManager;

            Tile originTile = gameManager.boardManager.GetTileByPositionName(previousTile);
            Tile targetTile = gameManager.boardManager.GetTileByPositionName(newTile);

            if (isVictor)
            {

                network.AssignPieceToTile(targetTile.tilePos, originTile.networkPiece, originTile.occupyingPlayer, originTile.currentPieceId);
                network.UnassignPieceFromTile(originTile.tilePos);

                currentTile = targetTile.tilePos;
            }
            else
            {
                // move back to the previous tile.
            }
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

        public Piece GetPieceById(int id)
        {
            Piece piece = null;

            if (id == pieceId)
            {
                piece = this;
            }

            return piece;
        }

        public PieceType GetPieceType(Piece piece)
        {
            if (piece is Pawn)
            {
                return PieceType.Pawn;
            }
            else if (piece is Bishop)
            {
                return PieceType.Bishop;
            }
            else if (piece is Knight)
            {
                return PieceType.Knight;
            }
            else if (piece is Rook)
            {
                return PieceType.Rook;
            }
            else if (piece is Mage)
            {
                return PieceType.Mage;
            }
            else if (piece is King)
            {
                return PieceType.King;
            }

            return PieceType.Empty;
        }
    }
}