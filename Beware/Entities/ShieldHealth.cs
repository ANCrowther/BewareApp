using Microsoft.Xna.Framework;
using System;

namespace Beware.Utilities {
    public class ShieldHealth : Health {
        private int framesUntilShieldHeals = 10;
        public override event Action OnHit;

        public ShieldHealth(int startingHealth = 100) : base(startingHealth) { }

        public override void Update(GameTime gameTime) {
            IncreaseHealth();
            base.Update(gameTime);
        }

        public override void IncreaseHealth(int increaseHealthBy = 1) {
            if (CurrentHealth < totalHealth && framesUntilShieldHeals-- <= 0) {
                CurrentHealth += increaseHealthBy;
            }
        }

        public override void ResetTimer() {
            framesUntilShieldHeals = 10;
        }
    }
}
