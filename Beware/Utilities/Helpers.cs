﻿using Beware.Inputs;
using Beware.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Beware.Utilities {
    public static class Helpers {
        public static string[] menuOptions = { "Play Game", "Player Settings", "Game Settings", "Quit" };

        public static Texture2D GetDigit(int digit) {
            switch (digit) {
                case 1:  return Art.One;
                case 2:  return Art.Two;
                case 3:  return Art.Three;
                case 4:  return Art.Four;
                case 5:  return Art.Five;
                case 6:  return Art.Six;
                case 7:  return Art.Seven;
                case 8:  return Art.Eight;
                case 9:  return Art.Nine;
                case 0:  return Art.Zero;
                case 10: return Art.Colon;
                default: return Art.Comma;
            }
        }

        public static Texture2D GetMappingKey(string inputKey) {
            switch (inputKey) {
                case "A": return Mapping.Key_A;
                case "B": return Mapping.Key_B;
                case "C": return Mapping.Key_C;
                case "D": return Mapping.Key_D;
                case "E": return Mapping.Key_E;
                case "F": return Mapping.Key_F;
                case "G": return Mapping.Key_G;
                case "H": return Mapping.Key_H;
                case "I": return Mapping.Key_I;
                case "J": return Mapping.Key_J;
                case "K": return Mapping.Key_K;
                case "L": return Mapping.Key_L;
                case "M": return Mapping.Key_M;
                case "N": return Mapping.Key_N;
                case "O": return Mapping.Key_O;
                case "P": return Mapping.Key_P;
                case "Q": return Mapping.Key_Q;
                case "R": return Mapping.Key_R;
                case "S": return Mapping.Key_S;
                case "T": return Mapping.Key_T;
                case "U": return Mapping.Key_U;
                case "V": return Mapping.Key_V;
                case "W": return Mapping.Key_W;
                case "X": return Mapping.Key_X;
                case "Y": return Mapping.Key_Y;
                case "Z": return Mapping.Key_Z;
                case "1": return Mapping.Key_1;
                case "2": return Mapping.Key_2;
                case "3": return Mapping.Key_3;
                case "4": return Mapping.Key_4;
                case "5": return Mapping.Key_5;
                case "6": return Mapping.Key_6;
                case "7": return Mapping.Key_7;
                case "8": return Mapping.Key_8;
                case "9": return Mapping.Key_9;
                case "0": return Mapping.Key_0;
                case "~": return Mapping.Key_Tilde;
                case "[": return Mapping.Key_OpenBracket;
                case "]": return Mapping.Key_ClosedBracket;
                case "\\": return Mapping.Key_Backslash;
                case ",": return Mapping.Key_Comma;
                case ".": return Mapping.Key_Period;
                case "/": return Mapping.Key_Slash;
                case ";": return Mapping.Key_SemiColon;
                case "'": return Mapping.Key_Hyphen;
                case "-": return Mapping.Key_Dash;
                case "=": return Mapping.Key_Equal;
                case " ": return Mapping.Key_Space;
                case "Left": return Mapping.Key_Left;
                case "Right": return Mapping.Key_Right;
                case "Up": return Mapping.Key_Up;
                case "Down": return Mapping.Key_Down;
                default:  return Mapping.Key_Esc;
            }
        }

        public static Texture2D GetMappingButton(string inputButton) {
            switch (inputButton) {
                case "A": return Mapping.Button_A;
                case "B": return Mapping.Button_B;
                case "C": return Mapping.Button_X;
                case "Y": return Mapping.Button_Y;
                case "Back": return Mapping.Button_Back;
                case "Start": return Mapping.Button_Start;
                case "LStick": return Mapping.Button_LeftStick;
                case "RStick": return Mapping.Button_RightStick;
                case "RB": return Mapping.Button_RB;
                case "LB": return Mapping.Button_LB;
                case "RT": return Mapping.Button_RT;
                case "LT": return Mapping.Button_LT;
                default: return Mapping.Button_DPad;
            }
        }

        public static Vector2 GetDirection(Mode type) {
            Vector2 direction = (((type == Mode.Move) ? ControlMap.Move_pad : ControlMap.Shoot_pad) == Buttons.LeftStick) ?
                PlayerInputStates.gamePadState.ThumbSticks.Left : PlayerInputStates.gamePadState.ThumbSticks.Right;
            direction.Y *= -1;

            if (PlayerInputStates.keyboardState.IsKeyDown((type == Mode.Move) ? ControlMap.MoveLeft : ControlMap.ShootLeft))
                direction.X -= 1;
            if (PlayerInputStates.keyboardState.IsKeyDown((type == Mode.Move) ? ControlMap.MoveRight : ControlMap.ShootRight))
                direction.X += 1;
            if (PlayerInputStates.keyboardState.IsKeyDown((type == Mode.Move) ? ControlMap.MoveUp : ControlMap.ShootUp))
                direction.Y -= 1;
            if (PlayerInputStates.keyboardState.IsKeyDown((type == Mode.Move) ? ControlMap.MoveDown : ControlMap.ShootDown))
                direction.Y += 1;

            if (direction.LengthSquared() > 0) {
                direction.Normalize();
            }

            return direction;
        }

        public static void DrawCardinalMap(Mode type, Vector2 centerPosition) {
            //CardinalMapManager.Instance.Initialize(centerPosition);
            //CardinalMapManager.Instance.Draw(GetPicture(type), GetDirection(type));
        }

        public static Texture2D GetPicture(Mode type) {
            switch (type) {
                case Mode.Move:  return Art.BlueStarBurst;
                case Mode.Shoot: return Art.RedStarBurst;
                default:         return Art.FourPointStar;
            }
        }
    }
}