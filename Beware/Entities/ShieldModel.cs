using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;

namespace Beware.Entities {
    public abstract class ShieldModel : EntityModel {
        private Color[] colors = { Color.WhiteSmoke, Color.Gainsboro, Color.Aqua, Color.DeepSkyBlue, Color.Gold, Color.Orange, Color.Tomato, Color.DarkOrange, Color.Red, Color.DarkRed };
        private int colorCount = 0;
        private int maxShieldHealth;

        public ShieldModel(int startingHealth, int startingImpactDamage = 15) : base(startingHealth, startingImpactDamage) {
            image = EntityArt.Shield;
            CollisionRadius = (float)image.Width / 6;
            Position = PlayerModel.Instance.Position;
            health = new ShieldHealth();
            health.OnDeath += delegate { this.Die(); };

            maxShieldHealth = startingHealth;

            foreach (var item in colors) {
                colorCount++;
            }
        }

        public override HitCircle CollisionCircle {
            get {
                float radius = (float)(image.Width > image.Height ? image.Height : image.Width);
                return new HitCircle(Position, radius / 6);
            }
        }

        public override void Update() {
            UpdateDrawColor();
            base.Update();
        }

        public virtual void HandleCollision(EntityModel other) {
            var d = Position - other.Position;
            Velocity += 10 * d / (d.LengthSquared() + 1);
        }

        private void UpdateDrawColor() {
            int index = (maxShieldHealth - health.CurrentHealth) / colorCount;
            index = (index < 0) ? 0 : index;
            index = (index > colorCount - 1) ? colorCount - 1 : index;
            color = colors[index];
        }

        public override void Draw() {
            float scale = 0.3f + 0.05f * (float)Math.Sin(2 * BewareGame.GameTime.TotalGameTime.TotalSeconds);
            BewareGame.Instance._spriteBatch.Draw(image, Position, null, color, Orientation, Size / 2f, scale, 0, 0);
        }
    }
}
