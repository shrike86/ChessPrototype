using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.Base
{
    public class NetworkGameManager : NetworkManager
    {
        public BoardManager boardManager;

        public bool isHost;

        public override void Start()
        {
            base.Start();

            GameConstants.Init();

            if (isHost)
            {
                StartHost();
            }
            else
            {
                StartClient();
            }
        }

        public override void OnStartServer()
        {
            base.OnStartServer();

            NetworkServer.RegisterHandler<ClientSpawnPlayerRequest>(SpawnPlayer);
            NetworkServer.RegisterHandler<ClientSpawnPiecesRequest>(SpawnPieces);
        }

        public Vector3 GetCameraPosition(PlayerIndex index)
        {
            switch (index)
            {
                case PlayerIndex.Player1:
                    return GameConstants.CAM_POSITION_PLAYER1;
                case PlayerIndex.Player2:
                    return GameConstants.CAM_POSITION_PLAYER2;
                default:
                    return Vector3.zero;
            }
        }

        public Vector3 GetCameraEuler(PlayerIndex index)
        {
            switch (index)
            {
                case PlayerIndex.Player1:
                    return GameConstants.CAM_ROTATION_PLAYER1;
                case PlayerIndex.Player2:
                    return GameConstants.CAM_ROTATION_PLAYER2;
                default:
                    return Vector3.zero;
            }
        }

        public override void OnClientConnect(NetworkConnection conn)
        {
            ClientSpawnPlayerRequest spawnPlayerRequest = new ClientSpawnPlayerRequest();

            if (isHost)
            {
                spawnPlayerRequest.isHost = true;
            }
            else
            {
                spawnPlayerRequest.isHost = false;
            }

            if (!ClientScene.ready) ClientScene.Ready(conn);

            conn.Send(spawnPlayerRequest);
        }

        private void SpawnPlayer(NetworkConnection conn, ClientSpawnPlayerRequest msg)
        {
            GameObject go = Instantiate(playerPrefab);
            PlayerManager player = go.GetComponent<PlayerManager>();

            if (msg.isHost)
            {
                player.playerIndex = PlayerIndex.Player1;
            }
            else
            {
                player.playerIndex = PlayerIndex.Player2;
            }

            NetworkServer.AddPlayerForConnection(conn, go);
        }

        private void SpawnPieces(NetworkConnection conn, ClientSpawnPiecesRequest msg)
        {
            switch (msg.index)
            {
                case PlayerIndex.Player1:
                    SpawnPawns(conn, PlayerIndex.Player1);
                    SpawnBishops(conn, PlayerIndex.Player1);
                    SpawnRooks(conn, PlayerIndex.Player1);
                    SpawnKnights(conn, PlayerIndex.Player1);
                    SpawnMages(conn, PlayerIndex.Player1);
                    SpawnKingss(conn, PlayerIndex.Player1);
                    break;
                case PlayerIndex.Player2:
                    SpawnPawns(conn, PlayerIndex.Player2);
                    SpawnBishops(conn, PlayerIndex.Player2);
                    SpawnRooks(conn, PlayerIndex.Player2);
                    SpawnKnights(conn, PlayerIndex.Player2);
                    SpawnMages(conn, PlayerIndex.Player2);
                    SpawnKingss(conn, PlayerIndex.Player2);
                    break;
                default:
                    break;
            }
        }

        private void SpawnPawns(NetworkConnection conn, PlayerIndex playerIndex)
        {
            for (int i = 0; i <= 7; i++)
            {
                SpawnPiece(i, playerIndex, CurrentPiece.Pawn, conn);
            }
        }

        private void SpawnBishops(NetworkConnection conn, PlayerIndex playerIndex)
        {
            for (int i = 0; i <= 1; i++)
            {
                SpawnPiece(i, playerIndex, CurrentPiece.Bishop, conn);
            }
        }

        private void SpawnRooks(NetworkConnection conn, PlayerIndex playerIndex)
        {
            for (int i = 0; i <= 1; i++)
            {
                SpawnPiece(i, playerIndex, CurrentPiece.Rook, conn);
            }
        }

        private void SpawnKnights(NetworkConnection conn, PlayerIndex playerIndex)
        {
            for (int i = 0; i <= 1; i++)
            {
                SpawnPiece(i, playerIndex, CurrentPiece.Knight, conn);
            }
        }

        private void SpawnMages(NetworkConnection conn, PlayerIndex playerIndex)
        {
            for (int i = 0; i == 0; i++)
            {
                SpawnPiece(i, playerIndex, CurrentPiece.Mage, conn);
            }
        }

        private void SpawnKingss(NetworkConnection conn, PlayerIndex playerIndex)
        {
            for (int i = 0; i == 0; i++)
            {
                SpawnPiece(i, playerIndex, CurrentPiece.King, conn);
            }
        }

        private GameObject SpawnPiece(int pieceIndex, PlayerIndex playerIndex, CurrentPiece piece, NetworkConnection conn)
        {
            GameObject go = null;

            switch (playerIndex)
            {
                case PlayerIndex.Player1:
                    switch (piece)
                    {
                        case CurrentPiece.Empty:
                            break;
                        case CurrentPiece.Pawn:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.PAWN_SPAWN_POSITIONS_PLAYER_1[pieceIndex], Quaternion.identity);
                            break;
                        case CurrentPiece.Knight:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.KNIGHT_SPAWN_POSITIONS_PLAYER_1[pieceIndex], Quaternion.identity);
                            break;
                        case CurrentPiece.Rook:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.ROOK_SPAWN_POSITIONS_PLAYER_1[pieceIndex], Quaternion.identity);
                            break;
                        case CurrentPiece.Bishop:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.BISHOP_SPAWN_POSITIONS_PLAYER_1[pieceIndex], Quaternion.identity);
                            break;
                        case CurrentPiece.Mage:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.MAGE_SPAWN_POSITIONS_PLAYER_1[pieceIndex], Quaternion.identity);
                            break;
                        case CurrentPiece.King:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.KING_SPAWN_POSITIONS_PLAYER_1[pieceIndex], Quaternion.identity);
                            break;
                        default:
                            break;
                    }
                    break;
                case PlayerIndex.Player2:
                    Quaternion rotation = Quaternion.Euler(GameConstants.PIECE_ROTATION_PLAYER2.x, GameConstants.PIECE_ROTATION_PLAYER2.y, GameConstants.PIECE_ROTATION_PLAYER2.z);

                    switch (piece)
                    {
                        case CurrentPiece.Empty:
                            break;
                        case CurrentPiece.Pawn:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.PAWN_SPAWN_POSITIONS_PLAYER_2[pieceIndex], rotation);
                            break;
                        case CurrentPiece.Knight:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.KNIGHT_SPAWN_POSITIONS_PLAYER_2[pieceIndex], rotation);
                            break;
                        case CurrentPiece.Rook:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.ROOK_SPAWN_POSITIONS_PLAYER_2[pieceIndex], rotation);
                            break;
                        case CurrentPiece.Bishop:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.BISHOP_SPAWN_POSITIONS_PLAYER_2[pieceIndex], rotation);
                            break;
                        case CurrentPiece.Mage:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.MAGE_SPAWN_POSITIONS_PLAYER_2[pieceIndex], rotation);
                            break;
                        case CurrentPiece.King:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.KING_SPAWN_POSITIONS_PLAYER_2[pieceIndex], rotation);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            NetworkServer.Spawn(go, conn);

            return go;
        }

        public class ClientSpawnPlayerRequest : MessageBase { public bool isHost; }

        public class ClientSpawnPiecesRequest : MessageBase { public PlayerIndex index; }
    }
}