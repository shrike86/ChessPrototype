using ChessPrototype.Pieces;
using ChessPrototype.UI;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ChessPrototype.Base.NetworkGameManager;

namespace ChessPrototype.Base
{
    public class PlayerManager : NetworkBehaviour
    {
        [SyncVar]
        public PlayerIndex playerIndex;

        public GameObject cameraPrefab;
        public GameObject cameraHolder;
        public Camera mainCamera;

        public NetworkGameManager networkGameManager;
        public GameManager gameManager;

        public MoveManager movePiece;

        public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();

            networkGameManager = NetworkManager.singleton as NetworkGameManager;
            gameManager = FindObjectOfType<GameManager>();
            movePiece = GetComponent<MoveManager>();

            SpawnPlayerCamera();
            SpawnPieces();

            gameManager.Init(mainCamera);
            movePiece.Init(gameManager, this);
        }

        private void SpawnPlayerCamera()
        {
            Vector3 pos = networkGameManager.GetCameraPosition(playerIndex);

            Vector3 euler = networkGameManager.GetCameraEuler(playerIndex);
            Quaternion rot = Quaternion.Euler(euler.x, euler.y, euler.z);

            GameObject camera = Instantiate(cameraPrefab, cameraHolder.transform);

            camera.transform.localPosition = pos;
            camera.transform.localRotation = rot;

            mainCamera = camera.GetComponentInChildren<Camera>();
        }

        private void SpawnPieces()
        {
            ClientSpawnPiecesRequest spawnPiecesRequest = new ClientSpawnPiecesRequest();
            spawnPiecesRequest.index = playerIndex;

            connectionToServer.Send(spawnPiecesRequest);
        }
    }

    public enum PlayerIndex : byte
    { 
        Player1,
        Player2,
        None
    }
}