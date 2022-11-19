using Beware.GameScenes;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Linq;

/*      |---|--- --- --- ---|           |---|--- --- ---|---|
 *      |   |               |           |   |           |   |           |---|--- --- ---|---|
 *      |   |       M       |           |   |     M     |   |           |   |           |   |
 *      |   |               |           |   |           |   |           | 1 |     M     | 2 |
 *      | 1 |--- --- --- ---|           | 1 |           | 2 |           |   |           |   |
 *      |   |--- --- --- ---|           |   |           |   |           |---|--- --- ---|---|
 *      |   |       2       |           |   |--- --- ---|   |               Layout 3
 *      |---|--- --- --- ---|           |---|--- --- ---|---|
 *          Layout 1                        Layout 2
 */

namespace Beware.Managers {
    public class SceneManager {
        public GameScene NewGame => CreateNewGame();
        public static GameScene MenuWindow { get; private set; }
        public static GameScene PlayerSettingsWindow { get; private set; }
        public static GameScene GameSettingsWindow { get; private set; }
        public static GameScene GameOverWindow { get; private set; }
        public static GameScene GameWonWindow { get; private set; }

        public SceneManager() {
            Initialize();
        }

        public void SwitchScene(GameScene inputScene) {
            GameComponent[] components = inputScene.ReturnComponents();
            TimeKeeper.Reset();
            foreach (GameComponent component in BewareGame.Instance.Components) {
                bool isActive = components.Contains(component);
                ChangeComponentState(component, isActive);
            }
        }

        private void Initialize() {
            InitializeMenuWindow();
            InitializePlayerSettingsWindow();
            InitializeGameSettingsWindow();
            //InitializeGameOverWindow();
            //InitializeGameWonWindow();
        }

        private void ChangeComponentState(GameComponent component, bool isEnabled) {
            component.Enabled = isEnabled;
            if (component is DrawableGameComponent) {
                ((DrawableGameComponent)component).Visible = isEnabled;
            }
        }

        private GameScene CreateNewGame() {
            BackgroundStationary tickerBackground = new BackgroundStationary(Scenes.Stars_1, View.Ticker);
            TickerLogic tickerLogic = new TickerLogic();

            BackgroundStationary gameboardBackground = new BackgroundStationary(Scenes.Stars_2, View.GamePlay);
            GameboardLogic gameboardLogic = new GameboardLogic();

            //BackgroundStationary panelOneBackground = new BackgroundStationary(Scenes.GreenSky, View.InfoOne);
            BackgroundMoving panelOneBackground = new BackgroundMoving(Scenes.BlinkingStar, View.InfoOne);
            PanelOneLogic panelOneLogic = new PanelOneLogic();

            //BackgroundStationary panelTwoBackground = new BackgroundStationary(Scenes.Parchment, View.InfoTwo);
            BackgroundMoving panelTwoBackground = new BackgroundMoving(Scenes.BlinkingStar, View.InfoTwo);
            PanelTwoLogic panelTwoLogic = new PanelTwoLogic();

            // Layout 3 does not use the Ticker logic. It is supposed to mimic a Nintendo Switch (for my son's amusement).
            if (ViewportManager.CurrentLayout == ViewportLayout.Layout3) {
                BackgroundStationary leftControllerBackground = new BackgroundStationary(Scenes.LeftController, View.InfoOne);
                BackgroundStationary rightControllerBackground = new BackgroundStationary(Scenes.RightController, View.InfoTwo);
                return new GameScene(leftControllerBackground, panelOneLogic, rightControllerBackground, panelTwoLogic, gameboardBackground, gameboardLogic);
            }
            return new GameScene(tickerBackground, tickerLogic, panelOneBackground, panelOneLogic, panelTwoBackground, panelTwoLogic, gameboardBackground, gameboardLogic);
        }

        private void InitializeMenuWindow() {
            StartMenuComponents menuOptions = new StartMenuComponents(new Vector2(ViewportManager.MenuView.Width / 3, ViewportManager.MenuView.Height / 3));
            StartMenuLogic menuLogic = new StartMenuLogic(menuOptions);
            BackgroundStationary background = new BackgroundStationary(Scenes.Stars_3, View.Menu);
            MenuWindow = new GameScene(background, menuOptions, menuLogic);
        }

        private void InitializePlayerSettingsWindow() {
            BackgroundStationary background = new BackgroundStationary(Scenes.Parchment, View.Menu);
            PlayerSettingsLogic logic = new PlayerSettingsLogic();
            PlayerSettingsWindow = new GameScene(background, logic);
        }

        private void InitializeGameSettingsWindow() {
            BackgroundStationary background = new BackgroundStationary(Scenes.GreenSky, View.Menu);
            GameSettingsLogic logic = new GameSettingsLogic();
            GameSettingsWindow = new GameScene(background, logic);
        }

        private void InitializeGameOverWindow() {
            throw new NotImplementedException();
        }

        private void InitializeGameWonWindow() {
            throw new NotImplementedException();
        }
    }
}
