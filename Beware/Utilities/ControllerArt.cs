using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

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
            Button_Back = content.Load<Texture2D>(@"Controllers\Button_LT");
            Button_Start = content.Load<Texture2D>(@"Controllers\Button_RT");
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
    }
}
