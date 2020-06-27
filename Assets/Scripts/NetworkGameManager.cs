using ChessPrototype.Pieces;
using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ChessPrototype.Base
{
    public class NetworkGameManager : NetworkManager
    {
        public BoardManager boardManager;
        public TurnManager turnManager;

        public List<Piece> pieces = new List<Piece>();

        public bool isHost;
        public bool allPlayersConnected;
        public bool isTurnManagerInit;

        private int pieceIndex;

        private float updateTick = 1f;
        private float timer;


        public override void Start()
        {
            base.Start();

            pieceIndex = 1;
            timer = 0;

            allPlayersConnected = false;
            isTurnManagerInit = false;

            GameConstants.Init();

            if (isHost)
            {
                StartHost();
            }
            else
            {
                StartClient();
            }

            if (boardManager == null)
                boardManager = FindObjectOfType<BoardManager>();
        }

        private void Update()
        {
            if (turnManager == null)
                turnManager = FindObjectOfType<TurnManager>();

            if (!isHost)
                return;

            MonitorAllPlayersConnected();

            if (!allPlayersConnected)
                return;

            InitTurnManager();
        }

        public override void OnStartServer()
        {
            base.OnStartServer();

            NetworkServer.RegisterHandler<ClientSpawnPlayerRequest>(SpawnPlayer);
            NetworkServer.RegisterHandler<ClientSpawnPiecesRequest>(SpawnPieces);
        }

        public override void OnStartClient()
        {
            base.OnStartClient();

            if (isHost)
                return;

            NetworkClient.RegisterHandler<ServerSpawnPiecesComplete>(ClientFillPieces);
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

        public void AssignPieceToTile(TilePositionName tileName, PieceType piece, PlayerIndex player, int pieceId)
        {
            Tile tile = boardManager.GetTileByPositionName(tileName);

            tile.networkPiece = piece;
            tile.occupyingPlayer = player;
            tile.currentPieceId = pieceId;
        }

        public void UnassignPieceFromTile(TilePositionName tileName)
        {
            Tile tile = boardManager.GetTileByPositionName(tileName);

            tile.networkPiece = PieceType.Empty;
            tile.occupyingPlayer = PlayerIndex.None;
            tile.currentPieceId = 0;
        }

        public bool AllPlayersConnected() => numPlayers == 2;

        private void MonitorAllPlayersConnected()
        {
            if (!allPlayersConnected)
            {
                timer += Time.deltaTime;

                if (timer >= updateTick)
                {
                    allPlayersConnected = AllPlayersConnected();
                    timer = 0;
                }
            }
        }

        private void InitTurnManager()
        {
            if (allPlayersConnected && !turnManager.isGameStarted)
            {
                turnManager.Init(this);
            }
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
                    SpawnPawns(conn, PlayerIndex.Player1, ref pieceIndex);
                    SpawnBishops(conn, PlayerIndex.Player1, ref pieceIndex);
                    SpawnRooks(conn, PlayerIndex.Player1, ref pieceIndex);
                    SpawnKnights(conn, PlayerIndex.Player1, ref pieceIndex);
                    SpawnMages(conn, PlayerIndex.Player1, ref pieceIndex);
                    SpawnKingss(conn, PlayerIndex.Player1, ref pieceIndex);
                    break;
                case PlayerIndex.Player2:
                    SpawnPawns(conn, PlayerIndex.Player2, ref pieceIndex);
                    SpawnBishops(conn, PlayerIndex.Player2, ref pieceIndex);
                    SpawnRooks(conn, PlayerIndex.Player2, ref pieceIndex);
                    SpawnKnights(conn, PlayerIndex.Player2, ref pieceIndex);
                    SpawnMages(conn, PlayerIndex.Player2, ref pieceIndex);
                    SpawnKingss(conn, PlayerIndex.Player2, ref pieceIndex);

                    ServerSpawnPiecesComplete finishedMsg = new ServerSpawnPiecesComplete();
                    conn.Send(finishedMsg);
                    break;
                default:
                    break;
            }
        }

        private void ClientFillPieces(NetworkConnection conn, ServerSpawnPiecesComplete msg)
        {
            Piece[] p = FindObjectsOfType<Piece>();

            foreach (var piece in p)
            {
                pieces.Add(piece);
            }

            boardManager.InitOnClient();
        }

        private void SpawnPawns(NetworkConnection conn, PlayerIndex playerIndex, ref int pieceIndex)
        {
            for (int i = 0; i <= 7; i++)
            {
                GameObject pieceGo = SpawnPiece(i, playerIndex, PieceType.Pawn, conn);
                Piece piece = null;
                int pieceId = AssignPieceId(pieceGo, ref pieceIndex, playerIndex, ref piece);

                Pawn pawn = piece as Pawn;
                pawn.InitPawnPiece();
                pawn.SetPieceColour(playerIndex);

                AssignStartingPositions(pieceId, i, PieceType.Pawn, playerIndex);
            }
        }

        private void SpawnBishops(NetworkConnection conn, PlayerIndex playerIndex, ref int pieceIndex)
        {
            GameObject bishop1 = SpawnPiece(0, playerIndex, PieceType.Bishop, conn);
            Piece piece1 = null;
            int pieceId = AssignPieceId(bishop1, ref pieceIndex, playerIndex, ref piece1);
            AssignStartingPositions(pieceId, 0, PieceType.Bishop, playerIndex);

            Bishop b1 = piece1 as Bishop;
            b1.SetPieceColour(playerIndex);

            GameObject bishop2 = SpawnPiece(1, playerIndex, PieceType.Bishop, conn);
            Piece piece2 = null;
            int pieceId2 = AssignPieceId(bishop2, ref pieceIndex, playerIndex, ref piece2);
            AssignStartingPositions(pieceId2, 7, PieceType.Bishop, playerIndex);

            Bishop b2 = piece2 as Bishop;
            b2.SetPieceColour(playerIndex);
        }

        private void SpawnRooks(NetworkConnection conn, PlayerIndex playerIndex, ref int pieceIndex)
        {
            GameObject rook1 = SpawnPiece(0, playerIndex, PieceType.Rook, conn);
            Piece piece1 = null;
            int pieceId = AssignPieceId(rook1, ref pieceIndex, playerIndex, ref piece1);
            AssignStartingPositions(pieceId, 2, PieceType.Rook, playerIndex);

            Rook r1 = piece1 as Rook;
            r1.SetPieceColour(playerIndex);

            GameObject rook2 = SpawnPiece(1, playerIndex, PieceType.Rook, conn);
            Piece piece2 = null;
            int pieceId2 = AssignPieceId(rook2, ref pieceIndex, playerIndex, ref piece2);
            AssignStartingPositions(pieceId2, 5, PieceType.Rook, playerIndex);

            Rook r2 = piece2 as Rook;
            r2.SetPieceColour(playerIndex);
        }

        private void SpawnKnights(NetworkConnection conn, PlayerIndex playerIndex, ref int pieceIndex)
        {
            GameObject knight1 = SpawnPiece(0, playerIndex, PieceType.Knight, conn);
            Piece piece1 = null;
            int pieceId = AssignPieceId(knight1, ref pieceIndex, playerIndex, ref piece1);
            AssignStartingPositions(pieceId, 1, PieceType.Knight, playerIndex);

            Knight k1 = piece1 as Knight;
            k1.SetPieceColour(playerIndex);

            GameObject knight2 = SpawnPiece(1, playerIndex, PieceType.Knight, conn);
            Piece piece2 = null;
            int pieceId2 = AssignPieceId(knight2, ref pieceIndex, playerIndex, ref piece2);
            AssignStartingPositions(pieceId2, 6, PieceType.Knight, playerIndex);

            Knight k2 = piece2 as Knight;
            k2.SetPieceColour(playerIndex);
        }

        private void SpawnMages(NetworkConnection conn, PlayerIndex playerIndex, ref int pieceIndex)
        {
            GameObject mage = SpawnPiece(0, playerIndex, PieceType.Mage, conn);
            Piece piece = null;
            int pieceId = AssignPieceId(mage, ref pieceIndex, playerIndex, ref piece);
            AssignStartingPositions(pieceId, 3, PieceType.Mage, playerIndex);

            Mage m = piece as Mage;
            m.SetPieceColour(playerIndex);
        }

        private void SpawnKingss(NetworkConnection conn, PlayerIndex playerIndex, ref int pieceIndex)
        {
            GameObject king = SpawnPiece(0, playerIndex, PieceType.King, conn);
            Piece piece = null;
            int pieceId = AssignPieceId(king, ref pieceIndex, playerIndex, ref piece);
            AssignStartingPositions(pieceId, 4, PieceType.King, playerIndex);

            King k = piece as King;
            k.SetPieceColour(playerIndex);
        }


        private GameObject SpawnPiece(int pieceIndex, PlayerIndex playerIndex, PieceType piece, NetworkConnection conn)
        {
            GameObject go = null;

            switch (playerIndex)
            {
                case PlayerIndex.Player1:
                    Quaternion rot_player1 = Quaternion.Euler(GameConstants.LOOK_DIRECTION_PLAYER1.x, GameConstants.LOOK_DIRECTION_PLAYER1.y, GameConstants.LOOK_DIRECTION_PLAYER1.z);

                    switch (piece)
                    {
                        case PieceType.Empty:
                            break;
                        case PieceType.Pawn:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.PAWN_SPAWN_POSITIONS_PLAYER_1[pieceIndex], rot_player1);
                            break;
                        case PieceType.Knight:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.KNIGHT_SPAWN_POSITIONS_PLAYER_1[pieceIndex], rot_player1);
                            break;
                        case PieceType.Rook:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.ROOK_SPAWN_POSITIONS_PLAYER_1[pieceIndex], rot_player1);
                            break;
                        case PieceType.Bishop:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.BISHOP_SPAWN_POSITIONS_PLAYER_1[pieceIndex], rot_player1);
                            break;
                        case PieceType.Mage:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.MAGE_SPAWN_POSITIONS_PLAYER_1[pieceIndex], rot_player1);
                            break;
                        case PieceType.King:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.KING_SPAWN_POSITIONS_PLAYER_1[pieceIndex], rot_player1);
                            break;
                        default:
                            break;
                    }
                    break;
                case PlayerIndex.Player2:
                    Quaternion rot_player2 = Quaternion.Euler(GameConstants.LOOK_DIRECTION_PLAYER2.x, GameConstants.LOOK_DIRECTION_PLAYER2.y, GameConstants.LOOK_DIRECTION_PLAYER2.z);

                    switch (piece)
                    {
                        case PieceType.Empty:
                            break;
                        case PieceType.Pawn:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.PAWN_SPAWN_POSITIONS_PLAYER_2[pieceIndex], rot_player2);
                            break;
                        case PieceType.Knight:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.KNIGHT_SPAWN_POSITIONS_PLAYER_2[pieceIndex], rot_player2);
                            break;
                        case PieceType.Rook:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.ROOK_SPAWN_POSITIONS_PLAYER_2[pieceIndex], rot_player2);
                            break;
                        case PieceType.Bishop:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.BISHOP_SPAWN_POSITIONS_PLAYER_2[pieceIndex], rot_player2);
                            break;
                        case PieceType.Mage:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.MAGE_SPAWN_POSITIONS_PLAYER_2[pieceIndex], rot_player2);
                            break;
                        case PieceType.King:
                            go = Instantiate(boardManager.GetPiecePrefab(piece), GameConstants.KING_SPAWN_POSITIONS_PLAYER_2[pieceIndex], rot_player2);
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

        private int AssignPieceId(GameObject pieceGo, ref int pieceIndex, PlayerIndex player, ref Piece piece)
        {
            piece = pieceGo.GetComponent<Piece>();
            piece.pieceId = pieceIndex;
            piece.player = player;
            pieceIndex++;

            pieces.Add(piece);

            return piece.pieceId;
        }

        private void AssignStartingPositions(int pieceId, int pieceIndex, PieceType piece, PlayerIndex player)
        {
            Tile tile = null;

            switch (player)
            {
                case PlayerIndex.Player1:
                    if (piece == PieceType.Pawn)
                    {
                        Tuple<int, int> tilePosPawn = new Tuple<int, int>(1, pieceIndex);
                        SetTileValuesOnStart(tile, tilePosPawn, piece, player, pieceId);
                    }
                    else
                    {
                        Tuple<int, int> tilePos = new Tuple<int, int>(0, pieceIndex);
                        SetTileValuesOnStart(tile, tilePos, piece, player, pieceId);
                    }
                    break;
                case PlayerIndex.Player2:
                    if (piece == PieceType.Pawn)
                    {
                        Tuple<int, int> tilePosPawn = new Tuple<int, int>(6, pieceIndex);
                        SetTileValuesOnStart(tile, tilePosPawn, piece, player, pieceId);
                    }
                    else
                    {
                        Tuple<int, int> tilePos = new Tuple<int, int>(7, pieceIndex);
                        SetTileValuesOnStart(tile, tilePos, piece, player, pieceId);
                    }
                    break;
                default:
                    break;
            }
        }

        private void SetTileValuesOnStart(Tile tile, Tuple<int, int> tilePos, PieceType piece, PlayerIndex player, int pieceId)
        {
            tile = boardManager.tilePositions[tilePos.Item1, tilePos.Item2];

            tile.networkPiece = piece;
            tile.occupyingPlayer = player;
            tile.currentPieceId = pieceId;

            SetPiecesCurrentTile(pieceId, tile);
        }

        private void SetPiecesCurrentTile(int pieceId, Tile tile)
        {
            Piece p = pieces.Where(piece => piece.pieceId == pieceId).Single();
            p.currentTile = tile.tilePos;
        }

        public class ClientSpawnPlayerRequest : MessageBase { public bool isHost; }

        public class ClientSpawnPiecesRequest : MessageBase { public PlayerIndex index; }
        public class ServerSpawnPiecesComplete : MessageBase { }
    }
}