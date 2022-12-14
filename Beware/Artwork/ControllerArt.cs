using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Beware.Utilities {
    static class ControllerArt {
        public static Texture2D Button_A { get; private set; }
        public static Texture2D Button_B { get; private set; }
        public static Texture2D Button_X { get; private set; }
        public static Texture2D Button_Y { get; private set; }
        public static Texture2D Button_LT { get; private set; }
        public static Texture2D Button_LB { get; private set; }
        public static Texture2D Button_RT { get; private set; }
        public static Texture2D Button_RB { get; private set; }
        public static Texture2D Button_Back { get; private set; }
        public static Texture2D Button_Start { get; private set; }
        public static Texture2D Button_DPad { get; private set; }
        public static Texture2D Button_DPadUp { get; private set; }
        public static Texture2D Button_DPadDown { get; private set; }
        public static Texture2D Button_DPadLeft { get; private set; }
        public static Texture2D Button_DPadRight { get; private set; }
        public static Texture2D Button_LeftStick { get; private set; }
        public static Texture2D Button_RightStick { get; private set; }
        public static Texture2D Button_Generic { get; private set; }
        public static Texture2D Button_GenericStick { get; private set; }
        public static Texture2D Button_ThumbStationary { get; private set; }
        public static Texture2D Button_ThumbMoving { get; private set; }
        public static Texture2D Arrow { get; private set; }
        public static Texture2D A { get; private set; }
        public static Texture2D B { get; private set; }
        public static Texture2D X { get; private set; }
        public static Texture2D Y { get; private set; }

        public static void Initialize(ContentManager content) {
            Button_A = content.Load<Texture2D>(@"Controllers\Button_A");
            Button_B = content.Load<Texture2D>(@"Controllers\Button_B");
            Button_X = content.Load<Texture2D>(@"Controllers\Button_X");
            Button_Y = content.Load<Texture2D>(@"Controllers\Button_Y");
            Button_LeftStick = content.Load<Texture2D>(@"Controllers\Button_LStick");
            Button_RightStick = content.Load<Texture2D>(@"Controllers\Button_RStick");
            Button_LB = content.Load<Texture2D>(@"Controllers\Button_LB");
            Button_RB = content.Load<Texture2D>(@"Controllers\Button_RB");
            Button_LT = content.Load<Texture2D>(@"Controllers\Button_LT");
            Button_RT = content.Load<Texture2D>(@"Controllers\Button_RT");
            Button_DPad = content.Load<Texture2D>(@"Controllers\Button_DPad");
            Button_DPadUp = content.Load<Texture2D>(@"Controllers\Button_DPadUp");
            Button_DPadDown = content.Load<Texture2D>(@"Controllers\Button_DPadDown");
            Button_DPadLeft = content.Load<Texture2D>(@"Controllers\Button_DPadLeft");
            Button_DPadRight = content.Load<Texture2D>(@"Controllers\Button_DPadRight");
            Button_Back = content.Load<Texture2D>(@"Controllers\Button_Back");
            Button_Start = content.Load<Texture2D>(@"Controllers\Button_Start");
            Button_Generic = content.Load<Texture2D>(@"Controllers\controller_button");
            Button_GenericStick = content.Load<Texture2D>(@"Controllers\controller_thumb");
            Button_ThumbStationary = content.Load<Texture2D>(@"Controllers\controller_thumbStationary");
            Button_ThumbMoving = content.Load<Texture2D>(@"Controllers\controller_thumbMoving");
            Arrow = content.Load<Texture2D>(@"Controllers\arrow");
            A = content.Load<Texture2D>(@"Controllers\letter_A");
            B = content.Load<Texture2D>(@"Controllers\letter_B");
            X = content.Load<Texture2D>(@"Controllers\letter_X");
            Y = content.Load<Texture2D>(@"Controllers\letter_Y");
        }

        public static Texture2D GetControllerArt(Buttons button) {
            switch (button) {
                case Buttons.A: return Button_A;
                case Buttons.B: return Button_B;
                case Buttons.X: return Button_X;
                case Buttons.Y: return Button_Y;
                case Buttons.LeftStick: return Button_LeftStick;
                case Buttons.RightStick: return Button_RightStick;
                case Buttons.LeftShoulder: return Button_LB;
                case Buttons.RightShoulder: return Button_RB;
                case Buttons.LeftTrigger: return Button_LT;
                case Buttons.RightTrigger: return Button_RT;
                case Buttons.DPadUp: return Button_DPadUp;
                case Buttons.DPadDown: return Button_DPadDown;
                case Buttons.DPadLeft: return Button_DPadLeft;
                case Buttons.DPadRight: return Button_DPadRight;
                case Buttons.Back: return Button_Back;
                case Buttons.Start: return Button_Start;
                default: return Button_DPad;
            }
        }
    }
}
