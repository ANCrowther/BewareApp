using Beware.Entities;
using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;

namespace Beware.Behaviours {
    public class PlayerAttackBehaviour : IBehaviour {
        public static Random random = new Random();
        public void Update() {
            PlayerModel.Instance.IsShooting = false;
            PlayerModel.Instance.Aim = Helpers.GetDirection(Mode.Shoot);

            if (PlayerModel.Instance.Aim.LengthSquared() > 0) {
                PlayerModel.Instance.IsShooting = true;
                PlayerModel.Instance.Aim.Normalize();
                PlayerModel.Instance.Orientation = PlayerModel.Instance.Aim.ToAngle();
            }

            if (Input.WasKeyPressed(ControlMap.Shoot) || Input.WasButtonPressed(ControlMap.Shoot_pad)) {
                PlayerModel.Instance.ResetCooldown();
                float aimAngle = PlayerModel.Instance.Orientation;
                Quaternion aimQuat = Quaternion.CreateFromYawPitchRoll(0, 0, aimAngle);

                float randomSpread = random.NextFloat(-0.4f, 0.4f) +
                                     random.NextFloat(-0.4f, 0.4f);
                Vector2 vel = MathUtil.FromPolar(aimAngle + randomSpread, 11f);

                Vector2 offset = Vector2.Transform(new Vector2(25, -8), aimQuat);

                BulletModel bullet = new BulletModel(PlayerModel.Instance.Position + offset, vel);
                IBehaviour behaviour = new PlayerBulletBehaviour(bullet);
                bullet.SetBehaviour(() => behaviour.Update());
                EntityManager.Add(bullet);
            }

            PlayerModel.Instance.UpdateCooldown();
        }
    }
}
