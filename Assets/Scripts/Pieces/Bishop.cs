using ChessPrototype.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.Pieces
{
    public class Bishop : Piece
    {
        public override bool ValidateMove(TilePositionName originTilePos, TilePositionName targetTilePos, Tile originTile, Tile targetTile)
        {
            bool success = false;

            BoardManager board = gameManager.boardManager;
            Tuple<int, int> originTileIndex = board.GetTileIndexByName(originTilePos);
            Tuple<int, int> targetTileIndex = board.GetTileIndexByName(targetTilePos);

            bool isTargetTileOccupied = gameManager.boardManager.IsTargetTileOccupied(targetTile.tilePos);
            bool isTargetTileOccupiedByOpposingPlayer = gameManager.boardManager.IsTargetTileOccupiedByOpposingPlayer(targetTile.tilePos, originTile.occupyingPlayer);

            // If target tile is either one row up or one row down or one column to the right or left.
            if ((targetTileIndex.Item1 == (originTileIndex.Item1 + 1) || targetTileIndex.Item1 == (originTileIndex.Item1 - 1)) || (targetTileIndex.Item2 == (originTileIndex.Item2 + 1) || targetTileIndex.Item2 == (originTileIndex.Item2 - 1)))
            {
                success = ValidateOnePositionMove(success, originTileIndex, targetTileIndex, isTargetTileOccupied, isTargetTileOccupiedByOpposingPlayer);
            }
            // If target tile is either two rows up or down or one column to the right or left.
            else if ((targetTileIndex.Item1 == (originTileIndex.Item1 + 2) || targetTileIndex.Item1 == (originTileIndex.Item1 - 2)) || (targetTileIndex.Item2 == (originTileIndex.Item2 + 2) || targetTileIndex.Item2 == (originTileIndex.Item2 - 2)))
            {
                success = ValidateTwoPositionMove(success, board, originTileIndex, targetTileIndex, isTargetTileOccupied, isTargetTileOccupiedByOpposingPlayer);

            }
            // If target tile is either three rows up or down or three column to the right or left.
            else if ((targetTileIndex.Item1 == (originTileIndex.Item1 + 3) || targetTileIndex.Item1 == (originTileIndex.Item1 - 3)) || (targetTileIndex.Item2 == (originTileIndex.Item2 + 3) || targetTileIndex.Item2 == (originTileIndex.Item2 - 3)))
            {
                success = ValidateThreePositionMove(success, board, originTileIndex, targetTileIndex, isTargetTileOccupied, isTargetTileOccupiedByOpposingPlayer);
            }
            // If target tile is either four rows up or down or four column to the right or left.
            else if ((targetTileIndex.Item1 == (originTileIndex.Item1 + 4) || targetTileIndex.Item1 == (originTileIndex.Item1 - 4)) || (targetTileIndex.Item2 == (originTileIndex.Item2 + 4) || targetTileIndex.Item2 == (originTileIndex.Item2 - 4)))
            {
                success = ValidateFourPositionMove(success, board, originTileIndex, targetTileIndex, isTargetTileOccupied, isTargetTileOccupiedByOpposingPlayer);
            }
            // If target tile is either five rows up or down or five column to the right or left.
            else if ((targetTileIndex.Item1 == (originTileIndex.Item1 + 5) || targetTileIndex.Item1 == (originTileIndex.Item1 - 5)) || (targetTileIndex.Item2 == (originTileIndex.Item2 + 5) || targetTileIndex.Item2 == (originTileIndex.Item2 - 5)))
            {
                success = ValidateFivePositionMove(success, board, originTileIndex, targetTileIndex, isTargetTileOccupied, isTargetTileOccupiedByOpposingPlayer);
            }
            // If target tile is either six rows up or down or six column to the right or left.
            else if ((targetTileIndex.Item1 == (originTileIndex.Item1 + 1) || targetTileIndex.Item1 == (originTileIndex.Item1 - 1)) || (targetTileIndex.Item2 == (originTileIndex.Item2 + 1) || targetTileIndex.Item2 == (originTileIndex.Item2 - 1)))
            {
                success = ValidateSixPositionMove(success, board, originTileIndex, targetTileIndex, isTargetTileOccupied, isTargetTileOccupiedByOpposingPlayer);
            }
            return success;
        }

        private bool ValidateOnePositionMove(bool success, Tuple<int, int> originTileIndex, Tuple<int, int> targetTileIndex, bool isTargetTileOccupied, bool isTargetTileOccupiedByOpposingPlayer)
        {
            // If target tile is on the same column.
            if (targetTileIndex.Item2 == originTileIndex.Item2)
            {
                // If target tile is one row up
                if (targetTileIndex.Item1 == (originTileIndex.Item1 + 1))
                {
                    // If target tile is empty or occupied by an opposing player.
                    if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                    {
                        success = true;
                    }
                }
                // If target tile is one row down.
                else if (targetTileIndex.Item1 == (originTileIndex.Item1 - 1))
                {
                    // If target tile is empty or occupied by an opposing player.
                    if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
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
                    if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                    {
                        success = true;
                    }
                }
                // If target tile is one column to the left.
                else if (targetTileIndex.Item2 == (originTileIndex.Item2 - 1))
                {
                    // If target tile is empty or occupied by an opposing player.
                    if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                    {
                        success = true;
                    }
                }
            }

            return success;
        }

        private bool ValidateTwoPositionMove(bool success, BoardManager board, Tuple<int, int> originTileIndex, Tuple<int, int> targetTileIndex, bool isTargetTileOccupied, bool isTargetTileOccupiedByOpposingPlayer)
        {
            // If target tile is on the same column.
            if (targetTileIndex.Item2 == originTileIndex.Item2)
            {
                // If target tile is two rows up.
                if (targetTileIndex.Item1 == (originTileIndex.Item1 + 2))
                {
                    // Check first stop.
                    Tuple<int, int> firstStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 + 1), originTileIndex.Item2);
                    Tile firstStopTile = board.GetTileByIndex(firstStopTileIndex.Item1, firstStopTileIndex.Item2);

                    // If first stop is unoccupied then finally check target tile.
                    if (!gameManager.boardManager.IsTargetTileOccupied(firstStopTile.tilePos))
                    {
                        if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                        {
                            success = true;
                        }
                    }
                }
                // If target tile is two rows down
                else if (targetTileIndex.Item1 == (originTileIndex.Item1 - 2))
                {
                    // Check first stop.
                    Tuple<int, int> firstStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 - 1), originTileIndex.Item2);
                    Tile firstStopTile = board.GetTileByIndex(firstStopTileIndex.Item1, firstStopTileIndex.Item2);

                    // If first stop is unoccupied then finally check target tile.
                    if (!gameManager.boardManager.IsTargetTileOccupied(firstStopTile.tilePos))
                    {
                        if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                        {
                            success = true;
                        }
                    }
                }
            }
            // If target tile is on the same row.
            else if (targetTileIndex.Item1 == originTileIndex.Item1)
            {

                // If target tile is two columns to the right.
                if (targetTileIndex.Item2 == (originTileIndex.Item2 + 2))
                {
                    // Check first stop.
                    Tuple<int, int> firstStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 + 1));
                    Tile firstStopTile = board.GetTileByIndex(firstStopTileIndex.Item1, firstStopTileIndex.Item2);

                    // If first stop is unoccupied then finally check target tile.
                    if (!gameManager.boardManager.IsTargetTileOccupied(firstStopTile.tilePos))
                    {
                        if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                        {
                            success = true;
                        }
                    }
                }
                // If target tile is two columns to the left.
                else if (targetTileIndex.Item2 == (originTileIndex.Item2 - 2))
                {
                    // Check first stop.
                    Tuple<int, int> firstStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 - 1));
                    Tile firstStopTile = board.GetTileByIndex(firstStopTileIndex.Item1, firstStopTileIndex.Item2);

                    // If first stop is unoccupied then finally check target tile.
                    if (!gameManager.boardManager.IsTargetTileOccupied(firstStopTile.tilePos))
                    {
                        if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                        {
                            success = true;
                        }
                    }
                }
            }

            return success;
        }

        private bool ValidateThreePositionMove(bool success, BoardManager board, Tuple<int, int> originTileIndex, Tuple<int, int> targetTileIndex, bool isTargetTileOccupied, bool isTargetTileOccupiedByOpposingPlayer)
        {
            // If target tile is on the same column.
            if (targetTileIndex.Item2 == originTileIndex.Item2)
            {
                // If target tile is three rows up.
                if (targetTileIndex.Item1 == (originTileIndex.Item1 + 3))
                {
                    // Check first stop.
                    Tuple<int, int> firstStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 + 1), originTileIndex.Item2);
                    Tile firstStopTile = board.GetTileByIndex(firstStopTileIndex.Item1, firstStopTileIndex.Item2);

                    if (!gameManager.boardManager.IsTargetTileOccupied(firstStopTile.tilePos))
                    {
                        // Check second stop.
                        Tuple<int, int> secondStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 + 2), originTileIndex.Item2);
                        Tile secondStopTile = board.GetTileByIndex(secondStopTileIndex.Item1, secondStopTileIndex.Item2);

                        // If second stop is unoccupied then finally check target tile.
                        if (!gameManager.boardManager.IsTargetTileOccupied(secondStopTile.tilePos))
                        {
                            if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                            {
                                success = true;
                            }
                        }
                    }
                }
                // If target tile is three rows down
                else if (targetTileIndex.Item1 == (originTileIndex.Item1 - 3))
                {
                    // Check first stop.
                    Tuple<int, int> firstStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 - 1), originTileIndex.Item2);
                    Tile firstStopTile = board.GetTileByIndex(firstStopTileIndex.Item1, firstStopTileIndex.Item2);

                    if (!gameManager.boardManager.IsTargetTileOccupied(firstStopTile.tilePos))
                    {
                        // Check second stop.
                        Tuple<int, int> secondStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 - 2), originTileIndex.Item2);
                        Tile secondStopTile = board.GetTileByIndex(secondStopTileIndex.Item1, secondStopTileIndex.Item2);

                        // If second stop is unoccupied then finally check target tile.
                        if (!gameManager.boardManager.IsTargetTileOccupied(secondStopTile.tilePos))
                        {
                            if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                            {
                                success = true;
                            }
                        }
                    }
                }
            }
            // If target tile is on the same row.
            else if (targetTileIndex.Item1 == originTileIndex.Item1)
            {

                // If target tile is three columns to the right.
                if (targetTileIndex.Item2 == (originTileIndex.Item2 + 3))
                {
                    // Check first stop.
                    Tuple<int, int> firstStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 + 1));
                    Tile firstStopTile = board.GetTileByIndex(firstStopTileIndex.Item1, firstStopTileIndex.Item2);

                    // If first stop is unoccupied then finally check target tile.
                    if (!gameManager.boardManager.IsTargetTileOccupied(firstStopTile.tilePos))
                    {
                        // Check second stop.
                        Tuple<int, int> secondStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 + 2));
                        Tile secondStopTile = board.GetTileByIndex(secondStopTileIndex.Item1, secondStopTileIndex.Item2);

                        // If second stop is unoccupied then finally check target tile.
                        if (!gameManager.boardManager.IsTargetTileOccupied(secondStopTile.tilePos))
                        {
                            if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                            {
                                success = true;
                            }
                        }
                    }
                }
                // If target tile is three columns to the left.
                else if (targetTileIndex.Item2 == (originTileIndex.Item2 - 3))
                {
                    // Check first stop.
                    Tuple<int, int> firstStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 - 1));
                    Tile firstStopTile = board.GetTileByIndex(firstStopTileIndex.Item1, firstStopTileIndex.Item2);

                    // If first stop is unoccupied then finally check target tile.
                    if (!gameManager.boardManager.IsTargetTileOccupied(firstStopTile.tilePos))
                    {
                        // Check second stop.
                        Tuple<int, int> secondStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 - 2));
                        Tile secondStopTile = board.GetTileByIndex(secondStopTileIndex.Item1, secondStopTileIndex.Item2);

                        // If second stop is unoccupied then finally check target tile.
                        if (!gameManager.boardManager.IsTargetTileOccupied(secondStopTile.tilePos))
                        {
                            if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                            {
                                success = true;
                            }
                        }
                    }
                }
            }


            return success;
        }

        private bool ValidateFourPositionMove(bool success, BoardManager board, Tuple<int, int> originTileIndex, Tuple<int, int> targetTileIndex, bool isTargetTileOccupied, bool isTargetTileOccupiedByOpposingPlayer)
        {
            // If target tile is on the same column.
            if (targetTileIndex.Item2 == originTileIndex.Item2)
            {
                // If target tile is four rows up.
                if (targetTileIndex.Item1 == (originTileIndex.Item1 + 4))
                {
                    // Check first stop.
                    Tuple<int, int> firstStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 + 1), originTileIndex.Item2);
                    Tile firstStopTile = board.GetTileByIndex(firstStopTileIndex.Item1, firstStopTileIndex.Item2);

                    if (!gameManager.boardManager.IsTargetTileOccupied(firstStopTile.tilePos))
                    {
                        // Check second stop.
                        Tuple<int, int> secondStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 + 2), originTileIndex.Item2);
                        Tile secondStopTile = board.GetTileByIndex(secondStopTileIndex.Item1, secondStopTileIndex.Item2);

                        if (!gameManager.boardManager.IsTargetTileOccupied(secondStopTile.tilePos))
                        {
                            // Check third stop.
                            Tuple<int, int> thirdStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 + 3), originTileIndex.Item2);
                            Tile thirdStopTile = board.GetTileByIndex(thirdStopTileIndex.Item1, thirdStopTileIndex.Item2);

                            // If third stop is unoccupied then finally check target tile.
                            if (!gameManager.boardManager.IsTargetTileOccupied(thirdStopTile.tilePos))
                            {
                                if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                                {
                                    success = true;
                                }
                            }
                        }
                    }
                }
                // If target tile is four rows down
                else if (targetTileIndex.Item1 == (originTileIndex.Item1 - 4))
                {
                    // Check first stop.
                    Tuple<int, int> firstStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 - 1), originTileIndex.Item2);
                    Tile firstStopTile = board.GetTileByIndex(firstStopTileIndex.Item1, firstStopTileIndex.Item2);

                    if (!gameManager.boardManager.IsTargetTileOccupied(firstStopTile.tilePos))
                    {
                        // Check second stop.
                        Tuple<int, int> secondStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 - 2), originTileIndex.Item2);
                        Tile secondStopTile = board.GetTileByIndex(secondStopTileIndex.Item1, secondStopTileIndex.Item2);

                        // If second stop is unoccupied then finally check target tile.
                        if (!gameManager.boardManager.IsTargetTileOccupied(secondStopTile.tilePos))
                        {
                            // Check third stop.
                            Tuple<int, int> thirdStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 - 3), originTileIndex.Item2);
                            Tile thirdStopTile = board.GetTileByIndex(thirdStopTileIndex.Item1, thirdStopTileIndex.Item2);

                            // If third stop is unoccupied then finally check target tile.
                            if (!gameManager.boardManager.IsTargetTileOccupied(thirdStopTile.tilePos))
                            {
                                if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                                {
                                    success = true;
                                }
                            }
                        }
                    }
                }
            }
            // If target tile is on the same row.
            else if (targetTileIndex.Item1 == originTileIndex.Item1)
            {

                // If target tile is four columns to the right.
                if (targetTileIndex.Item2 == (originTileIndex.Item2 + 4))
                {
                    // Check first stop.
                    Tuple<int, int> firstStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 + 1));
                    Tile firstStopTile = board.GetTileByIndex(firstStopTileIndex.Item1, firstStopTileIndex.Item2);

                    // If first stop is unoccupied then finally check target tile.
                    if (!gameManager.boardManager.IsTargetTileOccupied(firstStopTile.tilePos))
                    {
                        // Check second stop.
                        Tuple<int, int> secondStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 + 2));
                        Tile secondStopTile = board.GetTileByIndex(secondStopTileIndex.Item1, secondStopTileIndex.Item2);

                        // If second stop is unoccupied then finally check target tile.
                        if (!gameManager.boardManager.IsTargetTileOccupied(secondStopTile.tilePos))
                        {
                            // Check third stop.
                            Tuple<int, int> thirdStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 + 3));
                            Tile thirdStopTile = board.GetTileByIndex(thirdStopTileIndex.Item1, thirdStopTileIndex.Item2);

                            // If third stop is unoccupied then finally check target tile.
                            if (!gameManager.boardManager.IsTargetTileOccupied(thirdStopTile.tilePos))
                            {
                                if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                                {
                                    success = true;
                                }
                            }
                        }
                    }
                }
                // If target tile is four columns to the left.
                else if (targetTileIndex.Item2 == (originTileIndex.Item2 - 4))
                {
                    // Check first stop.
                    Tuple<int, int> firstStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 - 1));
                    Tile firstStopTile = board.GetTileByIndex(firstStopTileIndex.Item1, firstStopTileIndex.Item2);

                    // If first stop is unoccupied then finally check target tile.
                    if (!gameManager.boardManager.IsTargetTileOccupied(firstStopTile.tilePos))
                    {
                        // Check second stop.
                        Tuple<int, int> secondStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 - 2));
                        Tile secondStopTile = board.GetTileByIndex(secondStopTileIndex.Item1, secondStopTileIndex.Item2);

                        // If second stop is unoccupied then finally check target tile.
                        if (!gameManager.boardManager.IsTargetTileOccupied(secondStopTile.tilePos))
                        {
                            // Check third stop.
                            Tuple<int, int> thirdStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 - 3));
                            Tile thirdStopTile = board.GetTileByIndex(thirdStopTileIndex.Item1, thirdStopTileIndex.Item2);

                            // If third stop is unoccupied then finally check target tile.
                            if (!gameManager.boardManager.IsTargetTileOccupied(thirdStopTile.tilePos))
                            {
                                if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                                {
                                    success = true;
                                }
                            }
                        }
                    }
                }
            }

            return success;
        }

        private bool ValidateFivePositionMove(bool success, BoardManager board, Tuple<int, int> originTileIndex, Tuple<int, int> targetTileIndex, bool isTargetTileOccupied, bool isTargetTileOccupiedByOpposingPlayer)
        {
            // If target tile is on the same column.
            if (targetTileIndex.Item2 == originTileIndex.Item2)
            {
                // If target tile is five rows up.
                if (targetTileIndex.Item1 == (originTileIndex.Item1 + 5))
                {
                    // Check first stop.
                    Tuple<int, int> firstStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 + 1), originTileIndex.Item2);
                    Tile firstStopTile = board.GetTileByIndex(firstStopTileIndex.Item1, firstStopTileIndex.Item2);

                    if (!gameManager.boardManager.IsTargetTileOccupied(firstStopTile.tilePos))
                    {
                        // Check second stop.
                        Tuple<int, int> secondStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 + 2), originTileIndex.Item2);
                        Tile secondStopTile = board.GetTileByIndex(secondStopTileIndex.Item1, secondStopTileIndex.Item2);

                        if (!gameManager.boardManager.IsTargetTileOccupied(secondStopTile.tilePos))
                        {
                            // Check third stop.
                            Tuple<int, int> thirdStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 + 3), originTileIndex.Item2);
                            Tile thirdStopTile = board.GetTileByIndex(thirdStopTileIndex.Item1, thirdStopTileIndex.Item2);

                            if (!gameManager.boardManager.IsTargetTileOccupied(thirdStopTile.tilePos))
                            {
                                // Check fourth stop.
                                Tuple<int, int> fourthStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 + 4), originTileIndex.Item2);
                                Tile fourthStopTile = board.GetTileByIndex(fourthStopTileIndex.Item1, fourthStopTileIndex.Item2);

                                // If fourth stop is unoccupied then finally check target tile.
                                if (!gameManager.boardManager.IsTargetTileOccupied(fourthStopTile.tilePos))
                                {
                                    if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                                    {
                                        success = true;
                                    }
                                }
                            }
                        }
                    }
                }
                // If target tile is five rows down
                else if (targetTileIndex.Item1 == (originTileIndex.Item1 - 5))
                {
                    // Check first stop.
                    Tuple<int, int> firstStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 - 1), originTileIndex.Item2);
                    Tile firstStopTile = board.GetTileByIndex(firstStopTileIndex.Item1, firstStopTileIndex.Item2);

                    if (!gameManager.boardManager.IsTargetTileOccupied(firstStopTile.tilePos))
                    {
                        // Check second stop.
                        Tuple<int, int> secondStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 - 2), originTileIndex.Item2);
                        Tile secondStopTile = board.GetTileByIndex(secondStopTileIndex.Item1, secondStopTileIndex.Item2);

                        // If second stop is unoccupied then finally check target tile.
                        if (!gameManager.boardManager.IsTargetTileOccupied(secondStopTile.tilePos))
                        {
                            // Check third stop.
                            Tuple<int, int> thirdStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 - 3), originTileIndex.Item2);
                            Tile thirdStopTile = board.GetTileByIndex(thirdStopTileIndex.Item1, thirdStopTileIndex.Item2);

                            // If third stop is unoccupied then finally check target tile.
                            if (!gameManager.boardManager.IsTargetTileOccupied(thirdStopTile.tilePos))
                            {
                                // Check fourth stop.
                                Tuple<int, int> fourthStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 - 4), originTileIndex.Item2);
                                Tile fourthStopTile = board.GetTileByIndex(fourthStopTileIndex.Item1, fourthStopTileIndex.Item2);

                                // If fourth stop is unoccupied then finally check target tile.
                                if (!gameManager.boardManager.IsTargetTileOccupied(fourthStopTile.tilePos))
                                {
                                    if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                                    {
                                        success = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            // If target tile is on the same row.
            else if (targetTileIndex.Item1 == originTileIndex.Item1)
            {

                // If target tile is five columns to the right.
                if (targetTileIndex.Item2 == (originTileIndex.Item2 + 5))
                {
                    // Check first stop.
                    Tuple<int, int> firstStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 + 1));
                    Tile firstStopTile = board.GetTileByIndex(firstStopTileIndex.Item1, firstStopTileIndex.Item2);

                    // If first stop is unoccupied then finally check target tile.
                    if (!gameManager.boardManager.IsTargetTileOccupied(firstStopTile.tilePos))
                    {
                        // Check second stop.
                        Tuple<int, int> secondStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 + 2));
                        Tile secondStopTile = board.GetTileByIndex(secondStopTileIndex.Item1, secondStopTileIndex.Item2);

                        // If second stop is unoccupied then finally check target tile.
                        if (!gameManager.boardManager.IsTargetTileOccupied(secondStopTile.tilePos))
                        {
                            // Check third stop.
                            Tuple<int, int> thirdStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 + 3));
                            Tile thirdStopTile = board.GetTileByIndex(thirdStopTileIndex.Item1, thirdStopTileIndex.Item2);

                            if (!gameManager.boardManager.IsTargetTileOccupied(thirdStopTile.tilePos))
                            {
                                // Check fourth stop.
                                Tuple<int, int> fourthStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 + 4));
                                Tile fourthStopTile = board.GetTileByIndex(fourthStopTileIndex.Item1, fourthStopTileIndex.Item2);

                                // If fourth stop is unoccupied then finally check target tile.
                                if (!gameManager.boardManager.IsTargetTileOccupied(fourthStopTile.tilePos))
                                {
                                    if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                                    {
                                        success = true;
                                    }
                                }
                            }
                        }
                    }
                }
                // If target tile is five columns to the left.
                else if (targetTileIndex.Item2 == (originTileIndex.Item2 - 5))
                {
                    // Check first stop.
                    Tuple<int, int> firstStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 - 1));
                    Tile firstStopTile = board.GetTileByIndex(firstStopTileIndex.Item1, firstStopTileIndex.Item2);

                    // If first stop is unoccupied then finally check target tile.
                    if (!gameManager.boardManager.IsTargetTileOccupied(firstStopTile.tilePos))
                    {
                        // Check second stop.
                        Tuple<int, int> secondStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 - 2));
                        Tile secondStopTile = board.GetTileByIndex(secondStopTileIndex.Item1, secondStopTileIndex.Item2);

                        // If second stop is unoccupied then finally check target tile.
                        if (!gameManager.boardManager.IsTargetTileOccupied(secondStopTile.tilePos))
                        {
                            // Check third stop.
                            Tuple<int, int> thirdStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 - 3));
                            Tile thirdStopTile = board.GetTileByIndex(thirdStopTileIndex.Item1, thirdStopTileIndex.Item2);

                            if (!gameManager.boardManager.IsTargetTileOccupied(thirdStopTile.tilePos))
                            {
                                // Check fourth stop.
                                Tuple<int, int> fourthStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 - 4));
                                Tile fourthStopTile = board.GetTileByIndex(fourthStopTileIndex.Item1, fourthStopTileIndex.Item2);

                                // If fourth stop is unoccupied then finally check target tile.
                                if (!gameManager.boardManager.IsTargetTileOccupied(fourthStopTile.tilePos))
                                {
                                    if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                                    {
                                        success = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return success;
        }

        private bool ValidateSixPositionMove(bool success, BoardManager board, Tuple<int, int> originTileIndex, Tuple<int, int> targetTileIndex, bool isTargetTileOccupied, bool isTargetTileOccupiedByOpposingPlayer)
        {
            // If target tile is on the same column.
            if (targetTileIndex.Item2 == originTileIndex.Item2)
            {
                // If target tile is six rows up.
                if (targetTileIndex.Item1 == (originTileIndex.Item1 + 5))
                {
                    // Check first stop.
                    Tuple<int, int> firstStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 + 1), originTileIndex.Item2);
                    Tile firstStopTile = board.GetTileByIndex(firstStopTileIndex.Item1, firstStopTileIndex.Item2);

                    if (!gameManager.boardManager.IsTargetTileOccupied(firstStopTile.tilePos))
                    {
                        // Check second stop.
                        Tuple<int, int> secondStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 + 2), originTileIndex.Item2);
                        Tile secondStopTile = board.GetTileByIndex(secondStopTileIndex.Item1, secondStopTileIndex.Item2);

                        if (!gameManager.boardManager.IsTargetTileOccupied(secondStopTile.tilePos))
                        {
                            // Check third stop.
                            Tuple<int, int> thirdStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 + 3), originTileIndex.Item2);
                            Tile thirdStopTile = board.GetTileByIndex(thirdStopTileIndex.Item1, thirdStopTileIndex.Item2);

                            if (!gameManager.boardManager.IsTargetTileOccupied(thirdStopTile.tilePos))
                            {
                                // Check fourth stop.
                                Tuple<int, int> fourthStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 + 4), originTileIndex.Item2);
                                Tile fourthStopTile = board.GetTileByIndex(fourthStopTileIndex.Item1, fourthStopTileIndex.Item2);

                                if (!gameManager.boardManager.IsTargetTileOccupied(fourthStopTile.tilePos))
                                {
                                    // Check fifth stop.
                                    Tuple<int, int> fifthStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 + 5), originTileIndex.Item2);
                                    Tile fifththStopTile = board.GetTileByIndex(fifthStopTileIndex.Item1, fifthStopTileIndex.Item2);

                                    // If fifth stop is unoccupied then finally check target tile.
                                    if (!gameManager.boardManager.IsTargetTileOccupied(fifththStopTile.tilePos))
                                    {
                                        if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                                        {
                                            success = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                // If target tile is six rows down
                else if (targetTileIndex.Item1 == (originTileIndex.Item1 - 5))
                {
                    // Check first stop.
                    Tuple<int, int> firstStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 - 1), originTileIndex.Item2);
                    Tile firstStopTile = board.GetTileByIndex(firstStopTileIndex.Item1, firstStopTileIndex.Item2);

                    if (!gameManager.boardManager.IsTargetTileOccupied(firstStopTile.tilePos))
                    {
                        // Check second stop.
                        Tuple<int, int> secondStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 - 2), originTileIndex.Item2);
                        Tile secondStopTile = board.GetTileByIndex(secondStopTileIndex.Item1, secondStopTileIndex.Item2);

                        // If second stop is unoccupied then finally check target tile.
                        if (!gameManager.boardManager.IsTargetTileOccupied(secondStopTile.tilePos))
                        {
                            // Check third stop.
                            Tuple<int, int> thirdStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 - 3), originTileIndex.Item2);
                            Tile thirdStopTile = board.GetTileByIndex(thirdStopTileIndex.Item1, thirdStopTileIndex.Item2);

                            // If third stop is unoccupied then finally check target tile.
                            if (!gameManager.boardManager.IsTargetTileOccupied(thirdStopTile.tilePos))
                            {
                                // Check fourth stop.
                                Tuple<int, int> fourthStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 - 4), originTileIndex.Item2);
                                Tile fourthStopTile = board.GetTileByIndex(fourthStopTileIndex.Item1, fourthStopTileIndex.Item2);

                                if (!gameManager.boardManager.IsTargetTileOccupied(fourthStopTile.tilePos))
                                {
                                    // Check fifth stop.
                                    Tuple<int, int> fifthStopTileIndex = new Tuple<int, int>((originTileIndex.Item1 - 5), originTileIndex.Item2);
                                    Tile fifththStopTile = board.GetTileByIndex(fifthStopTileIndex.Item1, fifthStopTileIndex.Item2);

                                    // If fifth stop is unoccupied then finally check target tile.
                                    if (!gameManager.boardManager.IsTargetTileOccupied(fifththStopTile.tilePos))
                                    {
                                        if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                                        {
                                            success = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            // If target tile is on the same row.
            else if (targetTileIndex.Item1 == originTileIndex.Item1)
            {

                // If target tile is six columns to the right.
                if (targetTileIndex.Item2 == (originTileIndex.Item2 + 5))
                {
                    // Check first stop.
                    Tuple<int, int> firstStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 + 1));
                    Tile firstStopTile = board.GetTileByIndex(firstStopTileIndex.Item1, firstStopTileIndex.Item2);

                    // If first stop is unoccupied then finally check target tile.
                    if (!gameManager.boardManager.IsTargetTileOccupied(firstStopTile.tilePos))
                    {
                        // Check second stop.
                        Tuple<int, int> secondStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 + 2));
                        Tile secondStopTile = board.GetTileByIndex(secondStopTileIndex.Item1, secondStopTileIndex.Item2);

                        // If second stop is unoccupied then finally check target tile.
                        if (!gameManager.boardManager.IsTargetTileOccupied(secondStopTile.tilePos))
                        {
                            // Check third stop.
                            Tuple<int, int> thirdStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 + 3));
                            Tile thirdStopTile = board.GetTileByIndex(thirdStopTileIndex.Item1, thirdStopTileIndex.Item2);

                            if (!gameManager.boardManager.IsTargetTileOccupied(thirdStopTile.tilePos))
                            {
                                // Check fourth stop.
                                Tuple<int, int> fourthStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 + 4));
                                Tile fourthStopTile = board.GetTileByIndex(fourthStopTileIndex.Item1, fourthStopTileIndex.Item2);

                                if (!gameManager.boardManager.IsTargetTileOccupied(fourthStopTile.tilePos))
                                {
                                    // Check fifth stop.
                                    Tuple<int, int> fifthStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 + 5));
                                    Tile fifththStopTile = board.GetTileByIndex(fifthStopTileIndex.Item1, fifthStopTileIndex.Item2);

                                    // If fifth stop is unoccupied then finally check target tile.
                                    if (!gameManager.boardManager.IsTargetTileOccupied(fifththStopTile.tilePos))
                                    {
                                        if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                                        {
                                            success = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                // If target tile is six columns to the left.
                else if (targetTileIndex.Item2 == (originTileIndex.Item2 - 5))
                {
                    // Check first stop.
                    Tuple<int, int> firstStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 - 1));
                    Tile firstStopTile = board.GetTileByIndex(firstStopTileIndex.Item1, firstStopTileIndex.Item2);

                    // If first stop is unoccupied then finally check target tile.
                    if (!gameManager.boardManager.IsTargetTileOccupied(firstStopTile.tilePos))
                    {
                        // Check second stop.
                        Tuple<int, int> secondStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 - 2));
                        Tile secondStopTile = board.GetTileByIndex(secondStopTileIndex.Item1, secondStopTileIndex.Item2);

                        // If second stop is unoccupied then finally check target tile.
                        if (!gameManager.boardManager.IsTargetTileOccupied(secondStopTile.tilePos))
                        {
                            // Check third stop.
                            Tuple<int, int> thirdStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 - 3));
                            Tile thirdStopTile = board.GetTileByIndex(thirdStopTileIndex.Item1, thirdStopTileIndex.Item2);

                            if (!gameManager.boardManager.IsTargetTileOccupied(thirdStopTile.tilePos))
                            {
                                // Check fourth stop.
                                Tuple<int, int> fourthStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 - 4));
                                Tile fourthStopTile = board.GetTileByIndex(fourthStopTileIndex.Item1, fourthStopTileIndex.Item2);

                                if (!gameManager.boardManager.IsTargetTileOccupied(fourthStopTile.tilePos))
                                {
                                    // Check fifth stop.
                                    Tuple<int, int> fifthStopTileIndex = new Tuple<int, int>(originTileIndex.Item1, (originTileIndex.Item2 - 5));
                                    Tile fifththStopTile = board.GetTileByIndex(fifthStopTileIndex.Item1, fifthStopTileIndex.Item2);

                                    // If fifth stop is unoccupied then finally check target tile.
                                    if (!gameManager.boardManager.IsTargetTileOccupied(fifththStopTile.tilePos))
                                    {
                                        if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                                        {
                                            success = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return success;
        }
    }
}