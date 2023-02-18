using Beware.EntityFeatures;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.Entities {
    class DroppedItemModel : EntityModel {
        public DroppedItemModel(Vector2 position, Vector2 velocity, Sprite sprite, int startingHealth = 1, int startingImpactDamage = 0) 
            : base(new Engine(position, velocity), sprite, startingHealth, startingImpactDamage) {

        }

        public override void Update() {
            base.Update();
        }

        public override void Hit(Vector2 damage) {
            PlayerStatus.SpecialAmmoCount += 10;
            IsExpired = true;
        }
    }
}
