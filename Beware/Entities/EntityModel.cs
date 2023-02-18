using Beware.Behaviours;
using Beware.EntityFeatures;
using Beware.ExtensionSupport;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;

namespace Beware.Entities {
    public abstract class EntityModel {
        public bool IsExpired;
        private readonly int baseImpactDamage;

        public Sprite Sprite;
        public Engine Engine;
        public Gun MainGun;
        protected Health Health;

        public Shield Shield { get; set; } = null;
        public virtual HitCircle CollisionCircle { get { return new HitCircle(Engine.Position, Sprite.Radius / 2); } }
        public Vector2 ImpactDamage { get { return this.Engine.Velocity; } }

        protected IBehaviour[] behaviours = new IBehaviour[5];

        public EntityModel(Engine engine, Sprite sprite, int startingHealth, int startingImpactDamage = 5) {
            this.Engine = engine;
            this.Sprite = sprite;
            this.Health = new Health(startingHealth);
            this.baseImpactDamage = startingImpactDamage;
        }

        public virtual void Update() {
            foreach (IBehaviour item in behaviours) {
                if (item != null) {
                    item.Update(this);
                }
            }
        }

        public virtual void Hit(Vector2 damage) {
            this.Health.TakeDamage(this.Engine.Velocity.GetDamage(damage, baseImpactDamage));
        }

        public virtual void SetBehaviour(BehaviourCategory category, IBehaviour behaviour) {
            this.behaviours[(int)category] = behaviour;
        }

        public virtual void RemoveBehaviour(BehaviourCategory category) {
            this.behaviours[(int)category] = null;
        }

        protected virtual void Die() {
            this.IsExpired = true;
        }

        public virtual void Draw() {
            this.Sprite.Draw(this.Engine);
            this.Shield?.Draw();
        }
    }
}
