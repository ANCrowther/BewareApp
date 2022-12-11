using Beware.Entities;
using Beware.ExtensionSupport;
using Beware.Managers;

namespace Beware.Behaviours {
    class BulletBehaviour : IBehaviour {
        public void Update(EntityModel entity) {
            if (entity.Velocity.LengthSquared() > 0) {
                entity.Orientation = entity.Velocity.ToAngle();
            }

            entity.Position += entity.Velocity;

            if (entity.Position.X <= 0 || entity.Position.X >= ViewportManager.GameboardView.Width ||
                entity.Position.Y <= 0 || entity.Position.Y >= ViewportManager.GameboardView.Height) {
                entity.IsExpired = true;
            }
        }
    }
}
