using ChessPrototype.Base;
using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype
{
    public class TurnManager : NetworkBehaviour
    {
        public static TurnManager Instance { get; private set; }
        public NetworkGameManager network;
        public GameManager gameManager;

        [SyncVar]
        public bool isGameStarted;
        [SyncVar]
        public bool hasMovedThisTurn;
        [SyncVar]
        public int turnNumber;
        [SyncVar(hook = nameof(HighlightSelectedTileOnTurnChange))]
        public PlayerIndex player;
        [SyncVar]
        public float gameTimer_player1;
        [SyncVar]
        public float gameTimer_player2;

        private void Awake()
        {
            Instance = this;
            gameManager = FindObjectOfType<GameManager>();

            isGameStarted = false;
            turnNumber = 0;
            player = PlayerIndex.None;
        }

        private void Update()
        {
            if (!isGameStarted)
                return;

            DecrementGameTime();
        }

        public void Init(NetworkGameManager net)
        {
            this.network = net;

            gameTimer_player1 = 1800;
            gameTimer_player2 = 1800;

            isGameStarted = true;

            IncrementTurn();

        }

        public void IncrementTurn()
        {
            turnNumber++;
            hasMovedThisTurn = false;

            switch (player)
            {
                case PlayerIndex.Player1:
                    player = PlayerIndex.Player2;
                    break;
                case PlayerIndex.Player2:
                    player = PlayerIndex.Player1;
                    break;
                case PlayerIndex.None:
                    player = PlayerIndex.Player1;
                    break;
                default:
                    break;
            }
        }

        private void DecrementGameTime()
        {
            switch (player)
            {
                case PlayerIndex.Player1:
                    gameTimer_player1 -= Time.deltaTime;
                    break;
                case PlayerIndex.Player2:
                    gameTimer_player2 -= Time.deltaTime;
                    break;
                default:
                    break;
            }
        }

        private void HighlightSelectedTileOnTurnChange(PlayerIndex oldPlayer, PlayerIndex newPlayer)
        {
            if (!isServer)
                return;

            if (newPlayer == PlayerIndex.Player1)
            {
                TargetHighlightTiles(NetworkServer.connections[0]);
            }
            else
            {
                TargetHighlightTiles(NetworkServer.connections[1]);
            }
        }

        [TargetRpc]
        private void TargetHighlightTiles(NetworkConnection conn)
        {
            Tile selectedTile = gameManager.uIManager.CurrentSelectedTile;

            if (selectedTile == null)
                return;

            StartCoroutine(HighlightValidTilesAfterPeriod(selectedTile));
        }

        private IEnumerator HighlightValidTilesAfterPeriod(Tile selectedTile)
        { 
            yield return new WaitForSeconds(0.5f);
            gameManager.boardManager.HighlightValidTiles(selectedTile, true);
        }

    }
}