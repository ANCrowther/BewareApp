using Beware.EntityFeatures;
using Beware.ExtensionSupport;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.Entities {
    class SabotRound : BulletModel {
        public SabotRound(Vector2 position, Vector2 velocity, int startingImpactDamage = 10) 
            : base(position, velocity * 2.5f, new Sprite(EntityArt.Sabot, 2.0f), startingImpactDamage) {
            Engine.Orientation = Engine.Velocity.ToAngle();
        }

        public override void Draw() {
            BewareGame.Instance._spriteBatch.Draw(Sprite.Image, Engine.Position, null, Sprite.color, Engine.Orientation, Sprite.Size / 2f, Sprite.Scale, 0, 0);
        }
    }
}
