using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Beware.Inputs {
    public static class Input {
        public static void Update() {
            PlayerInputStates.LastKeyboardState = PlayerInputStates.KeyboardState;
            PlayerInputStates.LastGamePadState = PlayerInputStates.GamePadState;
            PlayerInputStates.KeyboardState = Keyboard.GetState();
            PlayerInputStates.GamePadState = GamePad.GetState(PlayerIndex.One);
        }

        public static bool WasKeyPressed(Keys key) {
            return PlayerInputStates.LastKeyboardState.IsKeyUp(key) &&
                   PlayerInputStates.KeyboardState.IsKeyDown(key);
        }

        public static bool WasButtonPressed(Buttons button) {
            return PlayerInputStates.LastGamePadState.IsButtonUp(button) &&
                   PlayerInputStates.GamePadState.IsButtonDown(button);
        }

        public static bool IsKeyHeldDown(Keys key) {
            return PlayerInputStates.KeyboardState.IsKeyDown(key);
        }

        public static bool IsButtonHeldDown(Buttons button) {
            return PlayerInputStates.GamePadState.IsButtonDown(button);
        }
    }
}
