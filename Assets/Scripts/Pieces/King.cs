using ChessPrototype.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.Pieces
{
    public class King : Piece
    {
        public override bool ValidateMove(TilePositionName originTilePos, TilePositionName targetTilePos, Tile originTile, Tile targetTile, bool isHighlightValidation)
        {
            bool success = false;

            BoardManager board = gameManager.boardManager;
            Tuple<int, int> originTileIndex = board.GetTileIndexByName(originTilePos);
            Tuple<int, int> targetTileIndex = board.GetTileIndexByName(targetTilePos);

            bool isTargetTileEmpty = gameManager.boardManager.IsTargetTileEmpty(targetTile.tilePos);
            bool isTargetTileOccupiedByOpposingPlayer = gameManager.boardManager.IsTargetTileOccupiedByOpposingPlayer(targetTile.tilePos, originTile.occupyingPlayer);

            // If target tile is one row up or one row down.
            if (targetTileIndex.Item1 == (originTileIndex.Item1 + 1) || targetTileIndex.Item1 == (originTileIndex.Item1 - 1))
            {
                success = ValidateOnePositionMove_Rook(success, originTileIndex, targetTileIndex, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
            }
            // If target tile is either one row up or one row down or one column to the right or left.
            else if ((targetTileIndex.Item1 == (originTileIndex.Item1 + 1) || targetTileIndex.Item1 == (originTileIndex.Item1 - 1)) || (targetTileIndex.Item2 == (originTileIndex.Item2 + 1) || targetTileIndex.Item2 == (originTileIndex.Item2 - 1)))
            {
                success = ValidateOnePositionMove_Bishop(success, originTileIndex, targetTileIndex, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
            }

            return success;
        }



        private bool ValidateOnePositionMove_Rook(bool success, Tuple<int, int> originTileIndex, Tuple<int, int> targetTileIndex, bool isTargetTileEmpty, bool isTargetTileOccupiedByOpposingPlayer)
        {
            if (targetTileIndex.Item2 == (originTileIndex.Item2 + 1) || targetTileIndex.Item2 == (originTileIndex.Item2 - 1))
            {
                if (isTargetTileEmpty || isTargetTileOccupiedByOpposingPlayer)
                {
                    success = true;
                }
            }
            // If target tile is on the same column.
            else if (targetTileIndex.Item2 == originTileIndex.Item2)
            {
                // If target tile is one row up
                if (targetTileIndex.Item1 == (originTileIndex.Item1 + 1))
                {
                    // If target tile is empty or occupied by an opposing player.
                    if (isTargetTileEmpty || isTargetTileOccupiedByOpposingPlayer)
                    {
                        success = true;
                    }
                }
                // If target tile is one row down.
                else if (targetTileIndex.Item1 == (originTileIndex.Item1 - 1))
                {
                    // If target tile is empty or occupied by an opposing player.
                    if (isTargetTileEmpty || isTargetTileOccupiedByOpposingPlayer)
                    {
                        success = true;
                    }
                }
            }
            // If target tile is on the same row.
            else if (targetTileIndex.Item1 == originTileIndex.Item1)
            {
                // If target tile is one column to the right.
                if (targetTileIndex.Item2 == (originTileIndex.Item2 + 1))
                {
                    // If target tile is empty or occupied by an opposing player.
                    if (isTargetTileEmpty || isTargetTileOccupiedByOpposingPlayer)
                    {
                        success = true;
                    }
                }
                // If target tile is one column to the left.
                else if (targetTileIndex.Item2 == (originTileIndex.Item2 - 1))
                {
                    // If target tile is empty or occupied by an opposing player.
                    if (isTargetTileEmpty || isTargetTileOccupiedByOpposingPlayer)
                    {
                        success = true;
                    }
                }
            }

            return success;
        }

        private bool ValidateOnePositionMove_Bishop(bool success, Tuple<int, int> originTileIndex, Tuple<int, int> targetTileIndex, bool isTargetTileEmpty, bool isTargetTileOccupiedByOpposingPlayer)
        {
            // If target tile is on the same column.
            if (targetTileIndex.Item2 == originTileIndex.Item2)
            {
                // If target tile is one row up
                if (targetTileIndex.Item1 == (originTileIndex.Item1 + 1))
                {
                    // If target tile is empty or occupied by an opposing player.
                    if (isTargetTileEmpty || isTargetTileOccupiedByOpposingPlayer)
                    {
                        success = true;
                    }
                }
                // If target tile is one row down.
                else if (targetTileIndex.Item1 == (originTileIndex.Item1 - 1))
                {
                    // If target tile is empty or occupied by an opposing player.
                    if (isTargetTileEmpty || isTargetTileOccupiedByOpposingPlayer)
                    {
                        success = true;
                    }
                }
            }
            // If target tile is on the same row.
            else if (targetTileIndex.Item1 == originTileIndex.Item1)
            {
                // If target tile is one column to the right.
                if (targetTileIndex.Item2 == (originTileIndex.Item2 + 1))
                {
                    // If target tile is empty or occupied by an opposing player.
                    if (isTargetTileEmpty || isTargetTileOccupiedByOpposingPlayer)
                    {
                        success = true;
                    }
                }
                // If target tile is one column to the left.
                else if (targetTileIndex.Item2 == (originTileIndex.Item2 - 1))
                {
                    // If target tile is empty or occupied by an opposing player.
                    if (isTargetTileEmpty || isTargetTileOccupiedByOpposingPlayer)
                    {
                        success = true;
                    }
                }
            }

            return success;
        }
    }
}