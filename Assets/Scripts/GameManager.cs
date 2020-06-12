using ChessPrototype.Pieces;
using ChessPrototype.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.Base
{
    public class GameManager : MonoBehaviour
    {
        public SelectTile selectTile;

        public InputManager inputManager;
        public UIManager uIManager;
        public BoardManager boardManager;

        public new Camera camera;

        private void Start()
        {
            inputManager = GetComponent<InputManager>();
            uIManager = GetComponent<UIManager>();
        }

        public void Init(Camera cam)
        {
            this.camera = cam;

            inputManager.Init(this, camera);
            selectTile.Init(this);
        }

        public Tile GetTile()
        {
            Tile hitTile = null;

            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            int layerMask = 1 << 9;

            if (Physics.Raycast(ray, out hit, layerMask))
            {
                hitTile = hit.transform.GetComponentInParent<Tile>();
            }

            return hitTile;
        }
    }
}