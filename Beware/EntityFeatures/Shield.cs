using Beware.Entities;
using Beware.ExtensionSupport;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;

namespace Beware.EntityFeatures {
    public abstract class Shield : EntityFeature {
        public bool IsExpired;
        private readonly int baseImpactDamage;
        protected int maxShieldHealth;
        protected Health health;
        private readonly int colorCount = 0;
        public Vector2 ImpactDamage { get { return this.Entity.Engine.Velocity; } }


        public virtual HitCircle CollisionCircle { get { return new HitCircle(Entity.Engine.Position, Sprite.Radius / 6); } }

        public Shield(EntityModel entity, int startingHealth = 20, int startingImpactDamage = 15) 
            : base(entity, new Sprite(EntityArt.Shield)) {
            health = new ShieldHealth(startingHealth);
            maxShieldHealth = startingHealth;
            baseImpactDamage = startingImpactDamage;
            health.OnDeath += delegate { this.Die(); };

            foreach (var item in Helpers.colors2) {
                colorCount++;
            }
        }

        public override void Update() {
            UpdateDrawColor();
        }

        private void UpdateDrawColor() {
            int index = (maxShieldHealth - health.CurrentHealth) / colorCount;
            index = (index < 0) ? 0 : index;
            index = (index > colorCount - 1) ? colorCount - 1 : index;
            Sprite.color = Helpers.colors2[index];
        }

        public virtual void HandleCollision(EntityModel other) {
            var d = Entity.Engine.Position - other.Engine.Position;
            Entity.Engine.Velocity += 10 * d / (d.LengthSquared() + 1);
        }

        protected virtual void Die() {
            IsExpired = true;
        }

        public virtual void Hit(Vector2 damage) {
            this.health.TakeDamage(this.Entity.Engine.Velocity.GetDamage(damage, baseImpactDamage));
        }

        public override void Draw() {
            Sprite.Scale = 0.3f + 0.05f * (float)Math.Sin(2 * BewareGame.GameTime.TotalGameTime.TotalSeconds);
            Sprite.Draw(Entity.Engine);
        }
    }
}
