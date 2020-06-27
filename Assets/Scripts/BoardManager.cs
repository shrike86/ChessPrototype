using ChessPrototype.Pieces;
using ChessPrototype.UI;
using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ChessPrototype.Base
{
    public class BoardManager : MonoBehaviour
    {
        public Tile[,] tilePositions;
        public Tile[] tiles;

        public GameObject pawnPrefab;
        public GameObject knightPrefab;
        public GameObject rookPrefab;
        public GameObject bishopPrefab;
        public GameObject magePrefab;
        public GameObject kingPrefab;

        private NetworkGameManager network;

        public Material highlightMat;
        public Material defaultMat;

        private void Start()
        {
            tilePositions = new Tile[8, 8];
            tiles = GetComponentsInChildren<Tile>();

            FillTilePositions(tiles);
            InitTiles(tiles);
        }

        public void InitOnClient()
        {
            tilePositions = new Tile[8, 8];
            tiles = GetComponentsInChildren<Tile>();

            FillTilePositions(tiles);
            InitTiles(tiles);
        }

        public bool IsTargetTileEmpty(TilePositionName name)
        {
            Tile targetTile = GetTileByPositionName(name);
            return targetTile.occupyingPlayer == PlayerIndex.None;
        }

        public bool IsTargetTileOccupiedByOpposingPlayer(TilePositionName name, PlayerIndex callingPlayer)
        {
            Tile targetTile = GetTileByPositionName(name);

            switch (callingPlayer)
            {
                case PlayerIndex.Player1:
                    return targetTile.occupyingPlayer == PlayerIndex.Player2;
                case PlayerIndex.Player2:
                    return targetTile.occupyingPlayer == PlayerIndex.Player1;
                default:
                    return false;
            }
        }

        public GameObject GetPiecePrefab(PieceType piece)
        {
            switch (piece)
            {
                case PieceType.Pawn:
                    return pawnPrefab;
                case PieceType.Knight:
                    return knightPrefab;
                case PieceType.Rook:
                    return rookPrefab;
                case PieceType.Bishop:
                    return bishopPrefab;
                case PieceType.Mage:
                    return magePrefab;
                case PieceType.King:
                    return kingPrefab;
                default:
                    return null;
            }
        }

        public Tile GetTileByPositionName(TilePositionName pos)
        {
            Tile tile = null;

            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    if (tilePositions[i, j].tilePos == pos)
                    {
                        tile = tilePositions[i, j];
                    }
                }
            }

            return tile;
        }

        public void HighlightValidTiles(Tile selectedTle, bool highlight)
        {
            // get piece through tile.
            int pieceId = selectedTle.currentPieceId;

            if (network == null)
                network = FindObjectOfType<NetworkGameManager>();

            Piece piece = network.pieces.Where(p => p.pieceId == pieceId).Single();

            // Don't allow highlighting of an enemy piece.
            if (!piece.hasAuthority && highlight)
                return;

            // Only allow highlighting of tiles when it is your turn and a piece hasn't moved already that turn.
            if (piece.player != TurnManager.Instance.player || TurnManager.Instance.hasMovedThisTurn)
                return;

            PieceType type = piece.GetPieceType(piece);

            switch (type)
            {
                case PieceType.Empty:
                    break;
                case PieceType.Pawn:
                    Pawn pawn = piece as Pawn;

                    for (int i = 0; i < tiles.Length; i++)
                    {
                        bool valid = pawn.ValidateMove(selectedTle.tilePos, tiles[i].tilePos, selectedTle, tiles[i], true);

                        if (valid)
                        {
                            TileOutline outline = tiles[i].GetComponentInChildren<TileOutline>();

                            if (highlight)
                            {
                                outline.UpdateRendererMaterial(highlightMat);
                            }
                            else
                            {
                                outline.UpdateRendererMaterial(defaultMat);
                            }
                        }
                    }
                    break;
                case PieceType.Knight:
                    Knight knight = piece as Knight;

                    for (int i = 0; i < tiles.Length; i++)
                    {
                        bool valid = knight.ValidateMove(selectedTle.tilePos, tiles[i].tilePos, selectedTle, tiles[i], true);

                        if (valid)
                        {
                            TileOutline outline = tiles[i].GetComponentInChildren<TileOutline>();

                            if (highlight)
                            {
                                outline.UpdateRendererMaterial(highlightMat);
                            }
                            else
                            {
                                outline.UpdateRendererMaterial(defaultMat);
                            }
                        }
                    }
                    break;
                case PieceType.Rook:
                    Rook rook = piece as Rook;

                    for (int i = 0; i < tiles.Length; i++)
                    {
                        bool valid = rook.ValidateMove(selectedTle.tilePos, tiles[i].tilePos, selectedTle, tiles[i], true);

                        if (valid)
                        {
                            TileOutline outline = tiles[i].GetComponentInChildren<TileOutline>();

                            if (highlight)
                            {
                                outline.UpdateRendererMaterial(highlightMat);
                            }
                            else
                            {
                                outline.UpdateRendererMaterial(defaultMat);
                            }
                        }
                    }
                    break;
                case PieceType.Bishop:
                    Bishop bishop = piece as Bishop;

                    for (int i = 0; i < tiles.Length; i++)
                    {
                        bool valid = bishop.ValidateMove(selectedTle.tilePos, tiles[i].tilePos, selectedTle, tiles[i], true);

                        if (valid)
                        {
                            TileOutline outline = tiles[i].GetComponentInChildren<TileOutline>();

                            if (highlight)
                            {
                                outline.UpdateRendererMaterial(highlightMat);
                            }
                            else
                            {
                                outline.UpdateRendererMaterial(defaultMat);
                            }
                        }
                    }
                    break;
                case PieceType.Mage:
                    Mage mage = piece as Mage;

                    for (int i = 0; i < tiles.Length; i++)
                    {
                        bool valid = mage.ValidateMove(selectedTle.tilePos, tiles[i].tilePos, selectedTle, tiles[i], true);

                        if (valid)
                        {
                            TileOutline outline = tiles[i].GetComponentInChildren<TileOutline>();

                            if (highlight)
                            {
                                outline.UpdateRendererMaterial(highlightMat);
                            }
                            else
                            {
                                outline.UpdateRendererMaterial(defaultMat);
                            }
                        }
                    }
                    break;
                case PieceType.King:
                    King king = piece as King;

                    for (int i = 0; i < tiles.Length; i++)
                    {
                        bool valid = king.ValidateMove(selectedTle.tilePos, tiles[i].tilePos, selectedTle, tiles[i], true);

                        if (valid)
                        {
                            TileOutline outline = tiles[i].GetComponentInChildren<TileOutline>();

                            if (highlight)
                            {
                                outline.UpdateRendererMaterial(highlightMat);
                            }
                            else
                            {
                                outline.UpdateRendererMaterial(defaultMat);
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public void ClearTileHighlights()
        {
            foreach (Tile tile in tiles)
            {
                TileOutline t = tile.GetComponentInChildren<TileOutline>();
                t.UpdateRendererMaterial(defaultMat);
            }
        }

        public Tile GetTileByIndex(int row, int column)
        {
            return tilePositions[row, column];
        }

        public Tuple<int, int> GetTileIndexByName(TilePositionName name)
        {
            Tuple<int, int> tileIndex = null;

            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    if (tilePositions[i, j].tilePos == name)
                    {
                        tileIndex = new Tuple<int, int>(i, j);
                    }
                }
            }

            if (tileIndex == null)
            {
                Debug.Log("Could not get a tile index for position name: " + name);
            }

            return tileIndex;
        }

        private void InitTiles(Tile[] tiles)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].Init(this, i);
            }
        }

        private void FillTilePositions(Tile[] tiles)
        {
            int j = 0;

            for (int i = 0; i < tiles.Length; i++)
            {
                if (i <= 7)
                {
                    tilePositions[0, i] = tiles[i];
                }
                else if (i > 7 && i <= 15)
                {
                    tilePositions[1, j] = tiles[i];
                    j++;
                }
                else if (i > 15 && i <= 23)
                {
                    if (i == 16)
                        j = 0;

                    tilePositions[2, j] = tiles[i];
                    j++;
                }
                else if (i > 23 && i <= 31)
                {
                    if (i == 24)
                        j = 0;

                    tilePositions[3, j] = tiles[i];
                    j++;
                }
                else if (i > 31 && i <= 39)
                {
                    if (i == 32)
                        j = 0;

                    tilePositions[4, j] = tiles[i];
                    j++;
                }
                else if (i > 39 && i <= 47)
                {
                    if (i == 40)
                        j = 0;

                    tilePositions[5, j] = tiles[i];
                    j++;
                }
                else if (i > 47 && i <= 55)
                {
                    if (i == 48)
                        j = 0;

                    tilePositions[6, j] = tiles[i];
                    j++;
                }
                else if (i > 55 && i <= 63)
                {
                    if (i == 56)
                        j = 0;

                    tilePositions[7, j] = tiles[i];
                    j++;
                }

            }
        }

    }
}