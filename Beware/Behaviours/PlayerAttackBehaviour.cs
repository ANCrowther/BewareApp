using Beware.Entities;
using Beware.Utilities;

namespace Beware.Behaviours {
    public class PlayerAttackBehaviour : IBehaviour {
        public void Update() {
            PlayerModel.Instance.Aim = Helpers.GetDirection(Mode.Shoot);

            if (PlayerModel.Instance.Aim.LengthSquared() > 0) {
                PlayerModel.Instance.IsShooting = true;
                PlayerModel.Instance.Aim.Normalize();
            }

            if (PlayerModel.Instance.IsShooting == true) {
                PlayerModel.Instance.Orientation = PlayerModel.Instance.Aim.ToAngle();
            }
        }
    }
}
