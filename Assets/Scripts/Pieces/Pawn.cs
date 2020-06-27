using ChessPrototype.Base;
using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ChessPrototype.Pieces
{
    public class Pawn : Piece
    {
        [SyncVar]
        public bool isFirstMove;

        public void InitPawnPiece()
        {
            isFirstMove = true;
        }

        public override bool ValidateMove(TilePositionName originTilePos, TilePositionName targetTilePos, Tile originTile, Tile targetTile, bool isHighlightValidation)
        {
            bool success = false;

            BoardManager board = gameManager.boardManager;
            Tuple<int, int> originTileIndex = board.GetTileIndexByName(originTilePos);
            Tuple<int, int> targetTileIndex = board.GetTileIndexByName(targetTilePos);

            bool isTargetTileEmpty = gameManager.boardManager.IsTargetTileEmpty(targetTile.tilePos);
            bool isTargetTileOccupiedByOpposingPlayer = gameManager.boardManager.IsTargetTileOccupiedByOpposingPlayer(targetTile.tilePos, originTile.occupyingPlayer);

            switch (originTile.occupyingPlayer)
            {
                case PlayerIndex.Player1:
                    // If the target tile is on the same column as the origin tile and the target tile is not occupied.
                    if (targetTileIndex.Item2 == originTileIndex.Item2)
                    {
                        // Allow to move two rows on the first move.
                        if (isFirstMove)
                        {
                            if (targetTileIndex.Item1 == (originTileIndex.Item1 + 1) || targetTileIndex.Item1 == (originTileIndex.Item1 + 2))
                            {
                                // Check first stop.
                                Tuple<int, int> firstStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 + 1), originTileIndex.Item2);
                                Tile firstStopTile = board.GetTileByIndex(firstStopTileIndex.Item1, firstStopTileIndex.Item2);

                                // If first stop is unoccupied then finally check target tile.
                                if (gameManager.boardManager.IsTargetTileEmpty(firstStopTile.tilePos))
                                {
                                    // Can only move forward one square if the tile is not occupied.
                                    if (isTargetTileEmpty)
                                    {
                                        success = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // Otherwise only ever move one row.
                            if (targetTileIndex.Item1 == (originTileIndex.Item1 + 1))
                            {
                                // Can only move forward one square if the tile is not occupied.
                                if (isTargetTileEmpty)
                                {
                                    success = true;
                                }
                            }
                        }
                    }
                    // If the target tile is one column to the right or one to the left.
                    else if (targetTileIndex.Item2 == (originTileIndex.Item2 - 1) || targetTileIndex.Item2 == (originTileIndex.Item2 + 1))
                    {
                        // If the target tile is one column to the left.
                        if (targetTileIndex.Item2 == (originTileIndex.Item2 - 1))
                        {
                            // If the target tile is one row up.
                            if (targetTileIndex.Item1 == (originTileIndex.Item1 + 1))
                            {
                                // The target tile is occupied by an enemy.
                                if (isTargetTileOccupiedByOpposingPlayer)
                                {
                                    success = true;
                                }
                            }
                        }

                        // If the target tile is one column to the right.
                        if (targetTileIndex.Item2 == (originTileIndex.Item2 + 1))
                        {
                            // If the target tile is one row up.
                            if (targetTileIndex.Item1 == (originTileIndex.Item1 + 1))
                            {
                                // And the target tile is empty or occupied by an enemy and only one row up from the current row.
                                if (isTargetTileOccupiedByOpposingPlayer)
                                {
                                    success = true;
                                }
                            }
                        }

                    }
                    break;
                case PlayerIndex.Player2:
                    if (targetTileIndex.Item2 == originTileIndex.Item2)
                    {
                        // Allow to move two rows on the first move.
                        if (isFirstMove)
                        {
                            if (targetTileIndex.Item1 == (originTileIndex.Item1 - 1) || targetTileIndex.Item1 == (originTileIndex.Item1 - 2))
                            {
                                // Check first stop.
                                Tuple<int, int> firstStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 - 1), originTileIndex.Item2);
                                Tile firstStopTile = board.GetTileByIndex(firstStopTileIndex.Item1, firstStopTileIndex.Item2);

                                // If first stop is unoccupied then finally check target tile.
                                if (gameManager.boardManager.IsTargetTileEmpty(firstStopTile.tilePos))
                                {
                                    // Can only move forward one square if the tile is not occupied.
                                    if (isTargetTileEmpty)
                                    {
                                        success = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // Otherwise only ever move one row.
                            if (targetTileIndex.Item1 == (originTileIndex.Item1 - 1))
                            {
                                // Can only move forward one square if the tile is not occupied.
                                if (isTargetTileEmpty)
                                {
                                    success = true;
                                }
                            }
                        }
                    }
                    else if (targetTileIndex.Item2 == (originTileIndex.Item2 - 1) || targetTileIndex.Item2 == (originTileIndex.Item2 + 1))
                    {
                        // If the target tile is one column to the left.
                        if (targetTileIndex.Item2 == (originTileIndex.Item2 - 1))
                        {
                            // If the target tile is one row down.
                            if (targetTileIndex.Item1 == (originTileIndex.Item1 - 1))
                            {
                                // The target tile is occupied by an enemy.
                                if (isTargetTileOccupiedByOpposingPlayer)
                                {
                                    success = true;
                                }
                            }
                        }

                        // If the target tile is one column to the right.
                        if (targetTileIndex.Item2 == (originTileIndex.Item2 + 1))
                        {
                            // If the target tile is one row down.
                            if (targetTileIndex.Item1 == (originTileIndex.Item1 - 1))
                            {
                                // The target tile is occupied by an enemy.
                                if (isTargetTileOccupiedByOpposingPlayer)
                                {
                                    success = true;
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

            return success;
        }
    }
}