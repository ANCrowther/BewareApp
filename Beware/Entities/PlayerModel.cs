using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.Entities {
    public class PlayerModel : EntityModel {
        private static PlayerModel instance;
        public Vector2 Aim { get; set; }
        public bool IsShooting { get; set; } = false;
        public bool IsSlow { get; set; } = false;
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
            Position = ViewportManager.GetWindowSize(Utilities.View.GamePlay) / 2;
            CollisionRadius = 10;
            image = EntityArt.Player1;
        }

        public override void Update() {
            if (IsDead) {
                if (--framesUntilRespawn == 0) {
                    if (ScoreKeeper.Lives == 0) {
                        ScoreKeeper.Reset();
                        Position = ViewportManager.GetWindowSize(Utilities.View.GamePlay) / 2;
                    }
                }
            } else {
                base.Update();
            }

            if (cooldownRemaining > 0) {
                cooldownRemaining--;
            }
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

        public void Kill() {
            ScoreKeeper.RemoveLife();
            framesUntilRespawn = 60;
        }
    }
}
