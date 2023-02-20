using Beware.Entities;
using Beware.EntityFeatures;
using Beware.Enums;
using Beware.ExtensionSupport;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;

namespace Beware.Behaviours {
    class EnemyRandomShootBehaviour : IBehaviour {
        private readonly Random random = new Random();
        private int cooldownRemaining = 10;
        private const int cooldownFrames = 125;
        private const float spreadLimit = 0.5f;

        public void Update(EntityModel entity) {
            if (cooldownRemaining <= 0) {
                ResetCooldown();

                float aimAngle = (PlayerModel.Instance.Engine.Position - entity.Engine.Position).ToAngle();
                Quaternion aimQuat = Quaternion.CreateFromYawPitchRoll(0, 0, aimAngle);
                float randomSpread = random.NextFloat(-spreadLimit, spreadLimit) + random.NextFloat(-spreadLimit, spreadLimit);
                Vector2 vel = MathUtil.FromPolar(aimAngle + randomSpread, 11f);
                Vector2 offset = Vector2.Transform(new Vector2(25, -8), aimQuat);

                AmmoModel bullet = new BulletModel(entity.Engine.Position + offset, vel, new Sprite(EntityArt.Bullet));
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
