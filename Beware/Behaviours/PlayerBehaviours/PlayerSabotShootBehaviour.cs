using Beware.Entities;
using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;

namespace Beware.Behaviours {
    class PlayerSabotShootBehaviour : IBehaviour {
        public event Action OnUse;
        public event Action OnEmpty;

        public void Update(EntityModel entity) {
            if (PlayerStatus.IsSpecialDefensive == false) {
                Update((PlayerModel)entity);
            }
        }

        private void Update(PlayerModel player) {
            Helpers.UpdatePlayerGunBehaviour(player);

            // Creates the bullets whenever the player shoots.
            if (Input.WasButtonPressed(ControlMap.Special)) {
                OnUse?.Invoke();
                if (PlayerStatus.SpecialAmmoCount <= 0) {
                    OnEmpty?.Invoke();
                } else {
                    float aimAngle = player.MainGun.Orientation;
                    Quaternion aimQuat = Quaternion.CreateFromYawPitchRoll(0, 0, aimAngle);
                    Vector2 vel = MathUtil.FromPolar(aimAngle, 11f);
                    Vector2 offset = Vector2.Transform(new Vector2(25, -8), aimQuat);

                    BulletModel bullet = new SabotRound(player.Engine.Position + offset, vel);
                    bullet.SetBehaviour(BehaviourCategory.Move, new BulletBehaviour());
                    BulletManager.AddPlayerBullet(bullet);
                    PlayerStatus.SpecialAmmoCount--;
                }
            }
        }
    }
}
