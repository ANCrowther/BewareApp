using Beware.EntityFeatures;
using Microsoft.Xna.Framework;

namespace Beware.Entities {
    class PlayerBulletModel : AmmoModel {
        public PlayerBulletModel(Vector2 position, Vector2 velocity, Sprite sprite, int startingHealth = 1, int startingImpactDamage = 2)
            : base(new Engine(position, velocity), sprite, startingHealth, startingImpactDamage) { }
    }
}
