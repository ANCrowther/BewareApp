using Beware.EntityFeatures;
using Beware.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Beware.Entities {
    public abstract class EnemyModel : EntityModel {
        private readonly int timeUntilStart = 60;
        private Random random = new Random();
        public bool IsActive { get { return timeUntilStart <= 60; } }

        public EnemyModel(Texture2D image, Vector2 position, int startingHealth, int startingImpactDamage = 5, Sprite sprite = null) 
            : base(new Engine(position, Vector2.Zero), new Sprite(image, 1.3f), startingHealth, startingImpactDamage) {
            Health.OnHit += delegate { this.Health.ResetHealthBarFramesUntilColorChange(); };
        }

        public void HandleCollision(EntityModel other) {
            var d = Engine.Position - other.Engine.Position;
            Engine.Velocity += 10 * d / (d.LengthSquared() + 1);
        }

        public override void Update() {
            Health.Update();
            base.Update();
        }

        public override void Hit(int damage = 1) {
            // TODO: add spawning dropped items logic
            if (random.Next(50) == 0) {
                ItemDropSpawner.SpawnItem(this.Engine.Position);
            }
            base.Hit(damage);
        }

        public override void Draw() {
            if (!IsExpired) {
                Vector2 position = new Vector2(Engine.Position.X, Engine.Position.Y + Sprite.Size.Y / 2 + 5);
                Health.Draw(position);

                base.Draw();
            }
        }
    }
}
