﻿using Beware.Builders;
using Beware.Entities;
using Beware.EntityFeatures;
using Beware.Enums;
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
                    Vector2 vel = MathUtil.FromPolar(aimAngle, Values.SabotSpeed);
                    Vector2 offset = Vector2.Transform(new Vector2(25, -8), aimQuat);

                    EntityManager.Add(AmmoBuilder.Factory(AmmoType.SabotRound, player.Engine.Position + offset, vel));
                    PlayerStatus.SpecialAmmoCount--;
                }
            }
        }
    }
}
