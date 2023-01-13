using Beware.Entities;
using Beware.Utilities;

namespace Beware.EntityFeatures {
    public class PlayerShield : Shield {
        public PlayerShield(EntityModel entity, int startingHealth = 100, int startingImpactDamage = 25) 
            : base(entity, startingHealth, startingImpactDamage) { }


        public PlayerShield(int startingHealth = 100, int startingImpactDamage = 25) 
            : base(null, startingHealth, startingImpactDamage) {
            Sprite = new Sprite(EntityArt.Shield);
        }

        public override void Draw() {
            base.Draw();
        }

        public override void Update() {
            ((ShieldHealth)health).DecreaseHealth();

            base.Update();
        }
    }
}
