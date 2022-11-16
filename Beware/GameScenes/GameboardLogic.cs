using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.GameScenes {
    public class GameboardLogic : DrawableGameComponent {
        private View view;

        public GameboardLogic(View inputView) : base (BewareGame.Instance) {
            this.view = inputView;
        }

        public override void Update(GameTime gameTime) {
            if (Input.WasKeyPressed(ControlMap.Back) || Input.WasButtonPressed(ControlMap.Back_pad)) {
                BewareGame.Instance.Scene.SwitchScene(SceneManager.MenuWindow);
            }

            base.Update(gameTime);
        }
    }
}
