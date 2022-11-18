using Beware.Inputs;
using Beware.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.Entities {
    public abstract class EntityModel {
        public Vector2 Position;
        public Vector2 Velocity;
        public float Orientation;
        public float CollisionRadius = 20.0f;
        public bool IsExpired;
        protected Texture2D image;

        public Vector2 Size { get { return image == null ? Vector2.Zero : new Vector2(image.Width, image.Height); } }

        public abstract void Update();

        public virtual void Draw(SpriteBatch spriteBatch) {
            if (false) {
                spriteBatch.Draw(image, Position, null, Color.White, Orientation, Size / 2f, ViewportManager.ScaleToOne, 0, 0);
            }
        }
    }
}
