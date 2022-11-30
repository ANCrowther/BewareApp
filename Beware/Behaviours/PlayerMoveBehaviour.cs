using Beware.Entities;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.Behaviours {
    public class PlayerMoveBehaviour : IBehaviour {
        public void Update() {
            PlayerModel.Instance.Velocity = Helpers.GetDirection(Mode.Move);
            PlayerModel.Instance.Position += PlayerModel.Instance.Velocity;

            if (PlayerModel.Instance.IsShooting == false) {
                PlayerModel.Instance.Orientation = PlayerModel.Instance.Velocity.ToAngle();
                PlayerModel.Instance.Position = Vector2.Clamp(PlayerModel.Instance.Position, PlayerModel.Instance.Size / 2, ViewportManager.GetWindowSize(View.GamePlay) - PlayerModel.Instance.Size / 2);
            }
        }
    }
}
