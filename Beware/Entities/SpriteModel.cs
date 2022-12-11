using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.Entities {
    class SpriteModel {
        public Texture2D Image { get; private set; }
        public Vector2 Size { get; private set; }

        public SpriteModel(Texture2D image) {
            Image = image;
            Size = (image == null)? Vector2.Zero : new Vector2(Image.Width, Image.Height);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float rotation = 0, float scale = 1) {
            BewareGame.Instance._spriteBatch.Draw(Image, position, null, color, rotation, Size / 2, scale, SpriteEffects.None, 0);
        }
    }
}
