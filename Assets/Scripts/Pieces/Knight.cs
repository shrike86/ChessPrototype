using ChessPrototype.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.Pieces
{
    public class Knight : Piece
    {
        public override bool ValidateMove(TilePositionName originTilePos, TilePositionName targetTilePos, Tile originTile, Tile targetTile)
        {
            bool success = false;

            BoardManager board = gameManager.boardManager;
            Tuple<int, int> originTileIndex = board.GetTileIndexByName(originTilePos);
            Tuple<int, int> targetTileIndex = board.GetTileIndexByName(targetTilePos);

            bool isTargetTileOccupied = gameManager.boardManager.IsTargetTileOccupied(targetTile.tilePos);
            bool isTargetTileOccupiedByOpposingPlayer = gameManager.boardManager.IsTargetTileOccupiedByOpposingPlayer(targetTile.tilePos, originTile.occupyingPlayer);

            switch (originTile.occupyingPlayer)
            {
                case PlayerIndex.Player1:
                    if (targetTileIndex.Item1 == (originTileIndex.Item1 + 2))
                    {
                        if (targetTileIndex.Item2 == (originTileIndex.Item2 + 1) || targetTileIndex.Item2 == (originTileIndex.Item2 - 1))
                        {
                            if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                            {
                                success = true;
                            }
                        }
                    }
                    if (targetTileIndex.Item1 == (originTileIndex.Item1 - 2))
                    {
                        if (targetTileIndex.Item2 == (originTileIndex.Item2 + 1) || targetTileIndex.Item2 == (originTileIndex.Item2 - 1))
                        {
                            if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                            {
                                success = true;
                            }
                        }
                    }
                    break;
                case PlayerIndex.Player2:
                    if (targetTileIndex.Item1 == (originTileIndex.Item1 - 2))
                    {
                        if (targetTileIndex.Item2 == (originTileIndex.Item2 + 1) || targetTileIndex.Item2 == (originTileIndex.Item2 - 1))
                        {
                            if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                            {
                                success = true;
                            }
                        }
                    }
                    if (targetTileIndex.Item1 == (originTileIndex.Item1 + 2))
                    {
                        if (targetTileIndex.Item2 == (originTileIndex.Item2 + 1) || targetTileIndex.Item2 == (originTileIndex.Item2 - 1))
                        {
                            if (!isTargetTileOccupied || isTargetTileOccupiedByOpposingPlayer)
                            {
                                success = true;
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