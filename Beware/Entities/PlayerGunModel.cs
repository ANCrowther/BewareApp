using Beware.Behaviours;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.Entities {
    public class PlayerGunModel : EntityModel {
        private static PlayerGunModel instance;

        public Vector2 Aim { get; set; }
        public bool IsShooting { get; set; } = false;

        private int framesUntilColorChange = 0;

        public static PlayerGunModel Instance {
            get {
                if (instance == null) {
                    instance = new PlayerGunModel();
                }
                return instance;
            }
        }

        private PlayerGunModel() : base(1) {
            Position = ViewportManager.GetWindowSize(Utilities.View.GamePlay) / 2;
            image = EntityArt.MainGun;
        }

        public override void SetBehaviour(BehaviourCategory category, IBehaviour behaviour) {
            if (behaviour is PlayerRapidFireBehaviour p) {
                p.OnUse += delegate { UpdateDrawColor(); };
                base.SetBehaviour(category, p);
            }
            if (behaviour is PlayerSabotShootBehaviour q) {
                q.OnUse += delegate { UpdateDrawColor(); };
                q.OnEmpty += delegate { RemoveBehaviour(category); };
                base.SetBehaviour(category, q);
            }
        }

        public override void Update() {
            Position = PlayerModel.Instance.Position;
            if (framesUntilColorChange-- <= 0) {
                color = Color.Lime;
            }
            base.Update();
        }

        private void UpdateDrawColor() {
            color = Color.Red;
            framesUntilColorChange = 10;
        }

        public override void Draw() {
            BewareGame.Instance._spriteBatch.Draw(image, Position, null, color, Orientation, new Vector2(Size.X / 4, Size.Y / 2), 0.3f, 0, 0);
        }
    }
}
