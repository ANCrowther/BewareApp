using Beware.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

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
                default: return Art.Colon; // Simple solution to insert a ':' into the integer time clock
                //default: return Art.Comma; 
            }
        }

        public static Texture2D GetMappingKey(string inputKey) {
            switch (inputKey) {
                case "A": return KeysArt.Key_A;
                case "B": return KeysArt.Key_B;
                case "C": return KeysArt.Key_C;
                case "D": return KeysArt.Key_D;
                case "E": return KeysArt.Key_E;
                case "F": return KeysArt.Key_F;
                case "G": return KeysArt.Key_G;
                case "H": return KeysArt.Key_H;
                case "I": return KeysArt.Key_I;
                case "J": return KeysArt.Key_J;
                case "K": return KeysArt.Key_K;
                case "L": return KeysArt.Key_L;
                case "M": return KeysArt.Key_M;
                case "N": return KeysArt.Key_N;
                case "O": return KeysArt.Key_O;
                case "P": return KeysArt.Key_P;
                case "Q": return KeysArt.Key_Q;
                case "R": return KeysArt.Key_R;
                case "S": return KeysArt.Key_S;
                case "T": return KeysArt.Key_T;
                case "U": return KeysArt.Key_U;
                case "V": return KeysArt.Key_V;
                case "W": return KeysArt.Key_W;
                case "X": return KeysArt.Key_X;
                case "Y": return KeysArt.Key_Y;
                case "Z": return KeysArt.Key_Z;
                case "1": return KeysArt.Key_1;
                case "2": return KeysArt.Key_2;
                case "3": return KeysArt.Key_3;
                case "4": return KeysArt.Key_4;
                case "5": return KeysArt.Key_5;
                case "6": return KeysArt.Key_6;
                case "7": return KeysArt.Key_7;
                case "8": return KeysArt.Key_8;
                case "9": return KeysArt.Key_9;
                case "0": return KeysArt.Key_0;
                case "~": return KeysArt.Key_Tilde;
                case "[": return KeysArt.Key_OpenBracket;
                case "]": return KeysArt.Key_ClosedBracket;
                case "\\": return KeysArt.Key_Backslash;
                case ",": return KeysArt.Key_Comma;
                case ".": return KeysArt.Key_Period;
                case "/": return KeysArt.Key_Slash;
                case ";": return KeysArt.Key_SemiColon;
                case "'": return KeysArt.Key_Hyphen;
                case "-": return KeysArt.Key_Dash;
                case "=": return KeysArt.Key_Equal;
                case " ": return KeysArt.Key_Space;
                case "Left": return KeysArt.Key_Left;
                case "Right": return KeysArt.Key_Right;
                case "Up": return KeysArt.Key_Up;
                case "Down": return KeysArt.Key_Down;
                default:  return KeysArt.Key_Esc;
            }
        }

        public static Texture2D GetMappingButton(string inputButton) {
            switch (inputButton) {
                case "A": return ControllerArt.Button_A;
                case "B": return ControllerArt.Button_B;
                case "C": return ControllerArt.Button_X;
                case "Y": return ControllerArt.Button_Y;
                case "Back": return ControllerArt.Button_Back;
                case "Start": return ControllerArt.Button_Start;
                case "LStick": return ControllerArt.Button_LeftStick;
                case "RStick": return ControllerArt.Button_RightStick;
                case "RB": return ControllerArt.Button_RB;
                case "LB": return ControllerArt.Button_LB;
                case "RT": return ControllerArt.Button_RT;
                case "LT": return ControllerArt.Button_LT;
                default: return ControllerArt.Button_DPad;
            }
        }

        public static Vector2 GetDirection(Mode type) {
            Vector2 direction = (((type == Mode.Move) ? ControlMap.Move_pad : ControlMap.Shoot_pad) == Buttons.LeftStick) ?
                PlayerInputStates.gamePadState.ThumbSticks.Left : PlayerInputStates.gamePadState.ThumbSticks.Right;
            direction.Y *= -1;

            if (PlayerInputStates.keyboardState.IsKeyDown((type == Mode.Move) ? ControlMap.MoveLeft : ControlMap.AimLeft))
                direction.X -= 1;
            if (PlayerInputStates.keyboardState.IsKeyDown((type == Mode.Move) ? ControlMap.MoveRight : ControlMap.AimRight))
                direction.X += 1;
            if (PlayerInputStates.keyboardState.IsKeyDown((type == Mode.Move) ? ControlMap.MoveUp : ControlMap.AimUp))
                direction.Y -= 1;
            if (PlayerInputStates.keyboardState.IsKeyDown((type == Mode.Move) ? ControlMap.MoveDown : ControlMap.AimDown))
                direction.Y += 1;

            if (direction.LengthSquared() > 0) {
                direction.Normalize();
            }

            return direction;
        }

        public static (T, U) MoveThroughMenu<T, U>(List<(T, U)> list, (T, U) active) {
            if (Input.WasKeyPressed(Keys.Up) || Input.WasButtonPressed(Buttons.DPadUp)) {
                return SelectUp(list, active);
            }
            if (Input.WasKeyPressed(Keys.Down) || Input.WasButtonPressed(Buttons.DPadDown)) {
                return SelectDown(list, active);
            }
            return active;
        }

        private static (T, U) SelectUp<T, U>(List<(T, U)> list, (T, U) active) {
            int index = list.IndexOf(active);
            if (index > 0) {
                return active = list[index - 1];
            } else {
                return active = list[list.Count - 1];
            }
        }

        private static (T, U) SelectDown<T, U>(List<(T, U)> list, (T, U) active) {
            int index = list.IndexOf(active);
            if (index < list.Count - 1) {
                return active = list[index + 1];
            } else {
                return active = list[0];
            }
        }
    }
}
