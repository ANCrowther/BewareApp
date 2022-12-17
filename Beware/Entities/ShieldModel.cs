using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;

namespace Beware.Entities {
    public class ShieldModel : EntityModel {
        private Color[] colors = { Color.White, Color.AliceBlue, Color.Yellow, Color.Orange, Color.DarkOrange, Color.Red };
        private int maxShieldHealth;

        public ShieldModel(int startingHealth = 100, int startingImpactDamage = 15) : base(startingHealth, startingImpactDamage) {
            CollisionRadius = 40;
            maxShieldHealth = startingHealth;
            image = EntityArt.Shield;
            Position = PlayerModel.Instance.Position;
            health = new ShieldHealth();
            health.OnDeath += delegate { this.Die(); };
        }

        public override void Update() {
            Position = PlayerModel.Instance.Position;
            
            if (health is ShieldHealth s) {
                s.Update();
            }

            UpdateDrawColor();
            base.Update();
        }

        private void UpdateDrawColor() {
            int index = (maxShieldHealth - health.CurrentHealth) / 16;
            index = (index < 0) ? 0 : index;
            index = (index > 5) ? 5 : index;
            color = colors[index];
        }

        public override void Draw() {
            float scale = 0.3f + 0.1f * (float)Math.Sin(5 * BewareGame.GameTime.TotalGameTime.TotalSeconds);
            BewareGame.Instance._spriteBatch.Draw(image, Position, null, color, Orientation, Size / 2f, scale, 0, 0);
        }
    }
}
