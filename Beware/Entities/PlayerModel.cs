using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Timers;

namespace Beware.Entities {
    public class PlayerModel : EntityModel {
        private static PlayerModel instance;
        private int framesUntilRespawn = 0;
        //private Health health;

        public Vector2 Aim { get; set; }
        public bool IsShooting { get; set; } = false;
        public bool IsSlow { get; set; } = false;
        public bool IsDead { get { return framesUntilRespawn > 0; } }

        public event EventHandler OnCollide;

        public static PlayerModel Instance {
            get {
                if (instance == null) {
                    instance = new PlayerModel();
                }
                return instance;
            }
        }

        private PlayerModel() : base() {
            Position = ViewportManager.GetWindowSize(Utilities.View.GamePlay) / 2;
            CollisionRadius = 10;
            image = EntityArt.Player1;
            IsHit = false;
            health = new Health(8);
            health.OnDeath += delegate { this.Die(); Kill(); };
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

        private void Respawn() {
            IsHit = true;
            Timer timer = new Timer(2500); // 0.25 seconds
            timer.Elapsed += (e, o) => { IsHit = false; };
            timer.AutoReset = false;
            timer.Start();
        }
    }
}
