using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConstants
{
    public static Vector3 CAM_POSITION_PLAYER1 = new Vector3(16, 30, -13);
    public static Vector3 CAM_POSITION_PLAYER2 = new Vector3(16, 30, 45);
    public static Vector3 CAM_ROTATION_PLAYER1 = new Vector3(50, 0, 0);
    public static Vector3 CAM_ROTATION_PLAYER2 = new Vector3(-233, 0, -180);

    public static Vector3 PIECE_ROTATION_PLAYER2 = new Vector3(0, 180, 0);

    public static Vector3[] PAWN_SPAWN_POSITIONS_PLAYER_1;
    public static Vector3[] PAWN_SPAWN_POSITIONS_PLAYER_2;
    public static Vector3[] BISHOP_SPAWN_POSITIONS_PLAYER_1;
    public static Vector3[] BISHOP_SPAWN_POSITIONS_PLAYER_2;
    public static Vector3[] ROOK_SPAWN_POSITIONS_PLAYER_1;
    public static Vector3[] ROOK_SPAWN_POSITIONS_PLAYER_2;
    public static Vector3[] KNIGHT_SPAWN_POSITIONS_PLAYER_1;
    public static Vector3[] KNIGHT_SPAWN_POSITIONS_PLAYER_2;
    public static Vector3[] MAGE_SPAWN_POSITIONS_PLAYER_1;
    public static Vector3[] MAGE_SPAWN_POSITIONS_PLAYER_2;
    public static Vector3[] KING_SPAWN_POSITIONS_PLAYER_1;
    public static Vector3[] KING_SPAWN_POSITIONS_PLAYER_2;

    public static Vector3 PIECE_POSITION_A1 = new Vector3(-3.4f, 0, 1.4f);
    public static Vector3 PIECE_POSITION_B1 = new Vector3(1.89f, 0, 1.4f);
    public static Vector3 PIECE_POSITION_C1 = new Vector3(6.94f, 0, 1.4f);
    public static Vector3 PIECE_POSITION_D1 = new Vector3(12.04f, 0, 1.4f);
    public static Vector3 PIECE_POSITION_E1 = new Vector3(17.05f, 0, 1.4f);
    public static Vector3 PIECE_POSITION_F1 = new Vector3(22.13f, 0, 1.4f);
    public static Vector3 PIECE_POSITION_G1 = new Vector3(27.16f, 0, 1.4f);
    public static Vector3 PIECE_POSITION_H1 = new Vector3(32.15f, 0, 1.4f);

    public static Vector3 PIECE_POSITION_A2 = new Vector3(-0.94f, 0, 5.83f);
    public static Vector3 PIECE_POSITION_B2 = new Vector3(4.19f, 0, 5.83f);
    public static Vector3 PIECE_POSITION_C2 = new Vector3(9.39f, 0, 5.83f);
    public static Vector3 PIECE_POSITION_D2 = new Vector3(14.52f, 0, 5.83f);
    public static Vector3 PIECE_POSITION_E2 = new Vector3(19.5f, 0, 5.83f);
    public static Vector3 PIECE_POSITION_F2 = new Vector3(24.55f, 0, 5.83f);
    public static Vector3 PIECE_POSITION_G2 = new Vector3(29.61f, 0, 5.83f);
    public static Vector3 PIECE_POSITION_H2 = new Vector3(34.67f, 0, 5.83f);

    public static Vector3 PIECE_POSITION_A3 = new Vector3(-3.4f, 0, 9.94f);
    public static Vector3 PIECE_POSITION_B3 = new Vector3(1.89f, 0, 9.94f);
    public static Vector3 PIECE_POSITION_C3 = new Vector3(6.94f, 0, 9.94f);
    public static Vector3 PIECE_POSITION_D3 = new Vector3(12.04f, 0, 9.94f);
    public static Vector3 PIECE_POSITION_E3 = new Vector3(17.05f, 0, 9.94f);
    public static Vector3 PIECE_POSITION_F3 = new Vector3(22.13f, 0, 9.94f);
    public static Vector3 PIECE_POSITION_G3 = new Vector3(27.16f, 0, 9.94f);
    public static Vector3 PIECE_POSITION_H3 = new Vector3(32.15f, 0, 9.94f);

    public static Vector3 PIECE_POSITION_A4 = new Vector3(-0.94f, 0, 14.27f);
    public static Vector3 PIECE_POSITION_B4 = new Vector3(4.19f, 0, 14.27f);
    public static Vector3 PIECE_POSITION_C4 = new Vector3(9.39f, 0, 14.27f);
    public static Vector3 PIECE_POSITION_D4 = new Vector3(14.52f, 0, 14.27f);
    public static Vector3 PIECE_POSITION_E4 = new Vector3(19.5f, 0, 14.27f);
    public static Vector3 PIECE_POSITION_F4 = new Vector3(24.55f, 0, 14.27f);
    public static Vector3 PIECE_POSITION_G4 = new Vector3(29.61f, 0, 14.27f);
    public static Vector3 PIECE_POSITION_H4 = new Vector3(34.67f, 0, 14.27f);

    public static Vector3 PIECE_POSITION_A5 = new Vector3(-3.4f, 0, 18.63f);
    public static Vector3 PIECE_POSITION_B5 = new Vector3(1.89f, 0, 18.63f);
    public static Vector3 PIECE_POSITION_C5 = new Vector3(6.94f, 0, 18.63f);
    public static Vector3 PIECE_POSITION_D5 = new Vector3(12.04f, 0, 18.63f);
    public static Vector3 PIECE_POSITION_E5 = new Vector3(17.05f, 0, 18.63f);
    public static Vector3 PIECE_POSITION_F5 = new Vector3(22.13f, 0, 18.63f);
    public static Vector3 PIECE_POSITION_G5 = new Vector3(27.16f, 0, 18.63f);
    public static Vector3 PIECE_POSITION_H5 = new Vector3(32.15f, 0, 18.63f);

    public static Vector3 PIECE_POSITION_A6 = new Vector3(-0.94f, 0, 23.04f);
    public static Vector3 PIECE_POSITION_B6 = new Vector3(4.19f, 0, 23.04f);
    public static Vector3 PIECE_POSITION_C6 = new Vector3(9.39f, 0, 23.04f);
    public static Vector3 PIECE_POSITION_D6 = new Vector3(14.52f, 0, 23.04f);
    public static Vector3 PIECE_POSITION_E6 = new Vector3(19.5f, 0, 23.04f);
    public static Vector3 PIECE_POSITION_F6 = new Vector3(24.55f, 0, 23.04f);
    public static Vector3 PIECE_POSITION_G6 = new Vector3(29.61f, 0, 23.04f);
    public static Vector3 PIECE_POSITION_H6 = new Vector3(34.67f, 0, 23.04f);

    public static Vector3 PIECE_POSITION_A7 = new Vector3(-3.4f, 0, 27.44f);
    public static Vector3 PIECE_POSITION_B7 = new Vector3(1.89f, 0, 27.44f);
    public static Vector3 PIECE_POSITION_C7 = new Vector3(6.94f, 0, 27.44f);
    public static Vector3 PIECE_POSITION_D7 = new Vector3(12.04f, 0, 27.44f);
    public static Vector3 PIECE_POSITION_E7 = new Vector3(17.05f, 0, 27.44f);
    public static Vector3 PIECE_POSITION_F7 = new Vector3(22.13f, 0, 27.44f);
    public static Vector3 PIECE_POSITION_G7 = new Vector3(27.16f, 0, 27.44f);
    public static Vector3 PIECE_POSITION_H7 = new Vector3(32.15f, 0, 27.44f);

    public static Vector3 PIECE_POSITION_A8 = new Vector3(-0.94f, 0, 31.79f);
    public static Vector3 PIECE_POSITION_B8 = new Vector3(4.19f, 0, 31.79f);
    public static Vector3 PIECE_POSITION_C8 = new Vector3(9.39f, 0, 31.79f);
    public static Vector3 PIECE_POSITION_D8 = new Vector3(14.52f, 0, 31.79f);
    public static Vector3 PIECE_POSITION_E8 = new Vector3(19.5f, 0, 31.79f);
    public static Vector3 PIECE_POSITION_F8 = new Vector3(24.55f, 0, 31.79f);
    public static Vector3 PIECE_POSITION_G8 = new Vector3(29.61f, 0, 31.79f);
    public static Vector3 PIECE_POSITION_H8 = new Vector3(34.67f, 0, 31.79f);

    public static void Init()
    {
        PAWN_SPAWN_POSITIONS_PLAYER_1 = new Vector3[8]
        {
            PIECE_POSITION_A2,
            PIECE_POSITION_B2,
            PIECE_POSITION_C2,
            PIECE_POSITION_D2,
            PIECE_POSITION_E2,
            PIECE_POSITION_F2,
            PIECE_POSITION_G2,
            PIECE_POSITION_H2,
        };

        PAWN_SPAWN_POSITIONS_PLAYER_2 = new Vector3[8]
        {
            PIECE_POSITION_A7,
            PIECE_POSITION_B7,
            PIECE_POSITION_C7,
            PIECE_POSITION_D7,
            PIECE_POSITION_E7,
            PIECE_POSITION_F7,
            PIECE_POSITION_G7,
            PIECE_POSITION_H7,
        };

        BISHOP_SPAWN_POSITIONS_PLAYER_1 = new Vector3[2]
        {
            PIECE_POSITION_A1,
            PIECE_POSITION_H1,
        };

        BISHOP_SPAWN_POSITIONS_PLAYER_2 = new Vector3[2]
        {
            PIECE_POSITION_A8,
            PIECE_POSITION_H8,
        };

        ROOK_SPAWN_POSITIONS_PLAYER_1 = new Vector3[2]
        {
            PIECE_POSITION_C1,
            PIECE_POSITION_F1,
        };

        ROOK_SPAWN_POSITIONS_PLAYER_2 = new Vector3[2]
        {
            PIECE_POSITION_C8,
            PIECE_POSITION_F8,
        };

        KNIGHT_SPAWN_POSITIONS_PLAYER_1 = new Vector3[2]
        {
            PIECE_POSITION_B1,
            PIECE_POSITION_G1,
        };

        KNIGHT_SPAWN_POSITIONS_PLAYER_2 = new Vector3[2]
        {
            PIECE_POSITION_B8,
            PIECE_POSITION_G8,
        };

        MAGE_SPAWN_POSITIONS_PLAYER_1 = new Vector3[1]
        {
            PIECE_POSITION_D1,
        };

        MAGE_SPAWN_POSITIONS_PLAYER_2 = new Vector3[1]
        {
            PIECE_POSITION_D8,
        };

        KING_SPAWN_POSITIONS_PLAYER_1 = new Vector3[1]
        {
            PIECE_POSITION_E1,
        };

        KING_SPAWN_POSITIONS_PLAYER_2 = new Vector3[1]
        {
            PIECE_POSITION_E8,
        };
    }
}
