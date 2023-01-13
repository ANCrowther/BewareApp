using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.EntityFeatures {
    public class Sprite {
        public Texture2D Image { get; private set; }
        public float Scale { get; set; }
        public Vector2 Size { get { return Image == null ? Vector2.Zero : new Vector2(Image.Width, Image.Height); } }
        public float Radius { get { return (float)(Image.Width > Image.Height ? Image.Height * Scale : Image.Width * Scale); } }

        public Color color = Color.White;
        private readonly Engine entity;

        public Sprite(Texture2D image, float scale = 1.0f, Engine engine = null) {
            this.Image = image;
            this.entity = engine;
            this.Scale = scale;
        }

        public void Draw() {
            BewareGame.Instance._spriteBatch.Draw(Image, entity.Position, null, Color.White, entity.Orientation, Size / 2f, Scale, 0, 0);
        }

        public void Draw(Engine engine) {
            BewareGame.Instance._spriteBatch.Draw(Image, engine.Position, null, Color.White, engine.Orientation, Size / 2f, Scale, 0, 0);
        }

        public void Draw(Vector2 position, float scale, float orientaion) {
            BewareGame.Instance._spriteBatch.Draw(Image, position, null, color, orientaion, Size / 2f, scale, 0, 0);
        }
    }
}
