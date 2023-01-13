using Microsoft.Xna.Framework.Input;

namespace Beware.Inputs {
    internal static class PlayerInputStates {
        public static KeyboardState KeyboardState { get; set; }
        public static KeyboardState LastKeyboardState { get; set; }
        public static GamePadState GamePadState { get; set; }
        public static GamePadState LastGamePadState { get; set; }
    }
}
