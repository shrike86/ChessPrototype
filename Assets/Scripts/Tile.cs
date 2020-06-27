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
    public class Tile : NetworkBehaviour
    {
        [SyncVar]
        public TilePositionName tilePos;
        [SyncVar]
        public PieceType networkPiece;
        [SyncVar]
        public PlayerIndex occupyingPlayer;
        [SyncVar]
        public int currentPieceId;
        public bool isSelected;
        public bool isHighlightingValidMoves;

        private BoardManager boardManager;

        public bool IsSelected
        {
            get { return isSelected; }
            set 
            { 
                isSelected = value;

                // Don't allow selection of empy tiles.
                if (occupyingPlayer == PlayerIndex.None)
                    return;

                if (boardManager == null)
                    boardManager = GetComponentInParent<BoardManager>();

                if (isSelected)
                {
                    // In the case that the new selected tile shares a valid move with the old, give the old tile some time to be cleared so it doesn't override.
                    StartCoroutine(WaitForResetThenHighlightValidTiles());
                }
                else
                {
                    boardManager.HighlightValidTiles(this, false);
                    isHighlightingValidMoves = false;
                }
            }
        }

        public void Init(BoardManager manager, int index)
        {
            this.boardManager = manager;
            isHighlightingValidMoves = false;

            if (isServer)
            {
                SetTilePosition(index);
                SetNonPlayerIndexes(index);
            }
        }

        private void SetNonPlayerIndexes(int index)
        {
            // Tiles in row range 3 - 6 will not be occupied on start.
            if (Enumerable.Range(15, 46).Contains(index))
            {
                occupyingPlayer = PlayerIndex.None;
            }
        }

        private void SetTilePosition(int index)
        {
            tilePos = (TilePositionName)index;
        }

        private IEnumerator WaitForResetThenHighlightValidTiles()
        {
            yield return new WaitForEndOfFrame();

            boardManager.HighlightValidTiles(this, true);
            isHighlightingValidMoves = true;
        }
    }

    public enum TilePositionName : byte
    {
        A1, B1, C1, D1, E1, F1, G1, H1,
        A2, B2, C2, D2, E2, F2, G2, H2,
        A3, B3, C3, D3, E3, F3, G3, H3,
        A4, B4, C4, D4, E4, F4, G4, H4,
        A5, B5, C5, D5, E5, F5, G5, H5,
        A6, B6, C6, D6, E6, F6, G6, H6,
        A7, B7, C7, D7, E7, F7, G7, H7,
        A8, B8, C8, D8, E8, F8, G8, H8,
    }

    public enum PieceType : byte
    {
        Empty = 0,
        Pawn = 1,
        Knight = 2,
        Rook = 3,
        Bishop = 4,
        Mage = 5,
        King = 6
    }
}