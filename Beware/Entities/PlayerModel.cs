using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.Entities {
    public class PlayerModel : EntityModel {
        private static PlayerModel instance;
        private int framesUntilRespawn = 0;

        public Vector2 Aim { get; set; }
        public bool IsShooting { get; set; } = false;
        public bool IsSlow { get; set; } = false;
        public bool IsDead { get { return framesUntilRespawn > 0; } }

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
