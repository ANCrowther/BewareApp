using Beware.Entities;
using Beware.ExtensionSupport;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.Behaviours {
    public class PlayerMoveBehaviour : IBehaviour {
        public void Update(EntityModel entity) {
            float speedModifier = (PlayerStatus.IsSlow) ? PlayerStatus.MinSpeed : PlayerStatus.MaxSpeed;
            entity.Velocity = Helpers.GetDirection(Mode.Move) * speedModifier;
            entity.Position += PlayerModel.Instance.Velocity;
            entity.Position = Vector2.Clamp(entity.Position, entity.Size / 2, ViewportManager.GetWindowSize(View.GamePlay) - entity.Size / 2);
            entity.Orientation = entity.Velocity.ToAngle();

            if (PlayerModel.Instance.Velocity.LengthSquared() <= 0) {
                entity.Orientation = MathHelper.ToRadians(270.0f);
            }
        }
    }
}
