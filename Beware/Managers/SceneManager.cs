using Beware.GameScenes;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Linq;

/*      |---|--- --- --- ---|           |---|--- --- ---|---|
 *      |   |               |           |   |           |   |
 *      |   |               |           |   |           |   |
 *      |   |               |           |   |           |   |
 *      |   |--- --- --- ---|           |   |           |   |
 *      |   |--- --- --- ---|           |   |           |   |
 *      |   |               |           |   |--- --- ---|   |
 *      |---|--- --- --- ---|           |---|--- --- ---|---|
 *          CreateLayout1()                 CreateLayout2()
 */

namespace Beware.Managers {
    public class SceneManager {
        public static GameScene MenuWindow { get; private set; }
        public static GameScene PlayerSettingsWindow { get; private set; }
        public static GameScene GameSettingsWindow { get; private set; }

        public GameScene NewGame => CreateNewGame();

        public SceneManager() {
            Initialize();
        }

        private GameScene CreateNewGame() {
            if (ViewportManager.CurrentLayout == ViewportLayout.Layout1) {
                ViewportManager.ChangeLayout(ViewportLayout.Layout2);
            } else {
                ViewportManager.ChangeLayout(ViewportLayout.Layout1);
            }

            BackgroundStationary tickerBackground = new BackgroundStationary(Scenes.Stars_1, View.Ticker);
            TickerLogic tickerLogic = new TickerLogic(View.Ticker);

            BackgroundStationary gameboardBackground = new BackgroundStationary(Scenes.Stars_2, View.GamePlay);
            GameboardLogic gameboardLogic = new GameboardLogic(View.GamePlay);

            BackgroundStationary leftPanelBackground = new BackgroundStationary(Scenes.Stars_3, View.InfoOne);
            PanelOneLogic panelOneLogic = new PanelOneLogic(View.InfoOne);

            BackgroundStationary panelTwoBackground = new BackgroundStationary(Scenes.Stars_4, View.InfoTwo);
            PanelTwoLogic panelTwoLogic = new PanelTwoLogic(View.InfoTwo);
            return new GameScene(tickerBackground, tickerLogic, leftPanelBackground, panelOneLogic, panelTwoBackground, panelTwoLogic, gameboardBackground, gameboardLogic);
        }

        public void SwitchScene(GameScene inputScene) {
            GameComponent[] components = inputScene.ReturnComponents();
            foreach (GameComponent component in BewareGame.Instance.Components) {
                bool isActive = components.Contains(component);
                ChangeComponentState(component, isActive);
            }
        }

        private void Initialize() {
            InitializeMenuWindow();
            InitializePlayerSettingsWindow();
            InitializeGameSettingsWindow();
        }

        private void InitializeGameSettingsWindow() {
            BackgroundStationary background = new BackgroundStationary(Scenes.Stars_1, View.Menu);
            GameSettingsLogic logic = new GameSettingsLogic(View.Menu);
            GameSettingsWindow = new GameScene(background, logic);
        }

        private void InitializePlayerSettingsWindow() {
            BackgroundStationary background = new BackgroundStationary(Scenes.Stars_2, View.Menu);
            PlayerSettingsLogic logic = new PlayerSettingsLogic(View.Menu);
            PlayerSettingsWindow = new GameScene(background, logic);
        }

        private void InitializeMenuWindow() {
            StartMenuComponents menuOptions = new StartMenuComponents(new Vector2(ViewportManager.MenuView.Width / 3, ViewportManager.MenuView.Height / 3));
            StartMenuLogic menuLogic = new StartMenuLogic(menuOptions);
            BackgroundStationary background = new BackgroundStationary(Scenes.Stars_3, View.Menu);
            MenuWindow = new GameScene(background, menuOptions, menuLogic);
        }

        private void ChangeComponentState(GameComponent component, bool isEnabled) {
            component.Enabled = isEnabled;
            if (component is DrawableGameComponent) {
                ((DrawableGameComponent)component).Visible = isEnabled;
            }
        }
    }
}
