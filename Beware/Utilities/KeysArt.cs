﻿using Microsoft.Xna.Framework.Content;
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
        public static Texture2D Key_Enter { get; private set; }

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
            Key_Enter = content.Load<Texture2D>(@"Digits\Key_Enter");
        }

        public static Texture2D GetKeyPicture(Keys key) {
            switch (key) {
                case Keys.A: return Key_A;
                case Keys.B: return Key_B;
                case Keys.C: return Key_C;
                case Keys.D: return Key_D;
                case Keys.E: return Key_E;
                case Keys.F: return Key_F;
                case Keys.G: return Key_G;
                case Keys.H: return Key_H;
                case Keys.I: return Key_I;
                case Keys.J: return Key_J;
                case Keys.K: return Key_K;
                case Keys.L: return Key_L;
                case Keys.M: return Key_M;
                case Keys.N: return Key_N;
                case Keys.O: return Key_O;
                case Keys.P: return Key_P;
                case Keys.Q: return Key_Q;
                case Keys.R: return Key_R;
                case Keys.S: return Key_S;
                case Keys.T: return Key_T;
                case Keys.U: return Key_U;
                case Keys.V: return Key_V;
                case Keys.W: return Key_W;
                case Keys.X: return Key_X;
                case Keys.Y: return Key_Y;
                case Keys.Z: return Key_Z;
                case Keys.Escape: return Key_Esc;
                case Keys.OemOpenBrackets: return Key_OpenBracket;
                case Keys.OemCloseBrackets: return Key_ClosedBracket;
                case Keys.OemComma: return Key_Comma;
                case Keys.OemQuotes: return Key_Hyphen;
                case Keys.OemSemicolon: return Key_SemiColon;
                case Keys.OemBackslash:
                case Keys.OemPipe: return Key_Backslash;
                case Keys.OemPeriod: return Key_Period;
                case Keys.Space: return Key_Space;
                case Keys.Up: return Key_Up;
                case Keys.Down: return Key_Down;
                case Keys.Left: return Key_Left;
                case Keys.Right: return Key_Right;
                case Keys.OemPlus: return Key_Equal;
                case Keys.OemMinus: return Key_Dash;
                case Keys.Enter: return Key_Enter;
                default: return Key_Tilde;
            }
        }
    }
}