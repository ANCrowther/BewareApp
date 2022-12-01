using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.Entities {
    public class BulletModel : EntityModel {
        public BulletModel(Vector2 position, Vector2 velocity) {
            image = EntityArt.Bullet;
            Velocity = velocity;
            Position = position;
            Orientation = Velocity.ToAngle();
            CollisionRadius = 8;
        }
    }
}
