using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Beware.Utilities {
    static class Extensions {
        public static float ToAngle(this Vector2 vector) {
            return (float)Math.Atan2(vector.Y, vector.X);
        }

        public static Keys GetKey(this KeyboardState k) {
            if (k.IsKeyDown(Keys.A))
                return Keys.A;
            if (k.IsKeyDown(Keys.B))
                return Keys.B;
            if (k.IsKeyDown(Keys.C))
                return Keys.C;
            if (k.IsKeyDown(Keys.D))
                return Keys.D;
            if (k.IsKeyDown(Keys.E))
                return Keys.E;
            if (k.IsKeyDown(Keys.F))
                return Keys.F;
            if (k.IsKeyDown(Keys.G))
                return Keys.G;
            if (k.IsKeyDown(Keys.H))
                return Keys.H;
            if (k.IsKeyDown(Keys.I))
                return Keys.I;
            if (k.IsKeyDown(Keys.J))
                return Keys.J;
            if (k.IsKeyDown(Keys.K))
                return Keys.K;
            if (k.IsKeyDown(Keys.L))
                return Keys.L;
            if (k.IsKeyDown(Keys.M))
                return Keys.M;
            if (k.IsKeyDown(Keys.N))
                return Keys.N;
            if (k.IsKeyDown(Keys.O))
                return Keys.O;
            if (k.IsKeyDown(Keys.P))
                return Keys.P;
            if (k.IsKeyDown(Keys.Q))
                return Keys.Q;
            if (k.IsKeyDown(Keys.R))
                return Keys.R;
            if (k.IsKeyDown(Keys.S))
                return Keys.S;
            if (k.IsKeyDown(Keys.T))
                return Keys.T;
            if (k.IsKeyDown(Keys.U))
                return Keys.U;
            if (k.IsKeyDown(Keys.V))
                return Keys.V;
            if (k.IsKeyDown(Keys.W))
                return Keys.W;
            if (k.IsKeyDown(Keys.X))
                return Keys.X;
            if (k.IsKeyDown(Keys.Y))
                return Keys.Y;
            if (k.IsKeyDown(Keys.Z))
                return Keys.Z;
            if (k.IsKeyDown(Keys.Up))
                return Keys.Up;
            if (k.IsKeyDown(Keys.Down))
                return Keys.Down;
            if (k.IsKeyDown(Keys.Left))
                return Keys.Left;
            if (k.IsKeyDown(Keys.Right))
                return Keys.Right;
            if (k.IsKeyDown(Keys.OemOpenBrackets))
                return Keys.OemOpenBrackets;
            if (k.IsKeyDown(Keys.OemCloseBrackets))
                return Keys.OemCloseBrackets;
            if (k.IsKeyDown(Keys.OemPipe))
                return Keys.OemPipe;
            if (k.IsKeyDown(Keys.OemQuestion))
                return Keys.OemQuestion;
            if (k.IsKeyDown(Keys.OemPeriod))
                return Keys.OemPeriod;
            if (k.IsKeyDown(Keys.OemComma))
                return Keys.OemComma;
            if (k.IsKeyDown(Keys.OemSemicolon))
                return Keys.OemSemicolon;
            if (k.IsKeyDown(Keys.OemQuotes))
                return Keys.OemQuotes;
            if (k.IsKeyDown(Keys.Space))
                return Keys.Space;
            if (k.IsKeyDown(Keys.OemMinus))
                return Keys.OemMinus;
            if (k.IsKeyDown(Keys.OemPlus))
                return Keys.OemPlus;
            if (k.IsKeyDown(Keys.MediaPlayPause))
                return Keys.MediaPlayPause;
            if (k.IsKeyDown(Keys.VolumeDown))
                return Keys.VolumeDown;
            if (k.IsKeyDown(Keys.VolumeUp))
                return Keys.VolumeUp;
            if (k.IsKeyDown(Keys.VolumeMute))
                return Keys.VolumeMute;
            return Keys.OemTilde;
        }

        public static Buttons GetButton(this GamePadState g) {
            if (g.IsButtonDown(Buttons.A))
                return Buttons.A;
            if (g.IsButtonDown(Buttons.B))
                return Buttons.B;
            if (g.IsButtonDown(Buttons.X))
                return Buttons.X;
            if (g.IsButtonDown(Buttons.Y))
                return Buttons.Y;
            if (g.IsButtonDown(Buttons.LeftShoulder))
                return Buttons.LeftShoulder;
            if (g.IsButtonDown(Buttons.RightShoulder))
                return Buttons.RightShoulder;
            if (g.IsButtonDown(Buttons.LeftTrigger))
                return Buttons.LeftTrigger;
            if (g.IsButtonDown(Buttons.RightTrigger))
                return Buttons.RightTrigger;
            if (g.IsButtonDown(Buttons.LeftStick))
                return Buttons.LeftStick;
            if (g.IsButtonDown(Buttons.RightStick))
                return Buttons.RightStick;
            if (g.IsButtonDown(Buttons.Start))
                return Buttons.Start;
            if (g.IsButtonDown(Buttons.Back))
                return Buttons.Back;
            if (g.IsButtonDown(Buttons.DPadUp))
                return Buttons.DPadUp;
            if (g.IsButtonDown(Buttons.DPadDown))
                return Buttons.DPadDown;
            if (g.IsButtonDown(Buttons.DPadRight))
                return Buttons.DPadRight;
            if (g.IsButtonDown(Buttons.DPadLeft))
                return Buttons.DPadLeft;
            return Buttons.BigButton;
        }

        public static float SoundToFloat(this int soundLevel) {
            return soundLevel * 0.05f;
        }
    }
}
