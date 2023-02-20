using Beware.EntityFeatures;
using Microsoft.Xna.Framework;

namespace Beware.Entities {
    class SabotRound : AmmoModel {
        public SabotRound(Vector2 position, Vector2 velocity, Sprite sprite, int startingHealth = 100, int startingImpactDamage = 30)
            : base(new Engine(position, velocity * 2.5f), sprite, startingHealth, startingImpactDamage) { }
    }
}
