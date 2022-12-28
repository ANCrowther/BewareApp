using Beware.Entities;
using Beware.ExtensionSupport;
using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;

namespace Beware.Behaviours {
    public class PlayerRapidFireBehaviour : IBehaviour {
        private Random random = new Random(); 
        private int cooldownRemaining = 0;
        private const int cooldownFrames = 6;

        public event Action OnUse;

        public void Update(EntityModel entity) {
            if (entity is PlayerGunModel gun) {
                gun.IsShooting = false;
                gun.Aim = Helpers.GetDirection(Mode.Shoot);

                gun.Orientation = PlayerModel.Instance.Orientation;
                gun.IsShooting = Input.IsButtonHeldDown(ControlMap.Shoot);

                if (gun.Aim.LengthSquared() > 0) {
                    gun.Aim.Normalize();
                    gun.Orientation = gun.Aim.ToAngle();
                }

                gun.Position = Vector2.Clamp(gun.Position, gun.Size / 2, ViewportManager.GetWindowSize(View.GamePlay) - gun.Size / 2);

            }

            // Creates the bullets whenever the player shoots.
            if (Input.IsButtonHeldDown(ControlMap.Shoot) && cooldownRemaining <= 0) {
                OnUse?.Invoke();

                ResetCooldown();

                float aimAngle = PlayerGunModel.Instance.Orientation;
                Quaternion aimQuat = Quaternion.CreateFromYawPitchRoll(0, 0, aimAngle);
                float randomSpread = random.NextFloat(-0.2f, 0.2f) + random.NextFloat(-0.2f, 0.2f);
                Vector2 vel = MathUtil.FromPolar(aimAngle + randomSpread, 11f);
                Vector2 offset = Vector2.Transform(new Vector2(25, -8), aimQuat);

                BulletModel bullet = new BulletModel(entity.Position + offset, vel);
                bullet.SetBehaviour(BehaviourCategory.Move, new BulletBehaviour());
                BulletManager.AddPlayerBullet(bullet);
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
