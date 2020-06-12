using ChessPrototype.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.UI
{
    public class SelectTile : MonoBehaviour
    {
        public GameManager gameManager;

        public Material defaultMat;
        public Material selectedMat;

        public void Init(GameManager gameManager)
        {
            this.gameManager = gameManager;

            gameManager.uIManager.OnSelectedTileChanged += DeselectPreviousSelectedTile;
            gameManager.inputManager.OnSingleClick += SelectTileOnMouseDown;
        }

        private void SelectTileOnMouseDown(Tile tile)
        {
            if (gameManager == null)
                return;

            if (tile == null || tile.isSelected)
                return;

            tile.isSelected = !tile.isSelected;

            gameManager.uIManager.CurrentSelectedTile = tile;

            if (tile.isSelected)
            {
                TileOutline outline = tile.GetComponentInChildren<TileOutline>();
                outline.UpdateRendererMaterial(selectedMat);
            }
        }

        private void DeselectPreviousSelectedTile(Tile tile)
        {
            tile.isSelected = false;
            TileOutline outline = tile.GetComponentInChildren<TileOutline>();
            outline.UpdateRendererMaterial(defaultMat);
        }
    }
}