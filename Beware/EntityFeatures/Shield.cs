using Beware.Entities;
using Beware.Utilities;
using System;

namespace Beware.EntityFeatures {
    public abstract class Shield : EntityFeature {
        public bool IsExpired;
        public int ImpactDamage;
        protected int maxShieldHealth;
        protected Health health;
        private readonly int colorCount = 0;

        public virtual HitCircle CollisionCircle { get { return new HitCircle(Entity.Engine.Position, Sprite.Radius / 6); } }

        public Shield(EntityModel entity, int startingHealth = 20, int startingImpactDamage = 15) : base(entity) {
            health = new ShieldHealth(startingHealth);
            Sprite = new Sprite(EntityArt.Shield);
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

        public virtual void Hit(int damage = 1) {
            health.TakeDamage(damage);
        }

        public override void Draw() {
            //float scale = 0.3f + 0.05f * (float)Math.Sin(2 * BewareGame.GameTime.TotalGameTime.TotalSeconds);
            Sprite.Scale = 0.3f + 0.05f * (float)Math.Sin(2 * BewareGame.GameTime.TotalGameTime.TotalSeconds);
            Sprite.Draw(Entity.Engine);
            //Sprite.Draw(Entity.Engine.Position, Entity.Engine.Orientation, scale);
            //BewareGame.Instance._spriteBatch.Draw(Sprite.Image, Entity.Engine.Position, null, Sprite.color, Entity.Engine.Orientation, Sprite.Size / 2f, scale, 0, 0);
        }
    }
}
