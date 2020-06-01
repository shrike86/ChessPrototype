using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.Base
{
    public class BoardManager : MonoBehaviour
    {
        public Tile[,] tilePositions;

        public GameObject pawnPrefab;
        public GameObject knightPrefab;
        public GameObject rookPrefab;
        public GameObject bishopPrefab;
        public GameObject magePrefab;
        public GameObject kingPrefab;

        private void Start()
        {
            tilePositions = new Tile[8, 8];
            Tile[] tiles = GetComponentsInChildren<Tile>();

            FillTilePositions(tiles);
            InitTiles(tiles);
        }

        public GameObject GetPiecePrefab(CurrentPiece piece)
        {
            switch (piece)
            {
                case CurrentPiece.Pawn:
                    return pawnPrefab;
                case CurrentPiece.Knight:
                    return knightPrefab;
                case CurrentPiece.Rook:
                    return rookPrefab;
                case CurrentPiece.Bishop:
                    return bishopPrefab;
                case CurrentPiece.Mage:
                    return magePrefab;
                case CurrentPiece.King:
                    return kingPrefab;
                default:
                    return null;
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

        private void InitTiles(Tile[] tiles)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].Init(this, i);
            }
        }

    }
}