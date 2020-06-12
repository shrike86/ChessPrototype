using ChessPrototype.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConstants
{
    public static Vector3 CAM_POSITION_PLAYER1 = new Vector3(-5, 34, -21.5f);
    public static Vector3 CAM_POSITION_PLAYER2 = new Vector3(47.5f, 34, -21.5f);
    public static Vector3 CAM_ROTATION_PLAYER1 = new Vector3(60, 90, 0);
    public static Vector3 CAM_ROTATION_PLAYER2 = new Vector3(60, -90, 0);

    public static Vector3 LOOK_DIRECTION_PLAYER1 = new Vector3(0, 90, 0);
    public static Vector3 LOOK_DIRECTION_PLAYER2 = new Vector3(0, -90, 0);

    public static Dictionary<TilePositionName, Vector3> TILE_POSITIONS = new Dictionary<TilePositionName, Vector3>();

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

    public static Vector3 PIECE_POSITION_A1 = new Vector3(0.21f, -0.35f, -1.33f);
    public static Vector3 PIECE_POSITION_B1 = new Vector3(0.21f, -0.35f, -7.49f);
    public static Vector3 PIECE_POSITION_C1 = new Vector3(0.21f, -0.35f, -13.56f);
    public static Vector3 PIECE_POSITION_D1 = new Vector3(0.21f, -0.35f, -19.57f);
    public static Vector3 PIECE_POSITION_E1 = new Vector3(0.21f, -0.35f, -25.39f);
    public static Vector3 PIECE_POSITION_F1 = new Vector3(0.21f, -0.35f, -31.46f);
    public static Vector3 PIECE_POSITION_G1 = new Vector3(0.21f, -0.35f, -37.48f);
    public static Vector3 PIECE_POSITION_H1 = new Vector3(0.21f, -0.35f, -43.61f);

    public static Vector3 PIECE_POSITION_A2 = new Vector3(6f, 0.35f, -1.33f);
    public static Vector3 PIECE_POSITION_B2 = new Vector3(6f, 0.35f, -7.49f);
    public static Vector3 PIECE_POSITION_C2 = new Vector3(6f, 0.35f, -13.56f);
    public static Vector3 PIECE_POSITION_D2 = new Vector3(6f, 0.35f, -19.57f);
    public static Vector3 PIECE_POSITION_E2 = new Vector3(6f, 0.35f, -25.39f);
    public static Vector3 PIECE_POSITION_F2 = new Vector3(6f, 0.35f, -31.46f);
    public static Vector3 PIECE_POSITION_G2 = new Vector3(6f, 0.35f, -37.48f);
    public static Vector3 PIECE_POSITION_H2 = new Vector3(6f, 0.35f, -43.61f);

    public static Vector3 PIECE_POSITION_A3 = new Vector3(12.48f, 0.35f, -1.33f);
    public static Vector3 PIECE_POSITION_B3 = new Vector3(12.48f, 0.35f, -7.49f);
    public static Vector3 PIECE_POSITION_C3 = new Vector3(12.48f, 0.35f, -13.56f);
    public static Vector3 PIECE_POSITION_D3 = new Vector3(12.48f, 0.35f, -19.57f);
    public static Vector3 PIECE_POSITION_E3 = new Vector3(12.48f, 0.35f, -25.39f);
    public static Vector3 PIECE_POSITION_F3 = new Vector3(12.48f, 0.35f, -31.46f);
    public static Vector3 PIECE_POSITION_G3 = new Vector3(12.48f, 0.35f, -37.48f);
    public static Vector3 PIECE_POSITION_H3 = new Vector3(12.48f, 0.35f, -43.61f);

    public static Vector3 PIECE_POSITION_A4 = new Vector3(18.39f, 0.35f, -1.33f);
    public static Vector3 PIECE_POSITION_B4 = new Vector3(18.39f, 0.35f, -7.49f);
    public static Vector3 PIECE_POSITION_C4 = new Vector3(18.39f, 0.35f, -13.56f);
    public static Vector3 PIECE_POSITION_D4 = new Vector3(18.39f, 0.35f, -19.57f);
    public static Vector3 PIECE_POSITION_E4 = new Vector3(18.39f, 0.35f, -25.39f);
    public static Vector3 PIECE_POSITION_F4 = new Vector3(18.39f, 0.35f, -31.46f);
    public static Vector3 PIECE_POSITION_G4 = new Vector3(18.39f, 0.35f, -37.48f);
    public static Vector3 PIECE_POSITION_H4 = new Vector3(18.39f, 0.35f, -43.61f);

    public static Vector3 PIECE_POSITION_A5 = new Vector3(24.58f, 0.35f, -1.33f);
    public static Vector3 PIECE_POSITION_B5 = new Vector3(24.58f, 0.35f, -7.49f);
    public static Vector3 PIECE_POSITION_C5 = new Vector3(24.58f, 0.35f, -13.56f);
    public static Vector3 PIECE_POSITION_D5 = new Vector3(24.58f, 0.35f, -19.57f);
    public static Vector3 PIECE_POSITION_E5 = new Vector3(24.58f, 0.35f, -25.39f);
    public static Vector3 PIECE_POSITION_F5 = new Vector3(24.58f, 0.35f, -31.46f);
    public static Vector3 PIECE_POSITION_G5 = new Vector3(24.58f, 0.35f, -37.48f);
    public static Vector3 PIECE_POSITION_H5 = new Vector3(24.58f, 0.35f, -43.61f);

    public static Vector3 PIECE_POSITION_A6 = new Vector3(30.41f, 0.35f, -1.33f);
    public static Vector3 PIECE_POSITION_B6 = new Vector3(30.41f, 0.35f, -7.49f);
    public static Vector3 PIECE_POSITION_C6 = new Vector3(30.41f, 0.35f, -13.56f);
    public static Vector3 PIECE_POSITION_D6 = new Vector3(30.41f, 0.35f, -19.57f);
    public static Vector3 PIECE_POSITION_E6 = new Vector3(30.41f, 0.35f, -25.39f);
    public static Vector3 PIECE_POSITION_F6 = new Vector3(30.41f, 0.35f, -31.46f);
    public static Vector3 PIECE_POSITION_G6 = new Vector3(30.41f, 0.35f, -37.48f);
    public static Vector3 PIECE_POSITION_H6 = new Vector3(30.41f, 0.35f, -43.61f);

    public static Vector3 PIECE_POSITION_A7 = new Vector3(36.49f, 0.35f, -1.33f);
    public static Vector3 PIECE_POSITION_B7 = new Vector3(36.49f, 0.35f, -7.49f);
    public static Vector3 PIECE_POSITION_C7 = new Vector3(36.49f, 0.35f, -13.56f);
    public static Vector3 PIECE_POSITION_D7 = new Vector3(36.49f, 0.35f, -19.57f);
    public static Vector3 PIECE_POSITION_E7 = new Vector3(36.49f, 0.35f, -25.39f);
    public static Vector3 PIECE_POSITION_F7 = new Vector3(36.49f, 0.35f, -31.46f);
    public static Vector3 PIECE_POSITION_G7 = new Vector3(36.49f, 0.35f, -37.48f);
    public static Vector3 PIECE_POSITION_H7 = new Vector3(36.49f, 0.35f, -43.61f);

    public static Vector3 PIECE_POSITION_A8 = new Vector3(42.35f, 0.35f, -1.33f);
    public static Vector3 PIECE_POSITION_B8 = new Vector3(42.35f, 0.35f, -7.49f);
    public static Vector3 PIECE_POSITION_C8 = new Vector3(42.35f, 0.35f, -13.56f);
    public static Vector3 PIECE_POSITION_D8 = new Vector3(42.35f, 0.35f, -19.57f);
    public static Vector3 PIECE_POSITION_E8 = new Vector3(42.35f, 0.35f, -25.39f);
    public static Vector3 PIECE_POSITION_F8 = new Vector3(42.35f, 0.35f, -31.46f);
    public static Vector3 PIECE_POSITION_G8 = new Vector3(42.35f, 0.35f, -37.48f);
    public static Vector3 PIECE_POSITION_H8 = new Vector3(42.35f, 0.35f, -43.61f);

    public static void Init()
    {
        #region Tile Positions Dictionary

        TILE_POSITIONS.Add(TilePositionName.A1, PIECE_POSITION_A1);
        TILE_POSITIONS.Add(TilePositionName.B1, PIECE_POSITION_B1);
        TILE_POSITIONS.Add(TilePositionName.C1, PIECE_POSITION_C1);
        TILE_POSITIONS.Add(TilePositionName.D1, PIECE_POSITION_D1);
        TILE_POSITIONS.Add(TilePositionName.E1, PIECE_POSITION_E1);
        TILE_POSITIONS.Add(TilePositionName.F1, PIECE_POSITION_F1);
        TILE_POSITIONS.Add(TilePositionName.G1, PIECE_POSITION_G1);
        TILE_POSITIONS.Add(TilePositionName.H1, PIECE_POSITION_H1);

        TILE_POSITIONS.Add(TilePositionName.A2, PIECE_POSITION_A2);
        TILE_POSITIONS.Add(TilePositionName.B2, PIECE_POSITION_B2);
        TILE_POSITIONS.Add(TilePositionName.C2, PIECE_POSITION_C2);
        TILE_POSITIONS.Add(TilePositionName.D2, PIECE_POSITION_D2);
        TILE_POSITIONS.Add(TilePositionName.E2, PIECE_POSITION_E2);
        TILE_POSITIONS.Add(TilePositionName.F2, PIECE_POSITION_F2);
        TILE_POSITIONS.Add(TilePositionName.G2, PIECE_POSITION_G2);
        TILE_POSITIONS.Add(TilePositionName.H2, PIECE_POSITION_H2);

        TILE_POSITIONS.Add(TilePositionName.A3, PIECE_POSITION_A3);
        TILE_POSITIONS.Add(TilePositionName.B3, PIECE_POSITION_B3);
        TILE_POSITIONS.Add(TilePositionName.C3, PIECE_POSITION_C3);
        TILE_POSITIONS.Add(TilePositionName.D3, PIECE_POSITION_D3);
        TILE_POSITIONS.Add(TilePositionName.E3, PIECE_POSITION_E3);
        TILE_POSITIONS.Add(TilePositionName.F3, PIECE_POSITION_F3);
        TILE_POSITIONS.Add(TilePositionName.G3, PIECE_POSITION_G3);
        TILE_POSITIONS.Add(TilePositionName.H3, PIECE_POSITION_H3);

        TILE_POSITIONS.Add(TilePositionName.A4, PIECE_POSITION_A4);
        TILE_POSITIONS.Add(TilePositionName.B4, PIECE_POSITION_B4);
        TILE_POSITIONS.Add(TilePositionName.C4, PIECE_POSITION_C4);
        TILE_POSITIONS.Add(TilePositionName.D4, PIECE_POSITION_D4);
        TILE_POSITIONS.Add(TilePositionName.E4, PIECE_POSITION_E4);
        TILE_POSITIONS.Add(TilePositionName.F4, PIECE_POSITION_F4);
        TILE_POSITIONS.Add(TilePositionName.G4, PIECE_POSITION_G4);
        TILE_POSITIONS.Add(TilePositionName.H4, PIECE_POSITION_H4);

        TILE_POSITIONS.Add(TilePositionName.A5, PIECE_POSITION_A5);
        TILE_POSITIONS.Add(TilePositionName.B5, PIECE_POSITION_B5);
        TILE_POSITIONS.Add(TilePositionName.C5, PIECE_POSITION_C5);
        TILE_POSITIONS.Add(TilePositionName.D5, PIECE_POSITION_D5);
        TILE_POSITIONS.Add(TilePositionName.E5, PIECE_POSITION_E5);
        TILE_POSITIONS.Add(TilePositionName.F5, PIECE_POSITION_F5);
        TILE_POSITIONS.Add(TilePositionName.G5, PIECE_POSITION_G5);
        TILE_POSITIONS.Add(TilePositionName.H5, PIECE_POSITION_H5);

        TILE_POSITIONS.Add(TilePositionName.A6, PIECE_POSITION_A6);
        TILE_POSITIONS.Add(TilePositionName.B6, PIECE_POSITION_B6);
        TILE_POSITIONS.Add(TilePositionName.C6, PIECE_POSITION_C6);
        TILE_POSITIONS.Add(TilePositionName.D6, PIECE_POSITION_D6);
        TILE_POSITIONS.Add(TilePositionName.E6, PIECE_POSITION_E6);
        TILE_POSITIONS.Add(TilePositionName.F6, PIECE_POSITION_F6);
        TILE_POSITIONS.Add(TilePositionName.G6, PIECE_POSITION_G6);
        TILE_POSITIONS.Add(TilePositionName.H6, PIECE_POSITION_H6);

        TILE_POSITIONS.Add(TilePositionName.A7, PIECE_POSITION_A7);
        TILE_POSITIONS.Add(TilePositionName.B7, PIECE_POSITION_B7);
        TILE_POSITIONS.Add(TilePositionName.C7, PIECE_POSITION_C7);
        TILE_POSITIONS.Add(TilePositionName.D7, PIECE_POSITION_D7);
        TILE_POSITIONS.Add(TilePositionName.E7, PIECE_POSITION_E7);
        TILE_POSITIONS.Add(TilePositionName.F7, PIECE_POSITION_F7);
        TILE_POSITIONS.Add(TilePositionName.G7, PIECE_POSITION_G7);
        TILE_POSITIONS.Add(TilePositionName.H7, PIECE_POSITION_H7);

        TILE_POSITIONS.Add(TilePositionName.A8, PIECE_POSITION_A8);
        TILE_POSITIONS.Add(TilePositionName.B8, PIECE_POSITION_B8);
        TILE_POSITIONS.Add(TilePositionName.C8, PIECE_POSITION_C8);
        TILE_POSITIONS.Add(TilePositionName.D8, PIECE_POSITION_D8);
        TILE_POSITIONS.Add(TilePositionName.E8, PIECE_POSITION_E8);
        TILE_POSITIONS.Add(TilePositionName.F8, PIECE_POSITION_F8);
        TILE_POSITIONS.Add(TilePositionName.G8, PIECE_POSITION_G8);
        TILE_POSITIONS.Add(TilePositionName.H8, PIECE_POSITION_H8);

        #endregion

        #region Player Piece Positions

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

        #endregion
    }

    public static Vector3 GetTilePosition(TilePositionName name)
    {
        Vector3 result = Vector3.zero;
        TILE_POSITIONS.TryGetValue(name, out result);

        return result;
    }
}
