using Beware.EntityFeatures;
using Beware.Managers;
using Microsoft.Xna.Framework;
using System;

namespace Beware.Entities {
    public abstract class EnemyModel : EntityModel {
        private readonly int timeUntilStart = 60;
        private readonly Random random = new Random();
        public bool IsActive { get { return timeUntilStart <= 60; } }

        public EnemyModel(Engine engine, Sprite sprite, int startingHealth, int startingImpactDamage)
            : base(engine, sprite, startingHealth, startingImpactDamage) {
            Health.OnHit += delegate { this.Health.ResetHealthBarFramesUntilColorChange(); };
            Health.OnDeath += delegate { this.DropItem(); };
        }

        public void HandleCollision(EntityModel other) {
            var d = Engine.Position - other.Engine.Position;
            Engine.Velocity += 10 * d / (d.LengthSquared() + 1);
        }

        public override void Update() {
            Health.Update();
            base.Update();
        }
        
        public override void Draw() {
            if (!IsExpired) {
                Vector2 position = new Vector2(Engine.Position.X, Engine.Position.Y + Sprite.Size.Y / 2 + 5);
                Health.Draw(position);

                base.Draw();
            }
        }

        private void DropItem() {
            if (random.Next(50) == 0) {
                ItemDropSpawner.SpawnItem(this.Engine.Position);
            }
        }
    }
}
