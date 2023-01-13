using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Beware.Utilities {
    public class Health : DrawableGameComponent {
        public virtual event Action OnDeath;
        public virtual event Action OnHit;
        protected int totalHealth;
        protected int framesUntilColorChange = 0;
        protected int healthBarHeight;
        protected Color color;
        protected Texture2D healthBar;
        private const int displayHealthMultiplier = 15;

        public int CurrentHealth { get; protected set; }

        public Health(int startingHealth, int startingHealthBarHeight = 15) : base(BewareGame.Instance) {
            totalHealth = CurrentHealth = startingHealth;
            healthBarHeight = startingHealthBarHeight;
            SetHealthBar(CurrentHealth * displayHealthMultiplier);
        }

        public virtual void TakeDamage(int damage) {
            CurrentHealth -= damage;
            OnHit?.Invoke();
            if (CurrentHealth <= 0) {
                OnDeath?.Invoke();
            }
        }

        public virtual void Update() {
            if (framesUntilColorChange-- <= 0) {
                color = Color.Blue;
            }
            if (framesUntilColorChange > 0 && framesUntilColorChange % 10 == 0) {
                color = (color == Color.Blue) ? Color.Red : Color.Blue;
            }
        }

        public virtual void ResetHealthBarFramesUntilColorChange() {
            framesUntilColorChange = 70;
        }

        public virtual void IncreaseHealth(int increaseHealthBy = 1) {
            CurrentHealth += increaseHealthBy;
        }

        public virtual void ResetHealth() {
            CurrentHealth = totalHealth;
            framesUntilColorChange = 0;
        }

        public virtual void Draw(Vector2 position) {
            SetHealthBar(CurrentHealth * displayHealthMultiplier);
            BewareGame.Instance._spriteBatch.Draw(healthBar, position, null, Color.White, 0, new Vector2(healthBar.Width, healthBar.Height) / 2.0f, 0.2f, 0, 0.0f);
        }

        private void SetHealthBar(int width) {
            width = (width >= 300) ? 300 : width;
            healthBar = new Texture2D(GraphicsDevice, width, healthBarHeight);
            healthBar.CreateHealthBar(color);
        }
    }
}
