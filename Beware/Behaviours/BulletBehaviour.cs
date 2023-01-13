using Beware.Entities;
using Beware.ExtensionSupport;
using Beware.Managers;

namespace Beware.Behaviours {
    class BulletBehaviour : IBehaviour {
        public void Update(EntityModel entity) {
            if (entity.Engine.Velocity.LengthSquared() > 0) {
                entity.Engine.Orientation = entity.Engine.Velocity.ToAngle();
            }

            entity.Engine.Position += entity.Engine.Velocity;

            if (entity.Engine.Position.X <= 0 || entity.Engine.Position.X >= ViewportManager.GameboardView.Width ||
                entity.Engine.Position.Y <= 0 || entity.Engine.Position.Y >= ViewportManager.GameboardView.Height) {
                entity.IsExpired = true;
            }
        }
    }
}
