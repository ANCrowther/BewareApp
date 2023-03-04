using Beware.Enums;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.EntityFeatures {
    public class Sprite {
        public EntityArtType ImageType { get; private set; }
        public float Scale { get; set; }
        public Vector2 Size { get; private set; }
        public float Radius { get { return (float)((Size.X > Size.Y ? Size.X : Size.Y) * Scale); } }

        public Color color = Color.White;

        public Sprite(EntityArtType image, float scale = 1.0f) {
            this.ImageType = image;
            this.Scale = scale;
            Rectangle temp = EntityArt.GetImageSize(ImageType);
            Size = new Vector2(temp.Width, temp.Height);
        }

        public void Draw(Engine engine) {
            BewareGame.Instance._spriteBatch.Draw(EntityArt.GetImage(ImageType), engine.Position, null, Color.White, engine.Orientation, Size / 2f, Scale, 0, 0);
        }

        public void Draw(Vector2 position, float scale, float orientaion) {
            BewareGame.Instance._spriteBatch.Draw(EntityArt.GetImage(ImageType), position, null, color, orientaion, Size / 2f, scale, 0, 0);
        }

        public void DrawGun(Engine engine, float orientation) {
            BewareGame.Instance._spriteBatch.Draw(EntityArt.GetImage(ImageType), engine.Position, null, color, orientation, new Vector2(Size.X / 4, Size.Y / 2), Scale, 0, 0);
        }
    }
}
