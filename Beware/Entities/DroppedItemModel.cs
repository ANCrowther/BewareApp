using Beware.EntityFeatures;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.Entities {
    class DroppedItemModel : EntityModel {
        public DroppedItemModel(Vector2 position, Vector2 velocity, Sprite sprite = null, int startingHealth = 1, int startingImpactDamage = 0) : base(startingHealth, startingImpactDamage, sprite) {
            Sprite = sprite;
            Engine = new Engine(position, velocity);
        }

        public override void Update() {
            base.Update();
        }

        public override void Hit(int damage = 0) {
            PlayerStatus.SpecialAmmoCount += 10;
            IsExpired = true;
        }
    }
}
