using System;

namespace Beware.Utilities {
    public class Health {
        int totalHealth;
        public event EventHandler OnDeath;
        public int CurrentHealth { get; private set; }

        public Health(int startingHealth) {
            totalHealth = CurrentHealth = startingHealth;
        }

        public void TakeDamage(int damage) {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0) {
                OnDeath?.Invoke(this, new EventArgs());
                CurrentHealth = totalHealth;
            }
        }
    }
}
