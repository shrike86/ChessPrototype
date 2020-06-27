using ChessPrototype.AI;
using ChessPrototype.Base;
using ChessPrototype.UI;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ChessPrototype.Pieces
{
    public class MoveManager : NetworkBehaviour
    {
        public GameManager gameManager;
        public PlayerManager playerManager;


        public void Init(GameManager gameManager, PlayerManager playerManager)
        {
            this.gameManager = gameManager;
            this.playerManager = playerManager;

            gameManager.inputManager.OnDoubleClick += SetupMoveLocally;
        }

        private void SetupMoveLocally()
        {
            if (!TurnManager.Instance.isGameStarted || TurnManager.Instance.hasMovedThisTurn)
                return;

            PlayerIndex thisPlayer = playerManager.playerIndex;

            if (playerManager.networkGameManager.turnManager.player != thisPlayer)
                return;

            Tile originTile = gameManager.uIManager.CurrentSelectedTile;

            if (originTile == null || originTile.occupyingPlayer != playerManager.playerIndex)
                return;

            Tile targetTile = gameManager.GetTile();

            CmdSetupMoveOnServer(originTile.tilePos, targetTile.tilePos);
        }

        [Command]
        private void CmdSetupMoveOnServer(TilePositionName selectedTileName, TilePositionName targetTileName, NetworkConnectionToClient sender = null)
        {
            if (gameManager == null)
            {
                gameManager = FindObjectOfType<GameManager>();
            }

            Tile originTile = gameManager.boardManager.GetTileByPositionName(selectedTileName);
            Tile targetTile = gameManager.boardManager.GetTileByPositionName(targetTileName);

            int originPieceId = originTile.currentPieceId;

            NetworkGameManager network = NetworkManager.singleton as NetworkGameManager;
            Piece pieceToMove = network.pieces.Where(piece => piece.pieceId == originPieceId).Single();

            bool validMove = ValidateMove(pieceToMove, originTile.tilePos, targetTile.tilePos, originTile, targetTile);

            if (!validMove)
                return;

            TargetResetTileOnMove(sender, selectedTileName);
            StartCoroutine(WaitForTileResetThenMove(originTile, targetTile));
        }

        private IEnumerator WaitForTileResetThenMove(Tile originTile, Tile targetTile)
        {
            yield return new WaitForSeconds(0.2f);

            MovePieceOnServer(originTile, targetTile);
        }

        [TargetRpc]
        private void TargetResetTileOnMove(NetworkConnection target, TilePositionName originTile)
        {
            gameManager.uIManager.CurrentSelectedTile = null;
            Tile t = gameManager.boardManager.GetTileByPositionName(originTile);
            t.IsSelected = false;
        }

        private bool ValidateMove(Piece pieceToMove, TilePositionName originName, TilePositionName targetName, Tile origin, Tile target)
        {
            bool validMove = false;

            Pawn pawn = pieceToMove as Pawn;

            if (pawn != null)
            {
                validMove = pawn.ValidateMove(originName, targetName, origin, target, false);

                return validMove;
            }

            Knight knight = pieceToMove as Knight;

            if (knight != null)
            {
                validMove = knight.ValidateMove(originName, targetName, origin, target, false);

                return validMove;
            }

            Rook rook = pieceToMove as Rook;

            if (rook != null)
            {
                validMove = rook.ValidateMove(originName, targetName, origin, target, false);

                return validMove;
            }

            Bishop bishop = pieceToMove as Bishop;

            if (bishop != null)
            {
                validMove = bishop.ValidateMove(originName, targetName, origin, target, false);

                return validMove;
            }

            Mage mage = pieceToMove as Mage;

            if (mage != null)
            {
                validMove = mage.ValidateMove(originName, targetName, origin, target, false);

                return validMove;
            }

            King king = pieceToMove as King;

            if (king != null)
            {
                validMove = king.ValidateMove(originName, targetName, origin, target, false);

                return validMove;
            }

            return validMove;
        }


        private void MovePieceOnServer(Tile originTile, Tile targetTile)
        {
            int originPieceId = originTile.currentPieceId;

            NetworkGameManager network = NetworkManager.singleton as NetworkGameManager;
            Piece pieceToMove = network.pieces.Where(piece => piece.pieceId == originPieceId).Single();

            // If the target tile is not occupied it is then safe to update the target tile at this stage.
            bool isTargetTileEmpty = gameManager.boardManager.IsTargetTileEmpty(targetTile.tilePos);
            if (isTargetTileEmpty)
            {
                network.AssignPieceToTile(targetTile.tilePos, originTile.networkPiece, originTile.occupyingPlayer, originPieceId);
                network.UnassignPieceFromTile(originTile.tilePos);
                pieceToMove.currentTile = targetTile.tilePos;
            }

            // Assign this here so that when the move is finished we can update the tiles, will only be used in the case that the target tile was occupied but might as well always populate it.
            pieceToMove.previousTile = originTile.tilePos;
            pieceToMove.newTile = targetTile.tilePos;

            // Need to set first move at a later stage so that the removal of tile highlights will work.
            if (pieceToMove.GetPieceType(pieceToMove) == PieceType.Pawn)
            {
                Pawn p = pieceToMove as Pawn;

                if (p.isFirstMove)
                {
                    p.isFirstMove = false;
                }
            }

            // Get navmeshagent and move piece.
            AIManager ai = pieceToMove.GetComponent<AIManager>();

            Vector3 targetDestination = GameConstants.GetTilePosition(targetTile.tilePos);
            ai.RpcSetDestination(targetDestination);

            TurnManager.Instance.hasMovedThisTurn = true;
        }
    }
}