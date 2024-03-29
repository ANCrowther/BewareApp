﻿using Beware.Inputs;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Beware.ExtensionSupport {
    static class MenuRemoteExtensions {
        public static (T, U) MoveThroughMenu<T, U>(this List<(T, U)> list, (T, U) active) {
            if (Input.WasButtonPressed(Buttons.DPadUp) || Input.WasButtonPressed(Buttons.LeftThumbstickUp)) {
                return SelectUp(list, active);
            }
            if (Input.WasButtonPressed(Buttons.DPadDown) || Input.WasButtonPressed(Buttons.LeftThumbstickDown)) {
                return SelectDown(list, active);
            }
            return active;
        }

        private static (T, U) SelectUp<T, U>(List<(T, U)> list, (T, U) active) {
            int index = list.IndexOf(active);
            if (index > 0) {
                return list[index - 1];
            } else {
                return list[list.Count - 1];
            }
        }

        private static (T, U) SelectDown<T, U>(List<(T, U)> list, (T, U) active) {
            int index = list.IndexOf(active);
            if (index < list.Count - 1) {
                return list[index + 1];
            } else {
                return list[0];
            }
        }
    }
}
