using Beware.EntityFeatures;
using Beware.Utilities;

namespace Beware.Entities {
    class DroppedSabotAmmo : DroppedItemModel {
        public DroppedSabotAmmo(Engine engine, Sprite sprite, int startingHealth = 1, int startingImpactDamage = 0)
            : base(engine, sprite, startingHealth, startingImpactDamage) { }

        public override void Hit(int damage) {
            PlayerStatus.SpecialAmmoCount += 10;
            IsExpired = true;
        }
    }
}
