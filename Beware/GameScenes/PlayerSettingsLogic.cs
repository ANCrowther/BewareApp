using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.GameScenes {
    public class PlayerSettingsLogic : DrawableGameComponent {

        public PlayerSettingsLogic() : base(BewareGame.Instance) {
        }

        public override void Update(GameTime gameTime) {
            if (Input.WasKeyPressed(ControlMap.Back) || Input.WasButtonPressed(ControlMap.Back_pad)) {
                BewareGame.Instance.Scene.SwitchScene(SceneManager.MenuWindow);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();

            //if (ViewportManager.CurrentLayout == ViewportLayout.Layout1) {
            //    BewareGame.Instance._spriteBatch.Draw(Art.Layout1, new Vector2(150, 150), null, Color.White, 0, new Vector2(Art.Layout1.Width, Art.Layout1.Height) / 2.0f, 0.3f, 0, 0.0f);
            //}

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
