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

        
    }
}
