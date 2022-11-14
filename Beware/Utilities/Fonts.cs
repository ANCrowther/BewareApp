using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.Utilities {
    static class Fonts {
        public static SpriteFont NovaSquareLarge { get; private set; }
        public static SpriteFont NovaSquareMedium { get; private set; }
        public static SpriteFont NovaSquareSmall { get; private set; }

        public static void Initialize(ContentManager content) {
            NovaSquareLarge = content.Load<SpriteFont>(@"Fonts\NovaSquare_Large");
            NovaSquareMedium = content.Load<SpriteFont>(@"Fonts\NovaSquare_Regular");
            NovaSquareSmall = content.Load<SpriteFont>(@"Fonts\NovaSquare_Small");
        }
    }
}
