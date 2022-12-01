using Beware.Entities;
using Beware.Managers;
using Beware.Utilities;

namespace Beware.Behaviours {
    class PlayerBulletBehaviour : IBehaviour {
        EntityModel entity;

        public PlayerBulletBehaviour(EntityModel entity) {
            this.entity = entity;
        }

        public void Update() {
            if (this.entity.Velocity.LengthSquared() > 0) {
                this.entity.Orientation = this.entity.Velocity.ToAngle();
            }

            this.entity.Position += this.entity.Velocity;

            if (this.entity.Position.X <= 0 || this.entity.Position.X >= ViewportManager.GameboardView.Width ||
                this.entity.Position.Y <= 0 || this.entity.Position.Y >= ViewportManager.GameboardView.Height) {
                this.entity.IsExpired = true;
            }
        }
    }
}
