using Beware.Utilities;

namespace Beware.Entities {
    public class PlayerShieldModel : ShieldModel {
        public PlayerShieldModel(int startingHealth = 100, int startingImpactDamage = 15) : base(startingHealth, startingImpactDamage) { }

        public override void Update() {
            ((ShieldHealth)health).DecreaseHealth();

            base.Update();
        }
    }
}
