using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Beware.Entities {
    public class PlayerModel : EntityModel {
        private static PlayerModel instance;
        public Vector2 Aim { get; set; }
        public bool IsShooting { get; set; } = false;
        public bool IsDead { get { return framesUntilRespawn > 0; } }
        private int framesUntilRespawn = 0;
        private int cooldownRemaining = 0;
        private const int cooldownFrames = 6;

        public static PlayerModel Instance {
            get {
                if (instance == null) {
                    instance = new PlayerModel();
                }
                return instance;
            }
        }

        private PlayerModel() {
            behaviours = new List<Behaviour>();
            Position = ViewportManager.GetWindowSize(Utilities.View.GamePlay) / 2;
            CollisionRadius = 10;
            image = EntityArt.Player1;
        }

        public void ResetCooldown() {
            cooldownRemaining = cooldownFrames;
        }

        public void UpdateCooldown() {
            if (cooldownRemaining > 0) {
                cooldownRemaining--;
            }
        }

        public override void Draw() {
            if (!IsDead) {
                base.Draw();
            }
        }
    }
}
