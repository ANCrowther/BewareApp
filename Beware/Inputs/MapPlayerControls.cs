using Microsoft.Xna.Framework.Input;

namespace Beware.Inputs {
    static class MapPlayerControls {
        public static bool MapNewControl<T>(string name, T control) {

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
