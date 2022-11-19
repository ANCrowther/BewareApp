using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.Utilities {
    static class Scenes {
        public static Texture2D Stars_1 { get; private set; }
        public static Texture2D Stars_2 { get; private set; }
        public static Texture2D Stars_3 { get; private set; }
        public static Texture2D Stars_4 { get; private set; }
        public static Texture2D Parchment { get; private set; }
        public static Texture2D GreenSky { get; private set; }
        public static Texture2D BlinkingStar { get; private set; }
        public static Texture2D LeftController { get; private set; }
        public static Texture2D RightController { get; private set; }

        public static void Initialize(ContentManager content) {
            Stars_1 = content.Load<Texture2D>(@"Scenes\Background-1");
            Stars_2 = content.Load<Texture2D>(@"Scenes\Background-2");
            Stars_3 = content.Load<Texture2D>(@"Scenes\Background-3");
            Stars_4 = content.Load<Texture2D>(@"Scenes\Background-4");
            Parchment = content.Load<Texture2D>(@"Scenes\background_parchment");
            GreenSky = content.Load<Texture2D>(@"Scenes\background_zpos");
            BlinkingStar = content.Load<Texture2D>(@"Scenes\background_star");
            LeftController = content.Load<Texture2D>(@"Scenes\background_leftController");
            RightController = content.Load<Texture2D>(@"Scenes\background_rightController");
        }
    }
}
