using Beware.GameScenes;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Linq;

/*      |---|--- --- --- ---|           |---|--- --- ---|---|
 *      |   |               |           |   |           |   |           |---|--- --- ---|---|
 *      |   |       M       |           |   |     M     |   |           |   |           |   |
 *      |   |               |           |   |           |   |           | 1 |     M     | 2 |
 *      | 1 |--- --- --- ---|           | 1 |           | 2 |           |   |--- --- ---|   |
 *      |   |--- --- --- ---|           |   |           |   |           |---|--- --- ---|---|
 *      |   |       2       |           |   |--- --- ---|   |               Layout 3
 *      |---|--- --- --- ---|           |---|--- --- ---|---|
 *          Layout 1                        Layout 2
 */

namespace Beware.Managers {
    public static class SceneManager {
        public static GameScene NewGame => CreateNewGame();
        public static GameScene MenuWindow => CreateMenuWindow();
        public static GameScene PlayerSettingsWindow => CreatePlayerSettingWindow();
        public static GameScene GameSettingsWindow => CreateGameSettingWindow();
        public static GameScene GameOverWindow => CreateGameOverWindow();
        public static GameScene GameWonWindow { get; private set; }

        public static void SwitchScene(GameScene inputScene) {
            GameComponent[] components = inputScene.ReturnComponents();
            TimeKeeper.Reset();
            foreach (GameComponent component in BewareGame.Instance.Components) {
                bool isActive = components.Contains(component);
                ChangeComponentState(component, isActive);
            }
        }

        private static void ChangeComponentState(GameComponent component, bool isEnabled) {
            component.Enabled = isEnabled;
            if (component is DrawableGameComponent) {
                ((DrawableGameComponent)component).Visible = isEnabled;
            }
        }

        private static GameScene CreateNewGame() {
            if (ViewportManager.CurrentLayout == ViewportLayout.Layout3) {
                return CreateNintendoLayout();
            }

            return CreateStandardBackground();
        }

        private static GameScene CreateStandardBackground() {
            BackgroundStationary tickerBackground = new BackgroundStationary(Scenes.Stars_1, View.Ticker);
            TickerLogic tickerLogic = new TickerLogic();

            BackgroundStationary gameboardBackground = new BackgroundStationary(Scenes.Stars_2, View.GamePlay);
            GameboardLogic gameboardLogic = new GameboardLogic();

            BackgroundMoving panelOneBackground = new BackgroundMoving(Scenes.BlinkingStar, View.InfoOne);
            PanelOneLogic panelOneLogic = new PanelOneLogic();

            BackgroundMoving panelTwoBackground = new BackgroundMoving(Scenes.BlinkingStar, View.InfoTwo);
            PanelTwoLogic panelTwoLogic = new PanelTwoLogic();

            ViewportManager.ChangeDimension(Dimension.Standard);
            return new GameScene(tickerBackground, tickerLogic, panelOneBackground, panelOneLogic, panelTwoBackground, panelTwoLogic, gameboardBackground, gameboardLogic);
        }

        private static GameScene CreateNintendoLayout() {
            BackgroundMoving gameboardBackground = new BackgroundMoving(Scenes.BlinkingStar, View.GamePlay);
            GameboardLogic gameboardLogic = new GameboardLogic();

            BackgroundStationary leftControllerBackground = new BackgroundStationary(Scenes.LeftController, View.InfoOne);
            PanelOneLogic panelOneLogic = new PanelOneLogic();

            BackgroundStationary rightControllerBackground = new BackgroundStationary(Scenes.RightController, View.InfoTwo);
            PanelTwoLogic panelTwoLogic = new PanelTwoLogic();

            BackgroundMoving tickerBackground = new BackgroundMoving(Scenes.BlinkingStar, View.Ticker);
            TickerLogic tickerLogic = new TickerLogic();

            ViewportManager.ChangeDimension(Dimension.Nintendo);
            return new GameScene(tickerBackground, tickerLogic, leftControllerBackground, panelOneLogic, rightControllerBackground, panelTwoLogic, gameboardBackground, gameboardLogic);
        }

        private static GameScene CreateMenuWindow() {
            StartMenuComponents menuOptions = new StartMenuComponents(new Vector2(ViewportManager.MenuView.Width / 3, ViewportManager.MenuView.Height / 3));
            StartMenuLogic menuLogic = new StartMenuLogic(menuOptions);
            BackgroundStationary background = new BackgroundStationary(Scenes.Stars_3, View.Menu);
            ViewportManager.ChangeDimension(Dimension.Standard);
            return new GameScene(background, menuOptions, menuLogic);
        }

        private static GameScene CreatePlayerSettingWindow() {
            BackgroundStationary background = new BackgroundStationary(Scenes.Parchment, View.Menu);
            PlayerSettingsLogic logic = new PlayerSettingsLogic();
            ViewportManager.ChangeDimension(Dimension.Standard);
            return new GameScene(background, logic);
        }

        private static GameScene CreateGameSettingWindow() {
            BackgroundStationary background = new BackgroundStationary(Scenes.GreenSky, View.Menu);
            GameSettingsLogic logic = new GameSettingsLogic();
            ViewportManager.ChangeDimension(Dimension.Standard);
            return new GameScene(background, logic);
        }

        private static GameScene CreateGameOverWindow() {
            if (ViewportManager.CurrentLayout == ViewportLayout.Layout3) {
                return CreateNintendoGameOverWindow();
            }
            BackgroundStationary background = new BackgroundStationary(Scenes.GreenSky, View.Menu);
            GameOverLogic logic = new GameOverLogic();
            ViewportManager.ChangeDimension(Dimension.Standard);
            return new GameScene(background, logic);
        }

        private static GameScene CreateNintendoGameOverWindow() {
            BackgroundStationary background = new BackgroundStationary(Scenes.Stars_4, View.GamePlay);
            GameOverLogic logic = new GameOverLogic();

            BackgroundStationary leftControllerBackground = new BackgroundStationary(Scenes.LeftController, View.InfoOne);
            PanelOneLogic panelOneLogic = new PanelOneLogic();

            BackgroundStationary rightControllerBackground = new BackgroundStationary(Scenes.RightController, View.InfoTwo);
            PanelTwoLogic panelTwoLogic = new PanelTwoLogic();

            BackgroundMoving tickerBackground = new BackgroundMoving(Scenes.BlinkingStar, View.Ticker);
            TickerLogic tickerLogic = new TickerLogic();

            ViewportManager.ChangeDimension(Dimension.Nintendo);
            return new GameScene(tickerBackground, tickerLogic, background, logic, leftControllerBackground, panelOneLogic, rightControllerBackground, panelTwoLogic);
        }
    }
}
