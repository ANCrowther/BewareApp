using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Beware.Utilities {
    static class KeysArt {
        public static Texture2D Key_A { get; private set; }
        public static Texture2D Key_B { get; private set; }
        public static Texture2D Key_C { get; private set; }
        public static Texture2D Key_D { get; private set; }
        public static Texture2D Key_E { get; private set; }
        public static Texture2D Key_F { get; private set; }
        public static Texture2D Key_G { get; private set; }
        public static Texture2D Key_H { get; private set; }
        public static Texture2D Key_I { get; private set; }
        public static Texture2D Key_J { get; private set; }
        public static Texture2D Key_K { get; private set; }
        public static Texture2D Key_L { get; private set; }
        public static Texture2D Key_M { get; private set; }
        public static Texture2D Key_N { get; private set; }
        public static Texture2D Key_O { get; private set; }
        public static Texture2D Key_P { get; private set; }
        public static Texture2D Key_Q { get; private set; }
        public static Texture2D Key_R { get; private set; }
        public static Texture2D Key_S { get; private set; }
        public static Texture2D Key_T { get; private set; }
        public static Texture2D Key_U { get; private set; }
        public static Texture2D Key_V { get; private set; }
        public static Texture2D Key_W { get; private set; }
        public static Texture2D Key_X { get; private set; }
        public static Texture2D Key_Y { get; private set; }
        public static Texture2D Key_Z { get; private set; }
        public static Texture2D Key_Esc { get; private set; }
        public static Texture2D Key_Tilde { get; private set; }
        public static Texture2D Key_Backslash { get; private set; }
        public static Texture2D Key_Slash { get; private set; }
        public static Texture2D Key_Comma { get; private set; }
        public static Texture2D Key_SemiColon { get; private set; }
        public static Texture2D Key_OpenBracket { get; private set; }
        public static Texture2D Key_ClosedBracket { get; private set; }
        public static Texture2D Key_Period { get; private set; }
        public static Texture2D Key_Hyphen { get; private set; }
        public static Texture2D Key_Dash { get; private set; }
        public static Texture2D Key_Equal { get; private set; }
        public static Texture2D Key_1 { get; private set; }
        public static Texture2D Key_2 { get; private set; }
        public static Texture2D Key_3 { get; private set; }
        public static Texture2D Key_4 { get; private set; }
        public static Texture2D Key_5 { get; private set; }
        public static Texture2D Key_6 { get; private set; }
        public static Texture2D Key_7 { get; private set; }
        public static Texture2D Key_8 { get; private set; }
        public static Texture2D Key_9 { get; private set; }
        public static Texture2D Key_0 { get; private set; }
        public static Texture2D Key_Up { get; private set; }
        public static Texture2D Key_Down { get; private set; }
        public static Texture2D Key_Left { get; private set; }
        public static Texture2D Key_Right { get; private set; }
        public static Texture2D Key_Space { get; private set; }

        public static void Initialize(ContentManager content) {
            Key_A = content.Load<Texture2D>(@"Digits\key_A");
            Key_B = content.Load<Texture2D>(@"Digits\key_B");
            Key_C = content.Load<Texture2D>(@"Digits\key_C");
            Key_D = content.Load<Texture2D>(@"Digits\key_D");
            Key_E = content.Load<Texture2D>(@"Digits\key_E");
            Key_F = content.Load<Texture2D>(@"Digits\key_F");
            Key_G = content.Load<Texture2D>(@"Digits\key_G");
            Key_H = content.Load<Texture2D>(@"Digits\key_H");
            Key_I = content.Load<Texture2D>(@"Digits\key_I");
            Key_J = content.Load<Texture2D>(@"Digits\key_J");
            Key_K = content.Load<Texture2D>(@"Digits\key_K");
            Key_L = content.Load<Texture2D>(@"Digits\key_L");
            Key_M = content.Load<Texture2D>(@"Digits\key_M");
            Key_N = content.Load<Texture2D>(@"Digits\key_N");
            Key_O = content.Load<Texture2D>(@"Digits\key_O");
            Key_P = content.Load<Texture2D>(@"Digits\key_P");
            Key_Q = content.Load<Texture2D>(@"Digits\key_Q");
            Key_R = content.Load<Texture2D>(@"Digits\key_R");
            Key_S = content.Load<Texture2D>(@"Digits\key_S");
            Key_T = content.Load<Texture2D>(@"Digits\key_T");
            Key_U = content.Load<Texture2D>(@"Digits\key_U");
            Key_V = content.Load<Texture2D>(@"Digits\key_V");
            Key_W = content.Load<Texture2D>(@"Digits\key_W");
            Key_X = content.Load<Texture2D>(@"Digits\key_X");
            Key_Y = content.Load<Texture2D>(@"Digits\key_Y");
            Key_Z = content.Load<Texture2D>(@"Digits\key_Z");
            Key_1 = content.Load<Texture2D>(@"Digits\key_1");
            Key_2 = content.Load<Texture2D>(@"Digits\key_2");
            Key_3 = content.Load<Texture2D>(@"Digits\key_3");
            Key_4 = content.Load<Texture2D>(@"Digits\key_4");
            Key_5 = content.Load<Texture2D>(@"Digits\key_5");
            Key_6 = content.Load<Texture2D>(@"Digits\key_6");
            Key_7 = content.Load<Texture2D>(@"Digits\key_7");
            Key_8 = content.Load<Texture2D>(@"Digits\key_8");
            Key_9 = content.Load<Texture2D>(@"Digits\key_9");
            Key_0 = content.Load<Texture2D>(@"Digits\key_0");
            Key_Tilde = content.Load<Texture2D>(@"Digits\key_Tilde");
            Key_Esc = content.Load<Texture2D>(@"Digits\key_Esc");
            Key_Backslash = content.Load<Texture2D>(@"Digits\Key_backslash");
            Key_Slash = content.Load<Texture2D>(@"Digits\Key_slash");
            Key_Comma = content.Load<Texture2D>(@"Digits\Key_comma");
            Key_SemiColon = content.Load<Texture2D>(@"Digits\Key_SemiColon");
            Key_OpenBracket = content.Load<Texture2D>(@"Digits\Key_OpenBracket");
            Key_ClosedBracket = content.Load<Texture2D>(@"Digits\Key_CloseBracket");
            Key_Period = content.Load<Texture2D>(@"Digits\Key_Period");
            Key_Hyphen = content.Load<Texture2D>(@"Digits\Key_Hyphen");
            Key_Dash = content.Load<Texture2D>(@"Digits\Key_dash");
            Key_Equal = content.Load<Texture2D>(@"Digits\Key_equal");
            Key_Space = content.Load<Texture2D>(@"Digits\Key_Space");
            Key_Up = content.Load<Texture2D>(@"Digits\Key_Up");
            Key_Down = content.Load<Texture2D>(@"Digits\Key_Down");
            Key_Left = content.Load<Texture2D>(@"Digits\Key_Left");
            Key_Right = content.Load<Texture2D>(@"Digits\Key_Right");
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
