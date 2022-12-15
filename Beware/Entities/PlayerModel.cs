using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.Entities {
    public class PlayerModel : EntityModel {
        private static PlayerModel instance;
        private int framesUntilColorChange = 0;
        
        public bool IsSlow { get; set; } = false;

        public static PlayerModel Instance {
            get {
                if (instance == null) {
                    instance = new PlayerModel();
                }
                return instance;
            }
        }

        private PlayerModel(int startingHealth = 20) : base(startingHealth) {
            Position = ViewportManager.GetWindowSize(Utilities.View.GamePlay) / 2;
            CollisionRadius = 10;
            image = EntityArt.Player1;
            health.OnDeath += delegate { this.Die(); };
            health.OnHit += delegate { this.UpdateDrawColor(); };
        }


        public override void Update() {
            if (framesUntilColorChange-- <= 0) {
                color = Color.Blue;
            }
            if (framesUntilColorChange > 0 && framesUntilColorChange % 10 == 0) {
                color = (color == Color.Blue) ? Color.Red : Color.Blue;
            }

            base.Update();
        }

        private void UpdateDrawColor() {
            framesUntilColorChange = 70;
        }

        public override void Draw() {
            if (!IsExpired) {
                Vector2 position = new Vector2(Position.X, Position.Y + Size.Y / 2 + 5);
                health.DrawPlayerHealth(position, color);
                base.Draw();
            }
        }

        protected override void Die() {
            SceneManager.SwitchScene(SceneManager.GameOverWindow);
        }

        public void ResetPlayer() {
            health.ResetHealth();
            framesUntilColorChange = 0;
            IsExpired = false;
            Position = ViewportManager.GetWindowSize(View.GamePlay) / 2;
            Velocity = Vector2.Zero;
        }
    }
}
