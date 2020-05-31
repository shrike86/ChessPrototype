using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.Base
{
    public class GameManager : NetworkManager
    {
        public Vector3 camPos_player1 = new Vector3(16, 30, 13);
        public Vector3 camPos_player2 = new Vector3(16, 30, 45);
        public Vector3 camRot_player1 = new Vector3(50, 0, 0);
        public Vector3 camRot_player2 = new Vector3(-233, 0, -180);

    }
}