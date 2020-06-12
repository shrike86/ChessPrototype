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

        [SyncVar]
        public bool isGameStarted;
        [SyncVar]
        public bool isPieceAttacking;
        [SyncVar]
        public bool isPieceMoving;
        [SyncVar]
        public int turnNumber;
        [SyncVar]
        public PlayerIndex player;
        [SyncVar]
        public float gameTimer_player1;
        [SyncVar]
        public float gameTimer_player2;

        private void Awake()
        {
            Instance = this;

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

        [Command]
        public void CmdIncrementTurn()
        {
            IncrementTurn();
        }

        public void IncrementTurn()
        {
            turnNumber++;

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

    }
}