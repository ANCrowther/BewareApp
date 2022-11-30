using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Beware.GameScenes {
    public class StartMenuLogic : DrawableGameComponent {
        private StartMenuComponents components;

        public StartMenuLogic(StartMenuComponents menuComponents) : base(BewareGame.Instance) {
            components = menuComponents;
        }

        public override void Update(GameTime gameTime) {
            if (Input.WasKeyPressed(Keys.Enter) || Input.WasButtonPressed(Buttons.A)) {
                switch (components.SelectedItem.name) {
                    case "Play Game":
                        //BewareGame.Instance.Scene.SwitchScene(SceneManager.NewGame);
                        SceneManager.SwitchScene(SceneManager.NewGame);
                        break;
                    case "Player Settings":
                        //BewareGame.Instance.Scene.SwitchScene(SceneManager.PlayerSettingsWindow);
                        SceneManager.SwitchScene(SceneManager.PlayerSettingsWindow);
                        break;
                    case "Game Settings":
                        //BewareGame.Instance.Scene.SwitchScene(SceneManager.GameSettingsWindow);
                        SceneManager.SwitchScene(SceneManager.GameSettingsWindow);
                        break;
                    case "Quit":
                        BewareGame.Instance.Exit();
                        break;
                }
            }

            AudioManager.Update();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();

            if (AudioManager.IsMuted == true) {
                BewareGame.Instance._spriteBatch.Draw(Art.Mute, new Vector2(ViewportManager.MenuView.Width - 150, ViewportManager.MenuView.Height - 150), null, Color.White, 0, new Vector2(Art.Mute.Width, Art.Mute.Height) / 2, 0.25f, 0, 0.0f);
            }

            AudioManager.Draw(new Vector2(ViewportManager.MenuView.Width - 150, ViewportManager.MenuView.Height - 150));

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
