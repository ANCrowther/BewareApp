using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Beware.Inputs {
    static class MapPlayerControls {
        public static bool MapNewControl<T>(List<(string heading, T name)> list, (string heading, T name) activeSetting, T control) {
            foreach ((string heading, T name) in list) {
                //if (item.name is Keys j && control is Keys k && activeSetting.name is Keys l){
                //    if (item.heading != activeSetting.heading && j == k) {
                //        SetNewKey(item.heading, l);
                //        break;
                //    }
                //}
                if (name is Buttons a && control is Buttons b && activeSetting.name is Buttons c) {
                    if (heading != activeSetting.heading && a == b) {
                        SetNewButton(heading, c);
                        break;
                    }
                }
            }

            if (control is Buttons button) {
                return SetNewButton(activeSetting.heading, button);
            }

            return false;
        }

        private static bool SetNewButton(string heading, Buttons control) {
            bool isSet = IsValidButton(control);
            if (isSet) {
                switch (heading) {
                    case "Move":
                        ControlMap.Move = control;
                        break;
                    case "Aim":
                        ControlMap.Aim = control;
                        break;
                    case "Shoot":
                        ControlMap.Shoot = control;
                        break;
                    case "Slow":
                        ControlMap.Slow = control;
                        break;
                    case "Boost":
                        ControlMap.Boost = control;
                        break;
                    case "Switch Special":
                        ControlMap.SwitchSpecial = control;
                        break;
                    case "Special":
                        ControlMap.Special = control;
                        break;
                    case "Accept":
                        ControlMap.Accept = control;
                        break;
                    default:
                        isSet = false;
                        break;
                }
            }

            return isSet;
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
                //case Buttons.DPadUp:
                //case Buttons.DPadDown:
                //case Buttons.DPadLeft:
                //case Buttons.DPadRight:
                case Buttons.RightStick:
                case Buttons.LeftStick:
                    return true;
                default: 
                    return false;
            }
        }
    }
}
