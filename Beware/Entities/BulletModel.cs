using Beware.EntityFeatures;
using Microsoft.Xna.Framework;

namespace Beware.Entities {
    public class BulletModel : EntityModel {
        public BulletModel(Vector2 position, Vector2 velocity, Sprite sprite, int startingImpactDamage = 2) 
            : base(new Engine(position, velocity), sprite, 1, startingImpactDamage) {

        }
    }
}
