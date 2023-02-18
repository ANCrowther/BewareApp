using Beware.EntityFeatures;

namespace Beware.Entities {
    abstract class AmmoModel : EntityModel {
        public AmmoModel(Engine engine, Sprite sprite, int startingHealth, int startingImpactDamage)
            : base(engine, sprite, startingHealth, startingImpactDamage) {
            Health.OnDeath += delegate { this.Die(); };
        }
    }
}
