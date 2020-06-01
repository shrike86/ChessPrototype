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

        private NetworkGameManager networkGameManager;

        public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();

            networkGameManager = NetworkManager.singleton as NetworkGameManager;

            SpawnPlayerCamera();
            SpawnPieces();
        }

        private void SpawnPlayerCamera()
        {
            Vector3 pos = networkGameManager.GetCameraPosition(playerIndex);

            Vector3 euler = networkGameManager.GetCameraEuler(playerIndex);
            Quaternion rot = Quaternion.Euler(euler.x, euler.y, euler.z);

            GameObject camera = Instantiate(cameraPrefab, cameraHolder.transform);

            camera.transform.localPosition = pos;
            camera.transform.localRotation = rot;
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
        Player2
    }
}