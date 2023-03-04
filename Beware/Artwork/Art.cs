using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.Utilities {
    static class Art {
        public static Texture2D BlueSquare { get; private set; }
        public static Texture2D RedSquare { get; private set; }

        public static Texture2D Mute { get; private set; }
        public static Texture2D NintendoLayout { get; private set; }
        public static Texture2D LeftPanelLayout { get; private set; }
        public static Texture2D RightPanelLayout { get; private set; }
        public static Texture2D NoPanelLayout { get; private set; }

        // Used by TimeKeeper and ScoreKeeper
        public static Texture2D One { get; private set; }
        public static Texture2D Two { get; private set; }
        public static Texture2D Three { get; private set; }
        public static Texture2D Four { get; private set; }
        public static Texture2D Five { get; private set; }
        public static Texture2D Six { get; private set; }
        public static Texture2D Seven { get; private set; }
        public static Texture2D Eight { get; private set; }
        public static Texture2D Nine { get; private set; }
        public static Texture2D Zero { get; private set; }
        public static Texture2D Colon { get; private set; }
        //public static Texture2D Comma { get; private set; }

        public static void Initialize(ContentManager content) {
            BlueSquare = content.Load<Texture2D>(@"Sprites\blue_square");
            RedSquare = content.Load<Texture2D>(@"Sprites\red_square");

            Mute = content.Load<Texture2D>(@"Sprites\mute");

            NintendoLayout = content.Load<Texture2D>(@"Sprites\layout_nintendo");
            LeftPanelLayout = content.Load<Texture2D>(@"Sprites\layout_left_panel");
            RightPanelLayout = content.Load<Texture2D>(@"Sprites\layout_right_panel");
            NoPanelLayout = content.Load<Texture2D>(@"Sprites\layout_no_panel");

            One = content.Load<Texture2D>(@"Numbers\one");
            Two = content.Load<Texture2D>(@"Numbers\two");
            Three = content.Load<Texture2D>(@"Numbers\three");
            Four = content.Load<Texture2D>(@"Numbers\four");
            Five = content.Load<Texture2D>(@"Numbers\five");
            Six = content.Load<Texture2D>(@"Numbers\six");
            Seven = content.Load<Texture2D>(@"Numbers\seven");
            Eight = content.Load<Texture2D>(@"Numbers\eight");
            Nine = content.Load<Texture2D>(@"Numbers\nine");
            Zero = content.Load<Texture2D>(@"Numbers\zero");
            Colon = content.Load<Texture2D>(@"Numbers\glow_colon");
            //Comma = content.Load<Texture2D>(@"Numbers\glow_comma");
        }
    }
}
