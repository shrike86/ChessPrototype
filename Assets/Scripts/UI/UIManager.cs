using ChessPrototype.Base;
using ChessPrototype.Pieces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.UI
{
    public class UIManager : MonoBehaviour
    {
        public event Action<Tile> OnSelectedTileChanged;

        public Tile CurrentSelectedTile
        {
            get { return currentSelectedTile; }
            set
            {
                if(currentSelectedTile != null)
                    OnSelectedTileChanged(currentSelectedTile);

                currentSelectedTile = value; 
            }
        }

        private Tile currentSelectedTile;


    }
}