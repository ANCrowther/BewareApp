using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Beware.Utilities {
    public class Health : DrawableGameComponent {
        protected int totalHealth;
        private int displayHealthMultiplier = 15;
        public virtual event Action OnDeath;
        public event Action OnHit;

        public int CurrentHealth { get; protected set; }

        private Texture2D healthBar;

        public Health(int startingHealth) : base(BewareGame.Instance) {
            totalHealth = CurrentHealth = startingHealth;
            SetHealthBar(CurrentHealth * displayHealthMultiplier, 15, Color.Blue);
        }

        public virtual void TakeDamage(int damage) {
            CurrentHealth -= damage;
            OnHit?.Invoke();
            if (CurrentHealth <= 0) {
                OnDeath?.Invoke();
            }
        }

        public virtual void IncreaseHealth(int increaseHealthBy = 1) {
            CurrentHealth += increaseHealthBy;
        }

        public virtual void ResetHealth() {
            CurrentHealth = totalHealth;
        }

        public virtual void DrawPlayerHealth(Vector2 position, Color color) {
            SetHealthBar(CurrentHealth * displayHealthMultiplier, 15, color);
            BewareGame.Instance._spriteBatch.Draw(healthBar, position, null, Color.White, 0, new Vector2(healthBar.Width, healthBar.Height) / 2.0f, 0.2f, 0, 0.0f);
        }

        private void SetHealthBar(int width, int height, Color color) {
            healthBar = new Texture2D(GraphicsDevice, width, height);
            healthBar.CreateHealthBar(color);
        }
    }
}
