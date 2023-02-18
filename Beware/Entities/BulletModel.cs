using Beware.EntityFeatures;
using Microsoft.Xna.Framework;

namespace Beware.Entities {
    class BulletModel : AmmoModel {
        //public BulletModel(Vector2 position, Vector2 velocity, Sprite sprite, int startingImpactDamage = 2) 
        //    : base(new Engine(position, velocity), sprite, 1, startingImpactDamage) { }

        public BulletModel(Engine engine, Sprite sprite, int startingHealth = 1, int startingImpactDamage = 2)
            : base(engine, sprite, startingHealth, startingImpactDamage) { }
    }
}
