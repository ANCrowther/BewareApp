using Beware.Builders;
using Beware.Entities;
using Beware.EntityFeatures;
using Beware.Enums;
using Beware.ExtensionSupport;
using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;

namespace Beware.Behaviours {
    public class PlayerRapidFireBehaviour : IBehaviour {
        public event Action OnUse;
        private readonly Random random = new Random(); 
        private int cooldownRemaining = 0;
        private const int cooldownFrames = 6;
        private const float spreadLimit = 0.2f;

        public void Update(EntityModel entity) {
            Update((PlayerModel)entity);
            UpdateCooldown();
        }

        private void Update (PlayerModel player) {
            Helpers.UpdatePlayerGunBehaviour(player);

            // Creates the bullets whenever the player shoots.
            if (Input.IsButtonHeldDown(ControlMap.Shoot) && cooldownRemaining <= 0) {
                OnUse?.Invoke();
                ResetCooldown();

                float aimAngle = player.MainGun.Orientation;
                Quaternion aimQuat = Quaternion.CreateFromYawPitchRoll(0, 0, aimAngle);
                float randomSpread = random.NextFloat(-spreadLimit, spreadLimit) + random.NextFloat(-spreadLimit, spreadLimit);
                Vector2 vel = MathUtil.FromPolar(aimAngle + randomSpread, Values.BulletSpeed);
                Vector2 offset = Vector2.Transform(new Vector2(50, -8), aimQuat);

                EntityManager.Add(AmmoBuilder.Factory(AmmoType.PlayerBullet, player.Engine.Position + offset, vel));
            }
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
