using Beware.Behaviours;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Beware.Entities {
    public abstract class EntityModel {
        public Vector2 Position;
        public Vector2 Velocity;
        public float Orientation;
        public float CollisionRadius = 20.0f;
        public bool IsExpired;
        public Texture2D image;
        public Color color = Color.White;
        public bool IsHit;
        protected Health health;

        protected IBehaviour[] behaviours = new IBehaviour[5];

        public event EventHandler OnCollide;

        public Vector2 Size { get { return image == null ? Vector2.Zero : new Vector2(image.Width, image.Height); } }

        public EntityModel() {
            IsHit = false;
        }

        public virtual HitCircle HitCircle {
            get {
                float r = (float)(this.image.Width > this.image.Height ? image.Height : image.Width);
                var p = Position;
                return new HitCircle(p, r / 4);
            }
        }

        public virtual void Update() {
            foreach (IBehaviour item in behaviours) {
                if (item != null) {
                    item.Update(this);
                }
            }
        }

        public virtual void Hit(int damage = 1) {
            health.TakeDamage(damage);
        }

        public virtual void SetBehaviour(BehaviourCategory category, IBehaviour behaviour) {
            behaviours[(int)category] = behaviour;
        }

        public virtual void Die() {
            IsExpired = true;
        }

        public virtual void Draw() {
            BewareGame.Instance._spriteBatch.Draw(image, Position, null, Color.White, Orientation, Size / 2f, 1.0f, 0, 0);
        }
    }
}
