using Beware.Entities;
using Beware.ExtensionSupport;
using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;

namespace Beware.Behaviours {
    public class PlayerRapidFireBehaviour : IBehaviour {
        public event Action OnShooting;

        public void Update(EntityModel entity) {
            PlayerGunModel.Instance.IsShooting = false;
            PlayerGunModel.Instance.Aim = Helpers.GetDirection(Mode.Shoot);

            PlayerGunModel.Instance.Orientation = PlayerModel.Instance.Orientation;
            PlayerGunModel.Instance.IsShooting = Input.IsButtonHeldDown(ControlMap.Shoot_pad);

            if (PlayerGunModel.Instance.Aim.LengthSquared() > 0) {
                PlayerGunModel.Instance.Aim.Normalize();
                PlayerGunModel.Instance.Orientation = PlayerGunModel.Instance.Aim.ToAngle();
            }

            PlayerGunModel.Instance.Position = Vector2.Clamp(PlayerGunModel.Instance.Position, PlayerGunModel.Instance.Size / 2, ViewportManager.GetWindowSize(View.GamePlay) - PlayerGunModel.Instance.Size / 2);

            // Creates the bullets whenever the player shoots.
            if (Input.WasKeyPressed(ControlMap.Shoot) || Input.WasButtonPressed(ControlMap.Special_pad)) {
                OnShooting?.Invoke();
                float aimAngle = PlayerGunModel.Instance.Orientation;

                Quaternion aimQuat = Quaternion.CreateFromYawPitchRoll(0, 0, aimAngle);

                Vector2 vel = MathUtil.FromPolar(aimAngle, 11f);
                Vector2 offset = Vector2.Transform(new Vector2(25, -8), aimQuat);

                BulletModel bullet = new SabotRound(PlayerModel.Instance.Position + offset, vel);
                bullet.SetBehaviour(BehaviourCategory.Move, new BulletBehaviour());
                EntityManager.Add(bullet);
            }
        }
    }
}
