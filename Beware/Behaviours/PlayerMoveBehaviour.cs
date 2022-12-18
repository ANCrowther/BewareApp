using Beware.Entities;
using Beware.ExtensionSupport;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.Behaviours {
    public class PlayerMoveBehaviour : IBehaviour {
        public void Update(EntityModel entity) {
            float speedModifier = (PlayerStatus.IsSlow) ? PlayerStatus.MinSpeed : PlayerStatus.MaxSpeed;
            PlayerModel.Instance.Velocity = Helpers.GetDirection(Mode.Move) * speedModifier;
            PlayerModel.Instance.Position += PlayerModel.Instance.Velocity;
            PlayerModel.Instance.Position = Vector2.Clamp(PlayerModel.Instance.Position, PlayerModel.Instance.Size / 2, ViewportManager.GetWindowSize(View.GamePlay) - PlayerModel.Instance.Size / 2);
            PlayerModel.Instance.Orientation = PlayerModel.Instance.Velocity.ToAngle();

            if (PlayerModel.Instance.Velocity.LengthSquared() <= 0) {
                PlayerModel.Instance.Orientation = MathHelper.ToRadians(270.0f);
            }
        }
    }
}
