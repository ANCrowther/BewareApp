using Beware.Entities;
using Beware.ExtensionSupport;
using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;

namespace Beware.Behaviours {
    class PlayerAttackTwoBehaviour : IBehaviour {
        private Random random = new Random();
        private int cooldownRemaining = 0;
        private const int cooldownFrames = 6;

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
            if ((Input.IsKeyHeldDown(ControlMap.Shoot) || Input.IsButtonHeldDown(ControlMap.Shoot_pad)) && cooldownRemaining <= 0) {
                ResetCooldown();
                float aimAngle = PlayerModel.Instance.Orientation;
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
