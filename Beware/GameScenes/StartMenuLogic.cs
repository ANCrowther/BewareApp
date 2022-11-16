using Beware.Inputs;
using Beware.Managers;
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
                switch (components.SelectedItem.Text) {
                    case "Play Game":
                        BewareGame.Instance.Scene.SwitchScene(BewareGame.Instance.Scene.NewGame);
                        break;
                    case "Player Settings":
                        BewareGame.Instance.Scene.SwitchScene(SceneManager.PlayerSettingsWindow);
                        break;
                    case "Game Settings":
                        BewareGame.Instance.Scene.SwitchScene(SceneManager.GameSettingsWindow);
                        break;
                    case "Quit":
                        BewareGame.Instance.Exit();
                        break;
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            base.Draw(gameTime);
        }
    }
}
