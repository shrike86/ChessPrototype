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
            if (!playerManager.networkGameManager.turnManager.isGameStarted)
                return;

            Tile originTile = gameManager.uIManager.CurrentSelectedTile;

            if (originTile == null || originTile.occupyingPlayer != playerManager.playerIndex)
                return;

            Tile targetTile = gameManager.GetTile();

            CmdSetupMoveOnServer(originTile.tilePos, targetTile.tilePos);
        }

        [Command]
        private void CmdSetupMoveOnServer(TilePositionName selectedTileName, TilePositionName targetTileName)
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

            // Only do this if valid.
            MovePieceOnNetwork(originTile, targetTile);
        }

        private bool ValidateMove(Piece pieceToMove, TilePositionName originName, TilePositionName targetName, Tile origin, Tile target)
        {
            bool validMove = false;

            Pawn pawn = pieceToMove as Pawn;

            if (pawn != null)
            {
                validMove = pawn.ValidateMove(originName, targetName, origin, target);

                return validMove;
            }

            Knight knight = pieceToMove as Knight;

            if (knight != null)
            {
                validMove = knight.ValidateMove(originName, targetName, origin, target);

                return validMove;
            }

            Rook rook = pieceToMove as Rook;

            if (rook != null)
            {
                validMove = rook.ValidateMove(originName, targetName, origin, target);

                return validMove;
            }

            Bishop bishop = pieceToMove as Bishop;

            if (bishop != null)
            {
                validMove = bishop.ValidateMove(originName, targetName, origin, target);

                return validMove;
            }




            return validMove;
        }


        private void MovePieceOnNetwork(Tile originTile, Tile targetTile)
        {
            int originPieceId = originTile.currentPieceId;

            NetworkGameManager network = NetworkManager.singleton as NetworkGameManager;
            Piece pieceToMove = network.pieces.Where(piece => piece.pieceId == originPieceId).Single();

            network.AssignPieceToTile(targetTile.tilePos, originTile.networkPiece, originTile.occupyingPlayer, originPieceId);
            network.UnassignPieceFromTile(originTile.tilePos);

            // Get navmeshagent and move piece.
            AIManager ai = pieceToMove.GetComponent<AIManager>();

            Vector3 targetDestination = GameConstants.GetTilePosition(targetTile.tilePos);
            ai.RpcSetDestination(targetDestination);
        }
    }
}