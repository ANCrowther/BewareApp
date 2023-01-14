using Beware.EntityFeatures;
using Microsoft.Xna.Framework;

namespace Beware.Entities {
    public class BulletModel : EntityModel {
        public BulletModel(Vector2 position, Vector2 velocity, Sprite sprite = null, int startingImpactDamage = 2) : base(startingImpactDamage) {
            Sprite = sprite;
            Engine = new Engine(position, velocity);
        }
    }
}
