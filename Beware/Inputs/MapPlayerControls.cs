using Beware.Utilities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Beware.Inputs {
    static class MapPlayerControls {
        public static bool MapNewControl<T>(this List<(string heading, T name)> list, (string heading, T name) active, T control) {
            //foreach ((string heading, T name) item in list) {
            //    if (item.heading != active.heading) {

            //    }
            //}
            if (control is Keys key) {
                return SetNewKey(active.heading, key);
            }

            return false;
        }

        private static bool SetNewKey(string heading, Keys control) {
            bool isSet = IsValidKey(control);
            if (isSet) {
                switch (heading) {
                    case "Move Up":
                        ControlMap.MoveUp = control;
                        break;
                    case "Move Down":
                        ControlMap.MoveDown = control;
                        break;
                    case "Move Left":
                        ControlMap.MoveLeft = control;
                        break;
                    case "Move Right":
                        ControlMap.MoveRight = control;
                        break;

                    default:
                        isSet = false;
                        break;
                }
            }

            return isSet;
        }

        private static bool IsValidKey(Keys key) {
            switch (key) {
                case Keys.A:
                case Keys.B:
                case Keys.C:
                case Keys.D:
                case Keys.E:
                case Keys.F:
                case Keys.G:
                case Keys.H:
                case Keys.I:
                case Keys.J:
                case Keys.K:
                case Keys.L:
                case Keys.M:
                case Keys.N:
                case Keys.O:
                //case Keys.P:
                case Keys.Q:
                case Keys.R:
                case Keys.S:
                case Keys.T:
                case Keys.U:
                case Keys.V:
                case Keys.W:
                case Keys.X:
                case Keys.Y:
                case Keys.Z:
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                case Keys.Space:
                case Keys.OemOpenBrackets:
                case Keys.OemCloseBrackets:
                case Keys.OemSemicolon:
                case Keys.OemComma:
                case Keys.OemPeriod:
                case Keys.OemQuestion:
                case Keys.OemQuotes:
                    return true;
                default:
                    return false;
            }
        }

        public static Texture2D GetKeyPicture(Keys key) {
            switch (key) {
                case Keys.A: return KeysArt.Key_A;
                case Keys.B: return KeysArt.Key_B;
                case Keys.C: return KeysArt.Key_C;
                case Keys.D: return KeysArt.Key_D;
                case Keys.E: return KeysArt.Key_E;
                case Keys.F: return KeysArt.Key_F;
                case Keys.G: return KeysArt.Key_G;
                case Keys.H: return KeysArt.Key_H;
                case Keys.I: return KeysArt.Key_I;
                case Keys.J: return KeysArt.Key_J;
                case Keys.K: return KeysArt.Key_K;
                case Keys.L: return KeysArt.Key_L;
                case Keys.M: return KeysArt.Key_M;
                case Keys.N: return KeysArt.Key_N;
                case Keys.O: return KeysArt.Key_O;
                case Keys.P: return KeysArt.Key_P;
                case Keys.Q: return KeysArt.Key_Q;
                case Keys.R: return KeysArt.Key_R;
                case Keys.S: return KeysArt.Key_S;
                case Keys.T: return KeysArt.Key_T;
                case Keys.U: return KeysArt.Key_U;
                case Keys.V: return KeysArt.Key_V;
                case Keys.W: return KeysArt.Key_W;
                case Keys.X: return KeysArt.Key_X;
                case Keys.Y: return KeysArt.Key_Y;
                case Keys.Z: return KeysArt.Key_Z;
                case Keys.Escape: return KeysArt.Key_Esc;
                case Keys.OemOpenBrackets: return KeysArt.Key_OpenBracket;
                case Keys.OemCloseBrackets: return KeysArt.Key_ClosedBracket;
                case Keys.OemComma: return KeysArt.Key_Comma;
                case Keys.OemQuotes: return KeysArt.Key_Hyphen;
                case Keys.OemSemicolon: return KeysArt.Key_SemiColon;
                case Keys.OemPipe: return KeysArt.Key_Backslash;
                case Keys.OemPeriod: return KeysArt.Key_Period;
                case Keys.Space: return KeysArt.Key_Space;
                case Keys.Up: return KeysArt.Key_Up;
                case Keys.Down: return KeysArt.Key_Down;
                case Keys.Left: return KeysArt.Key_Left;
                case Keys.Right: return KeysArt.Key_Right;
                default: return KeysArt.Key_Tilde;
            }
        }
    }
}
