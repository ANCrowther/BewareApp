using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Timers;

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

        private PlayerModel(int startingHealth = 8) : base(startingHealth) {
            Position = ViewportManager.GetWindowSize(Utilities.View.GamePlay) / 2;
            CollisionRadius = 10;
            image = EntityArt.Player1;
            health.OnDeath += delegate { this.Die(); ScoreKeeper.RemoveLife(); };
        }

        public override void Update() {
            if (IsDead) {
                if (--framesUntilRespawn == 0) {
                    if (ScoreKeeper.Lives == 0) {
                        ScoreKeeper.Reset();
                        Position = ViewportManager.GetWindowSize(Utilities.View.GamePlay) / 2;
                    }
                    //IsExpired = false;
                }

                return;
            }

            base.Update();
        }


        public override void Draw() {
            if (!IsDead) {
                base.Draw();
            }
        }

        public override void Die() {
            framesUntilRespawn = 60;
            base.Die();
        }
    }
}
