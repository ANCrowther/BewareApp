using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.GameScenes {
    public class GameboardLogic : DrawableGameComponent {
        
        public GameboardLogic() : base (BewareGame.Instance) {
        }

        public override void Update(GameTime gameTime) {
            if (Input.WasKeyPressed(ControlMap.Back) || Input.WasButtonPressed(ControlMap.Back_pad)) {
                //BewareGame.Instance.Scene.SwitchScene(SceneManager.MenuWindow);
                SceneManager.SwitchScene(SceneManager.MenuWindow);
            }

            base.Update(gameTime);
        }
    }
}
