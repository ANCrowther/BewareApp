using Beware.Entities;
using Beware.Enums;
using Beware.ExtensionSupport;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.Behaviours {
    public class PlayerMoveBehaviour : IBehaviour {
        public void Update(EntityModel entity) {
            Update((PlayerModel)entity);
        }

        private void Update(PlayerModel player) {
            player.Engine.Velocity = Helpers.GetDirection(Mode.Move) * player.Engine.CurrentSpeed;
            player.Engine.Velocity *= (player.Engine.IsBoosting == true) ? 2 : 1;
            player.Engine.Position += player.Engine.Velocity;
            player.Engine.Position = Vector2.Clamp(player.Engine.Position, player.Sprite.Size / 2, ViewportManager.GetWindowSize(View.GamePlay) - player.Sprite.Size / 2);

            if (player.Engine.Velocity.LengthSquared() > 0) {
                player.Engine.Orientation = player.Engine.Velocity.ToAngle();
            }
        }
    }
}
