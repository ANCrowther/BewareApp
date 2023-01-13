using Beware.Behaviours;
using Beware.EntityFeatures;
using Beware.Utilities;

namespace Beware.Entities {
    public abstract class EntityModel {
        public bool IsExpired;
        public int ImpactDamage;

        public Sprite Sprite;
        public Engine Engine;
        public Gun MainGun;
        protected Health Health;

        public Shield Shield { get; set; } = null;

        public virtual HitCircle CollisionCircle { get { return new HitCircle(Engine.Position, Sprite.Radius / 2); } }

        protected IBehaviour[] behaviours = new IBehaviour[5];

        public EntityModel(int startingHealth = 8, int startingImpactDamage = 5, Sprite sprite = null) {
            this.Health = new Health(startingHealth);
            this.ImpactDamage = startingImpactDamage;
            this.Sprite = sprite;
        }

        public virtual void Update() {
            foreach (IBehaviour item in behaviours) {
                if (item != null) {
                    item.Update(this);
                }
            }
        }

        public virtual void Hit(int damage = 1) {
            this.Health.TakeDamage(damage);
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
