using Beware.Builders;
using Beware.Entities;
using Beware.Enums;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.Behaviours {
    class EnemyShootBehaviour : IBehaviour {
        private int cooldownRemaining = 10;
        private const int cooldownFrames = 150;

        public void Update(EntityModel entity) {
            if (cooldownRemaining <= 0) {
                ResetCooldown();

                float aimAngle = entity.Engine.Orientation;
                Quaternion aimQuat = Quaternion.CreateFromYawPitchRoll(0, 0, aimAngle);
                Vector2 vel = MathUtil.FromPolar(aimAngle, 11f);
                Vector2 offset = Vector2.Transform(new Vector2(25, -8), aimQuat);

                EntityManager.Add(AmmoBuilder.Factory(AmmoType.EnemyBullet, entity.Engine.Position + offset, vel));
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
