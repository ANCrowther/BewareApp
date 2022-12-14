using Microsoft.Xna.Framework.Input;

namespace Beware.Inputs {
    internal static class PlayerInputStates {
        public static KeyboardState keyboardState { get; set; }
        public static KeyboardState lastKeyboardState { get; set; }
        public static GamePadState gamePadState { get; set; }
        public static GamePadState lastGamePadState { get; set; }
        public static bool IsPaused { get; set; } = false;
    }
}
