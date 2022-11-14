using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Beware.Inputs {
    public static class Input {
        public static void Update() {
            PlayerInputStates.lastKeyboardState = PlayerInputStates.keyboardState;
            PlayerInputStates.lastGamePadState = PlayerInputStates.gamePadState;
            PlayerInputStates.keyboardState = Keyboard.GetState();
            PlayerInputStates.gamePadState = GamePad.GetState(PlayerIndex.One);
        }

        public static bool WasKeyPressed(Keys key) {
            return PlayerInputStates.lastKeyboardState.IsKeyUp(key) &&
                   PlayerInputStates.keyboardState.IsKeyDown(key);
        }

        public static bool WasButtonPressed(Buttons button) {
            return PlayerInputStates.lastGamePadState.IsButtonUp(button) &&
                   PlayerInputStates.gamePadState.IsButtonDown(button);
        }
    }
}
