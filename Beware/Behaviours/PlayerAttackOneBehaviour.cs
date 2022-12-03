using Beware.Entities;
using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.Behaviours {
    public class PlayerAttackOneBehaviour : IBehaviour {
        public void Update(EntityModel entity) {
            PlayerModel.Instance.IsShooting = false;
            PlayerModel.Instance.Aim = Helpers.GetDirection(Mode.Shoot);

            if (PlayerModel.Instance.Aim.LengthSquared() > 0) {
                PlayerModel.Instance.IsShooting = true;
                PlayerModel.Instance.Aim.Normalize();
                PlayerModel.Instance.Orientation = PlayerModel.Instance.Aim.ToAngle();
            }

            PlayerModel.Instance.Position = Vector2.Clamp(PlayerModel.Instance.Position, PlayerModel.Instance.Size / 2, ViewportManager.GetWindowSize(View.GamePlay) - PlayerModel.Instance.Size / 2);

            // Creates the bullets whenever the player shoots.
            if (Input.WasKeyPressed(ControlMap.Shoot) || Input.WasButtonPressed(ControlMap.Shoot_pad)) {
                float aimAngle = PlayerModel.Instance.Orientation;
                Quaternion aimQuat = Quaternion.CreateFromYawPitchRoll(0, 0, aimAngle);

                Vector2 vel = MathUtil.FromPolar(aimAngle, 11f);
                Vector2 offset = Vector2.Transform(new Vector2(25, -8), aimQuat);

                BulletModel bullet = new BulletModel(PlayerModel.Instance.Position + offset, vel);
                bullet.SetBehaviour(BehaviourCategory.Move, new BulletBehaviour());
                EntityManager.Add(bullet);
            }
        }
    }
}
