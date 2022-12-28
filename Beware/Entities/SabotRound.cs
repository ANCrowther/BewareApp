using Beware.ExtensionSupport;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.Entities {
    class SabotRound : BulletModel {
        public SabotRound(Vector2 position, Vector2 velocity, int startingImpactDamage = 10) : base(position, velocity, startingImpactDamage) {
            image = EntityArt.Sabot;
            Velocity = velocity * 2f;
            Position = position;
            Orientation = Velocity.ToAngle();
            CollisionRadius = 12;
            color = Color.White;
        }

        public override void Draw() {
            BewareGame.Instance._spriteBatch.Draw(image, Position, null, color, Orientation, Size / 2f, 2f, 0, 0);
        }
    }
}
