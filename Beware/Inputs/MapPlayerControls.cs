using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Beware.Inputs {
    static class MapPlayerControls {
        public static bool MapNewControl<T>(this List<(string heading, T name)> list, (string heading, T name) activeSetting, T control) {
            foreach ((string heading, T name) item in list) {
                if (item.heading != activeSetting.heading) {
                    if (activeSetting is Keys k && item.name is Keys i &&  i == k) {
                        SetNewKey(item.heading, k);
                        break;
                    }
                    if (control is Buttons b && item.name is Buttons j && j == b) {
                        SetNewButton(item.heading, b);
                    }
                }
            }
            if (control is Keys key) {
                return SetNewKey(activeSetting.heading, key);
            }
            if (control is Buttons button) {
                return SetNewButton(activeSetting.heading, button);
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
                    case "Aim Up":
                        ControlMap.AimUp = control;
                        break;
                    case "Aim Down":
                        ControlMap.AimDown = control;
                        break;
                    case "Aim Left":
                        ControlMap.AimLeft = control;
                        break;
                    case "Aim Right":
                        ControlMap.AimRight = control;
                        break;
                    case "Shoot":
                        ControlMap.Shoot = control;
                        break;
                    case "Slow":
                        ControlMap.Slow = control;
                        break;
                    case "Special":
                        ControlMap.Special = control;
                        break;
                    default:
                        isSet = false;
                        break;
                }
            }

            return isSet;
        }

        private static bool SetNewButton(string heading, Buttons control) {
            bool isSet = IsValidButton(control);
            if (isSet) {
                switch (heading) {
                    case "Move":
                        ControlMap.Move_pad = control;
                        break;
                    case "Aim":
                        ControlMap.Aim_pad = control;
                        break;
                    case "Shoot":
                        ControlMap.Shoot_pad = control;
                        break;
                    case "Slow":
                        ControlMap.Slow_pad = control;
                        break;
                    case "Special":
                        ControlMap.Special_pad = control;
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

        private static bool IsValidButton(Buttons button) {
            switch (button) {
                case Buttons.A:
                case Buttons.B:
                case Buttons.X:
                case Buttons.Y:
                case Buttons.LeftTrigger:
                case Buttons.RightTrigger:
                case Buttons.LeftShoulder:
                case Buttons.RightShoulder:
                case Buttons.DPadUp:
                case Buttons.DPadDown:
                case Buttons.DPadLeft:
                case Buttons.DPadRight:
                case Buttons.RightStick:
                case Buttons.LeftStick:
                    return true;
                default: 
                    return false;
            }
        }
    }
}
