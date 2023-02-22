using Beware.Entities;
using Microsoft.Xna.Framework;

namespace Beware.EntityFeatures {
    public abstract class Gun : EntityFeature {
        public Vector2 Aim { get; set; }
        public bool IsShooting { get; set; } = false;
        public float Orientation { get; set; }

        public Gun(EntityModel entity, Sprite sprite = null) : base(entity, sprite) { }

        public override void Draw() {
           BewareGame.Instance._spriteBatch.Draw(Sprite.Image, Entity.Engine.Position, null, Sprite.color, Orientation, new Vector2(Sprite.Size.X / 4, Sprite.Size.Y / 2), Sprite.Scale, 0, 0);
        }
    }
}
