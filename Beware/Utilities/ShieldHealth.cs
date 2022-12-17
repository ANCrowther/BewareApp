﻿using System;

namespace Beware.Utilities {
    public class ShieldHealth : Health {
        public override event Action OnDeath;

        public ShieldHealth(int startingHealth = 100) : base(startingHealth) { }

        public void Update() {
            DecreaseHealth();
        }

        private void DecreaseHealth() {
            if (TimeKeeper.Seconds % 3 == 0) {
                CurrentHealth--;
            }
            if (CurrentHealth <= 0) {
                OnDeath?.Invoke();
            }
        }
    }
}
