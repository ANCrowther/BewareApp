using Beware.Entities;
using Beware.Enums;
using Beware.Utilities;
using System;

namespace Beware.EntityFeatures {
    public abstract class Shield : EntityFeature {
        public bool IsExpired;
        public readonly int ImpactDamage;
        protected int maxShieldHealth;
        protected Health health;
        private readonly int colorCount = 0;

        public virtual HitCircle CollisionCircle { get { return new HitCircle(Entity.Engine.Position, Sprite.Radius / 3); } }

        public Shield(EntityModel entity, int startingHealth = 100, int startingImpactDamage = 15) 
            : base(entity, new Sprite(EntityArtType.Shield)) {
            health = new ShieldHealth(startingHealth);
            maxShieldHealth = startingHealth;
            ImpactDamage = startingImpactDamage;
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

        public virtual void Hit(int damage) {
            this.health.TakeDamage(damage);
        }

        public override void Draw() {
            Sprite.Scale = 0.3f + 0.05f * (float)Math.Sin(2 * BewareGame.GameTime.TotalGameTime.TotalSeconds);
            //Sprite.Draw(Entity.Engine);
            base.Draw();
        }
    }
}
