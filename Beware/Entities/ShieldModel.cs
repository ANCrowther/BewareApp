using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;

namespace Beware.Entities {
    public class ShieldModel : EntityModel {
        public ShieldModel(int startingHealth = 100, int startingImpactDamage = 15) : base(startingHealth, startingImpactDamage) {
            CollisionRadius = 40;
            image = EntityArt.Shield;
            Position = PlayerModel.Instance.Position;
            health = new ShieldHealth();
            health.OnDeath += delegate { this.Die(); };
            health.OnHit += delegate { health.ResetTimer(); };
        }

        public override void Update() {
            Position = PlayerModel.Instance.Position;
            UpdateDrawColor();
            TimeKeeper.Update();
            base.Update();
        }

        private void UpdateDrawColor() {
            if (health.CurrentHealth > 80) {
                color = Color.CadetBlue;
            } else if (health.CurrentHealth > 60) {
                color = Color.DarkBlue;
            } else if (health.CurrentHealth > 40) {
                color = Color.MediumPurple;
            } else if (health.CurrentHealth > 20) {
                color = Color.Purple;
            } else {
                color = Color.Red;
            }
        }

        public override void Draw() {
            float scale = 0.3f + 0.1f * (float)Math.Sin(5 * BewareGame.GameTime.TotalGameTime.TotalSeconds);
            BewareGame.Instance._spriteBatch.Draw(image, Position, null, color, Orientation, Size / 2f, scale, 0, 0);
        }
    }
}
