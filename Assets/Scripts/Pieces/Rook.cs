using ChessPrototype.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.Pieces
{
    public class Rook : Piece
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
                success = ValidateOnePositionMove(success, originTileIndex, targetTileIndex, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
            }
            // If target tile is either two rows up or two rows down.
            else if (targetTileIndex.Item1 == (originTileIndex.Item1 + 2) || targetTileIndex.Item1 == (originTileIndex.Item1 - 2))
            {
                success = ValidateTwoPositionMove(success, board, originTileIndex, targetTileIndex, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);

            }
            // If target tile is either three rows up or three rows down.
            else if (targetTileIndex.Item1 == (originTileIndex.Item1 + 3) || targetTileIndex.Item1 == (originTileIndex.Item1 - 3))
            {
                success = ValidateThreePositionMove(success, board, originTileIndex, targetTileIndex, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
            }
            // If target tile is either four rows up or four rows down.
            else if (targetTileIndex.Item1 == (originTileIndex.Item1 + 4) || targetTileIndex.Item1 == (originTileIndex.Item1 - 4))
            {
                success = ValidateFourPositionMove(success, board, originTileIndex, targetTileIndex, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
            }
            // If target tile is either five rows up or five rows down.
            else if (targetTileIndex.Item1 == (originTileIndex.Item1 + 5) || targetTileIndex.Item1 == (originTileIndex.Item1 - 5))
            {
                success = ValidateFivePositionMove(success, board, originTileIndex, targetTileIndex, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
            }
            // If target tile is either six rows up or six rows down.
            else if (targetTileIndex.Item1 == (originTileIndex.Item1 + 6) || targetTileIndex.Item1 == (originTileIndex.Item1 - 6))
            {
                success = ValidateSixPositionMove(success, board, originTileIndex, targetTileIndex, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
            }
            // If target tile is either seven rows up or seven rows down.
            else if (targetTileIndex.Item1 == (originTileIndex.Item1 + 7) || targetTileIndex.Item1 == (originTileIndex.Item1 - 7))
            {
                success = ValidateSevenPositionMove(success, board, originTileIndex, targetTileIndex, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
            }

            return success;
        }

        private bool ValidateOnePositionMove(bool success, Tuple<int, int> originTileIndex, Tuple<int, int> targetTileIndex, bool isTargetTileEmpty, bool isTargetTileOccupiedByOpposingPlayer)
        {
            if (targetTileIndex.Item2 == (originTileIndex.Item2 + 1) || targetTileIndex.Item2 == (originTileIndex.Item2 - 1))
            {
                if (isTargetTileEmpty || isTargetTileOccupiedByOpposingPlayer)
                {
                    success = true;
                }
            }

            return success;
        }

        private bool ValidateTwoPositionMove(bool success, BoardManager board, Tuple<int, int> originTileIndex, Tuple<int, int> targetTileIndex, bool isTargetTileEmpty, bool isTargetTileOccupiedByOpposingPlayer)
        {
            // If target tile is two rows up.
            if (targetTileIndex.Item1 == (originTileIndex.Item1 + 2))
            {
                // If target tile is two columns to the right or left.
                if (targetTileIndex.Item2 == (originTileIndex.Item2 + 2) || targetTileIndex.Item2 == (originTileIndex.Item2 - 2))
                {
                    // If target tile is two columns to the right.
                    if (targetTileIndex.Item2 == (originTileIndex.Item2 + 2))
                    {
                        success = ValidateForwardSteps(board, 1, 2, originTileIndex, false, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                    // If target tile is two columns to the left.
                    else if (targetTileIndex.Item2 == (originTileIndex.Item2 - 2))
                    {
                        success = ValidateForwardSteps(board, 1, 2, originTileIndex, true, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                }
            }

            // If target tile is two rows down.
            if (targetTileIndex.Item1 == (originTileIndex.Item1 - 2))
            {
                // If target tile is two columns to the right or left.
                if (targetTileIndex.Item2 == (originTileIndex.Item2 + 2) || targetTileIndex.Item2 == (originTileIndex.Item2 - 2))
                {
                    // If target tile is two columns to the right.
                    if (targetTileIndex.Item2 == (originTileIndex.Item2 - 2))
                    {
                        success = ValidateBackwardSteps(board, 1, 2, originTileIndex, false, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                    // If target tile is two columns to the left.
                    else if (targetTileIndex.Item2 == (originTileIndex.Item2 + 2))
                    {
                        success = ValidateBackwardSteps(board, 1, 2, originTileIndex, true, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                }
            }

            return success;
        }

        private bool ValidateThreePositionMove(bool success, BoardManager board, Tuple<int, int> originTileIndex, Tuple<int, int> targetTileIndex, bool isTargetTileEmpty, bool isTargetTileOccupiedByOpposingPlayer)
        {
            // If target tile is three rows up.
            if (targetTileIndex.Item1 == (originTileIndex.Item1 + 3))
            {
                // If target tile is either three columns to the right or three to the left.
                if (targetTileIndex.Item2 == (originTileIndex.Item2 + 3) || targetTileIndex.Item2 == (originTileIndex.Item2 - 3))
                {
                    // If target tile is three columns to the right.
                    if (targetTileIndex.Item2 == (originTileIndex.Item2 + 3))
                    {
                        success = ValidateForwardSteps(board, 1, 3, originTileIndex, false, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                    // If target tile is three columns to the left.
                    else if (targetTileIndex.Item2 == (originTileIndex.Item2 - 3))
                    {
                        success = ValidateForwardSteps(board, 1, 3, originTileIndex, true, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                }
            }

            // If target tile is three rows down.
            if (targetTileIndex.Item1 == (originTileIndex.Item1 - 3))
            {
                // If target tile is either three columns to the right or three to the left.
                if (targetTileIndex.Item2 == (originTileIndex.Item2 + 3) || targetTileIndex.Item2 == (originTileIndex.Item2 - 3))
                {
                    // If target tile is three columns to the right.
                    if (targetTileIndex.Item2 == (originTileIndex.Item2 - 3))
                    {
                        success = ValidateBackwardSteps(board, 1, 3, originTileIndex, false, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                    // If target tile is three columns to the left.
                    else if (targetTileIndex.Item2 == (originTileIndex.Item2 + 3))
                    {
                        success = ValidateBackwardSteps(board, 1, 3, originTileIndex, true, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                }
            }


            return success;
        }

        private bool ValidateFourPositionMove(bool success, BoardManager board, Tuple<int, int> originTileIndex, Tuple<int, int> targetTileIndex, bool isTargetTileEmpty, bool isTargetTileOccupiedByOpposingPlayer)
        {
            // If target tile is four rows up.
            if (targetTileIndex.Item1 == (originTileIndex.Item1 + 4))
            {
                // If target tile is either four columns to the right or four to the left.
                if (targetTileIndex.Item2 == (originTileIndex.Item2 + 4) || targetTileIndex.Item2 == (originTileIndex.Item2 - 4))
                {
                    // If target tile is four columns to the right.
                    if (targetTileIndex.Item2 == (originTileIndex.Item2 + 4))
                    {
                        success = ValidateForwardSteps(board, 1, 4, originTileIndex, false, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                    // If target tile is four columns to the left.
                    else if (targetTileIndex.Item2 == (originTileIndex.Item2 - 4))
                    {
                        success = ValidateForwardSteps(board, 1, 4, originTileIndex, true, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                }
            }

            // If target tile is four rows down.
            if (targetTileIndex.Item1 == (originTileIndex.Item1 - 4))
            {
                // If target tile is either four columns to the right or four to the left.
                if (targetTileIndex.Item2 == (originTileIndex.Item2 + 4) || targetTileIndex.Item2 == (originTileIndex.Item2 - 4))
                {
                    // If target tile is four columns to the right.
                    if (targetTileIndex.Item2 == (originTileIndex.Item2 - 4))
                    {
                        success = ValidateBackwardSteps(board, 1, 4, originTileIndex, false, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                    // If target tile is four columns to the left.
                    else if (targetTileIndex.Item2 == (originTileIndex.Item2 + 4))
                    {
                        success = ValidateBackwardSteps(board, 1, 4, originTileIndex, true, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                }
            }

            return success;
        }

        private bool ValidateFivePositionMove(bool success, BoardManager board, Tuple<int, int> originTileIndex, Tuple<int, int> targetTileIndex, bool isTargetTileEmpty, bool isTargetTileOccupiedByOpposingPlayer)
        {
            // If target tile is five rows up.
            if (targetTileIndex.Item1 == (originTileIndex.Item1 + 5))
            {
                // If target tile is either five columns to the right or five to the left.
                if (targetTileIndex.Item2 == (originTileIndex.Item2 + 5) || targetTileIndex.Item2 == (originTileIndex.Item2 - 5))
                {
                    // If target tile is five columns to the right.
                    if (targetTileIndex.Item2 == (originTileIndex.Item2 + 5))
                    {
                        success = ValidateForwardSteps(board, 1, 5, originTileIndex, false, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                    // If target tile is five columns to the left.
                    else if (targetTileIndex.Item2 == (originTileIndex.Item2 - 5))
                    {
                        success = ValidateForwardSteps(board, 1, 5, originTileIndex, true, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                }
            }

            // If target tile is five rows down.
            if (targetTileIndex.Item1 == (originTileIndex.Item1 - 5))
            {
                // If target tile is either five columns to the right or five to the left.
                if (targetTileIndex.Item2 == (originTileIndex.Item2 + 5) || targetTileIndex.Item2 == (originTileIndex.Item2 - 5))
                {
                    // If target tile is five columns to the right.
                    if (targetTileIndex.Item2 == (originTileIndex.Item2 - 5))
                    {
                        success = ValidateBackwardSteps(board, 1, 5, originTileIndex, false, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                    // If target tile is five columns to the left.
                    else if (targetTileIndex.Item2 == (originTileIndex.Item2 + 5))
                    {
                        success = ValidateBackwardSteps(board, 1, 5, originTileIndex, true, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                }
            }

            return success;
        }

        private bool ValidateSixPositionMove(bool success, BoardManager board, Tuple<int, int> originTileIndex, Tuple<int, int> targetTileIndex, bool isTargetTileEmpty, bool isTargetTileOccupiedByOpposingPlayer)
        {
            // If target tile is six rows up.
            if (targetTileIndex.Item1 == (originTileIndex.Item1 + 6))
            {
                // If target tile is either six columns to the right or six to the left.
                if (targetTileIndex.Item2 == (originTileIndex.Item2 + 6) || targetTileIndex.Item2 == (originTileIndex.Item2 - 6))
                {
                    // If target tile is six columns to the right.
                    if (targetTileIndex.Item2 == (originTileIndex.Item2 + 6))
                    {
                        success = ValidateForwardSteps(board, 1, 6, originTileIndex, false, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                    // If target tile is six columns to the left.
                    else if (targetTileIndex.Item2 == (originTileIndex.Item2 - 6))
                    {
                        success = ValidateForwardSteps(board, 1, 6, originTileIndex, true, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                }
            }

            // If target tile is six rows down.
            if (targetTileIndex.Item1 == (originTileIndex.Item1 - 6))
            {
                // If target tile is either six columns to the right or six to the left.
                if (targetTileIndex.Item2 == (originTileIndex.Item2 + 6) || targetTileIndex.Item2 == (originTileIndex.Item2 - 6))
                {
                    // If target tile is six columns to the right.
                    if (targetTileIndex.Item2 == (originTileIndex.Item2 - 6))
                    {
                        success = ValidateBackwardSteps(board, 1, 6, originTileIndex, false, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                    // If target tile is six columns to the left.
                    else if (targetTileIndex.Item2 == (originTileIndex.Item2 + 6))
                    {
                        success = ValidateBackwardSteps(board, 1, 6, originTileIndex, true, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                }
            }

            return success;
        }

        private bool ValidateSevenPositionMove(bool success, BoardManager board, Tuple<int, int> originTileIndex, Tuple<int, int> targetTileIndex, bool isTargetTileEmpty, bool isTargetTileOccupiedByOpposingPlayer)
        {
            // If target tile is seven rows up.
            if (targetTileIndex.Item1 == (originTileIndex.Item1 + 7))
            {
                // If target tile is either seven columns to the right or seven to the left.
                if (targetTileIndex.Item2 == (originTileIndex.Item2 + 7) || targetTileIndex.Item2 == (originTileIndex.Item2 - 7))
                {
                    // If target tile is seven columns to the right.
                    if (targetTileIndex.Item2 == (originTileIndex.Item2 + 7))
                    {
                        success = ValidateForwardSteps(board, 1, 7, originTileIndex, false, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                    // If target tile is seven columns to the left.
                    else if (targetTileIndex.Item2 == (originTileIndex.Item2 - 7))
                    {
                        success = ValidateForwardSteps(board, 1, 7, originTileIndex, true, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                }
            }

            // If target tile is seven rows down.
            if (targetTileIndex.Item1 == (originTileIndex.Item1 - 7))
            {
                // If target tile is either seven columns to the right or seven to the left.
                if (targetTileIndex.Item2 == (originTileIndex.Item2 + 7) || targetTileIndex.Item2 == (originTileIndex.Item2 - 7))
                {
                    // If target tile is seven columns to the right.
                    if (targetTileIndex.Item2 == (originTileIndex.Item2 - 7))
                    {
                        success = ValidateBackwardSteps(board, 1, 7, originTileIndex, false, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                    // If target tile is seven columns to the left.
                    else if (targetTileIndex.Item2 == (originTileIndex.Item2 + 7))
                    {
                        success = ValidateBackwardSteps(board, 1, 7, originTileIndex, true, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                    }
                }
            }

            return success;
        }

        private bool ValidateForwardSteps(BoardManager board, int index, int moves, Tuple<int, int> originTileIndex, bool isLeft, bool isTargetTileEmpty, bool isTargetTileOccupiedByOpposingPlayer)
        {
            bool valid = false;

            Tuple<int, int> stopIndex = new Tuple<int, int>(0, 0);

            if (!isLeft)
            {
                stopIndex = new Tuple<int, int>((originTileIndex.Item1 + index), (originTileIndex.Item2 + index));
            }
            else
            {
                stopIndex = new Tuple<int, int>((originTileIndex.Item1 + index), (originTileIndex.Item2 - index));
            }

            Tile stopTile = board.GetTileByIndex(stopIndex.Item1, stopIndex.Item2);

            // Tiles on the way to the final tile must be empty.
            if (index < moves)
            {
                if (gameManager.boardManager.IsTargetTileEmpty(stopTile.tilePos))
                {
                    index++;

                    valid = ValidateForwardSteps(board, index, moves, originTileIndex, isLeft, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                }
            }
            // When you get to the final stop then it must be empty or occupied by an enemy player.
            else if (index == moves)
            {
                if (isTargetTileEmpty || isTargetTileOccupiedByOpposingPlayer)
                {
                    valid = true;
                }
            }

            return valid;
        }

        private bool ValidateBackwardSteps(BoardManager board, int index, int moves, Tuple<int, int> originTileIndex, bool isLeft, bool isTargetTileEmpty, bool isTargetTileOccupiedByOpposingPlayer)
        {
            bool valid = false;

            Tuple<int, int> stopIndex = new Tuple<int, int>(0, 0);

            if (!isLeft)
            {
                stopIndex = new Tuple<int, int>((originTileIndex.Item1 - index), (originTileIndex.Item2 - index));
            }
            else
            {
                stopIndex = new Tuple<int, int>((originTileIndex.Item1 - index), (originTileIndex.Item2 + index));
            }

            Tile stopTile = board.GetTileByIndex(stopIndex.Item1, stopIndex.Item2);

            // Tiles on the way to the final tile must be empty.
            if (index < moves)
            {
                if (gameManager.boardManager.IsTargetTileEmpty(stopTile.tilePos))
                {
                    index++;

                    valid = ValidateBackwardSteps(board, index, moves, originTileIndex, isLeft, isTargetTileEmpty, isTargetTileOccupiedByOpposingPlayer);
                }
            }
            // When you get to the final stop then it must be empty or occupied by an enemy player.
            else if (index == moves)
            {
                if (isTargetTileEmpty || isTargetTileOccupiedByOpposingPlayer)
                {
                    valid = true;
                }
            }

            return valid;
        }


    }
}