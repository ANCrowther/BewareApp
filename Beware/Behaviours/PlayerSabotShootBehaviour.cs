using Beware.Entities;
using Beware.ExtensionSupport;
using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;

namespace Beware.Behaviours {
    class PlayerSabotShootBehaviour : IBehaviour {
        private Random random = new Random();
        private int cooldownRemaining = 0;
        private const int cooldownFrames = 6;

        public event Action OnShooting;

        public void Update(EntityModel entity) {
            PlayerGunModel.Instance.IsShooting = false;
            PlayerGunModel.Instance.Aim = Helpers.GetDirection(Mode.Shoot);

            PlayerGunModel.Instance.Orientation = PlayerModel.Instance.Orientation;
            PlayerGunModel.Instance.IsShooting = Input.IsButtonHeldDown(ControlMap.Special_pad);

            if (PlayerGunModel.Instance.Aim.LengthSquared() > 0) {
                PlayerGunModel.Instance.Aim.Normalize();
                PlayerGunModel.Instance.Orientation = PlayerGunModel.Instance.Aim.ToAngle();
            }

            PlayerGunModel.Instance.Position = Vector2.Clamp(PlayerGunModel.Instance.Position, PlayerGunModel.Instance.Size / 2, ViewportManager.GetWindowSize(View.GamePlay) - PlayerGunModel.Instance.Size / 2);

            // Creates the bullets whenever the player shoots.
            if ((Input.IsKeyHeldDown(ControlMap.Shoot) || Input.IsButtonHeldDown(ControlMap.Shoot_pad)) && cooldownRemaining <= 0) {
                OnShooting?.Invoke();

                ResetCooldown();
                float aimAngle = PlayerGunModel.Instance.Orientation;

                Quaternion aimQuat = Quaternion.CreateFromYawPitchRoll(0, 0, aimAngle);

                float randomSpread = random.NextFloat(-0.4f, 0.4f) + random.NextFloat(-0.4f, 0.4f);
                Vector2 vel = MathUtil.FromPolar(aimAngle + randomSpread, 11f);
                Vector2 offset = Vector2.Transform(new Vector2(25, -8), aimQuat);

                BulletModel bullet = new BulletModel(PlayerModel.Instance.Position + offset, vel);
                bullet.SetBehaviour(BehaviourCategory.Move, new BulletBehaviour());
                EntityManager.Add(bullet);
            }

            UpdateCooldown();
        }

        private void ResetCooldown() {
            cooldownRemaining = cooldownFrames;
        }

        private void UpdateCooldown() {
            if (cooldownRemaining > 0) {
                cooldownRemaining--;
            }
        }
    }
}
