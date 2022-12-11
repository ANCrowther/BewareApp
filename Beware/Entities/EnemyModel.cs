using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Beware.Entities {
    public abstract class EnemyModel : EntityModel {
        private int timeUntilStart = 60;
        public bool IsActive { get { return timeUntilStart <= 60; } }
        private int framesUntilColorChange = 0;

        public EnemyModel(Texture2D image, Vector2 position, int startingHealth, int startingImpactDamage = 5) : base(startingHealth, startingImpactDamage) {
            this.image = image;
            Position = position;
            CollisionRadius = image.Width / 2f;
            color = Color.Transparent;
            health.OnHit += delegate { this.UpdateDrawColor(); };
        }

        public void HandleCollision(EnemyModel other) {
            var d = Position - other.Position;
            Velocity += 10 * d / (d.LengthSquared() + 1);
        }


        public override void Update() {
            if (framesUntilColorChange-- <= 0) {
                color = Color.Blue;
            }

            base.Update();
        }

        protected void UpdateDrawColor() {
            color = Color.Red;
            framesUntilColorChange = 50;
        }

        public override void Draw() {
            if (!IsExpired) {
                Vector2 position = new Vector2(Position.X, Position.Y + Size.Y / 2 + 5);
                health.DrawPlayerHealth(position, color);
                base.Draw();
            }
        }
    }
}
