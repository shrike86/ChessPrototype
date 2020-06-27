using ChessPrototype.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.Pieces
{
    public class Knight : Piece
    {
        public override bool ValidateMove(TilePositionName originTilePos, TilePositionName targetTilePos, Tile originTile, Tile targetTile, bool isHighlightValidation)
        {
            bool success = false;

            BoardManager board = gameManager.boardManager;
            Tuple<int, int> originTileIndex = board.GetTileIndexByName(originTilePos);
            Tuple<int, int> targetTileIndex = board.GetTileIndexByName(targetTilePos);

            bool isTargetTileEmpty = gameManager.boardManager.IsTargetTileEmpty(targetTile.tilePos);
            bool isTargetTileOccupiedByOpposingPlayer = gameManager.boardManager.IsTargetTileOccupiedByOpposingPlayer(targetTile.tilePos, originTile.occupyingPlayer);

            //If target tile is either 2 rows up or 2 rows down.
            if (targetTileIndex.Item1 == (originTileIndex.Item1 + 2) || targetTileIndex.Item1 == (originTileIndex.Item1 - 2))
            {
                // If target tile is 2 rows up.
                if (targetTileIndex.Item1 == (originTileIndex.Item1 + 2))
                {
                    // If target tile is either one tile to the right or left.
                    if (targetTileIndex.Item2 == (originTileIndex.Item2 + 1) || targetTileIndex.Item2 == (originTileIndex.Item2 - 1))
                    {
                        if (isTargetTileEmpty || isTargetTileOccupiedByOpposingPlayer)
                        {
                            success = true;
                        }
                    }
                }
                // If target tile is 2 rows down.
                else if (targetTileIndex.Item1 == (originTileIndex.Item1 - 2))
                {
                    // If target tile is either one tile to the right or left.
                    if (targetTileIndex.Item2 == (originTileIndex.Item2 + 1) || targetTileIndex.Item2 == (originTileIndex.Item2 - 1))
                    {
                        if (isTargetTileEmpty || isTargetTileOccupiedByOpposingPlayer)
                        {
                            success = true;
                        }
                    }
                }
            }
            // If target tile is either 1 row up or 1 row down.
            else if (targetTileIndex.Item1 == (originTileIndex.Item1 + 1) || targetTileIndex.Item1 == (originTileIndex.Item1 - 1))
            {
                // If target tile is 1 rows up.
                if (targetTileIndex.Item1 == (originTileIndex.Item1 + 1))
                {
                    // If target tile is either two tiles to the right or left.
                    if (targetTileIndex.Item2 == (originTileIndex.Item2 + 2) || targetTileIndex.Item2 == (originTileIndex.Item2 - 2))
                    {
                        if (isTargetTileEmpty || isTargetTileOccupiedByOpposingPlayer)
                        {
                            success = true;
                        }
                    }
                }
                // If target tile is 1 rows down.
                else if (targetTileIndex.Item1 == (originTileIndex.Item1 - 1))
                {
                    // If target tile is either two tiles to the right or left.
                    if (targetTileIndex.Item2 == (originTileIndex.Item2 + 2) || targetTileIndex.Item2 == (originTileIndex.Item2 - 2))
                    {
                        if (isTargetTileEmpty || isTargetTileOccupiedByOpposingPlayer)
                        {
                            success = true;
                        }
                    }
                }
            }
            

            return success;
        }
    }
}