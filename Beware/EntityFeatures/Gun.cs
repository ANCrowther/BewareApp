using Beware.Entities;
using Microsoft.Xna.Framework;

namespace Beware.EntityFeatures {
    public abstract class Gun : EntityFeature {
        public Vector2 Aim { get; set; }
        public bool IsShooting { get; set; } = false;
        public float Orientation { get; set; }

        public Gun(EntityModel entity, Sprite sprite) : base(entity, sprite) { }

        public override void Draw() {
           Sprite.DrawGun(Entity.Engine);
        }
    }
}
