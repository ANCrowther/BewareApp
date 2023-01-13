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
            if (component is DrawableGameComponent c) {
                c.Visible = isEnabled;
            }
        }

        private static GameScene CreateNewGame() {
            if (ViewportManager.CurrentLayout == ViewportLayout.Nintendo) {
                return CreateNintendoLayout();
            }

            if (ViewportManager.CurrentLayout == ViewportLayout.NoPanel) {
                return CreateNoPanelLayout();
            }

            return CreateStandardBackground();
        }

        private static GameScene CreateNoPanelLayout() {
            BackgroundMoving gameboardBackground = new BackgroundMoving(ScenesArt.BlinkingStar, View.HUD);
            GameboardLogic gameboardLogic = new GameboardLogic();
            PanelOneLogic headsUpDisplayLogic = new PanelOneLogic();

            return new GameScene(gameboardBackground, gameboardLogic, headsUpDisplayLogic);
        }

        private static GameScene CreateStandardBackground() {
            BackgroundStationary tickerBackground = new BackgroundStationary(ScenesArt.GenericSpace, View.Ticker);
            TickerLogic tickerLogic = new TickerLogic();

            BackgroundMoving gameboardBackground = new BackgroundMoving(ScenesArt.BlinkingStar, View.GamePlay);
            GameboardLogic gameboardLogic = new GameboardLogic();

            BackgroundStationary panelOneBackground = new BackgroundStationary(ScenesArt.ArtificialPlanet, View.InfoOne);
            PanelOneLogic panelOneLogic = new PanelOneLogic();

            BackgroundStationary panelTwoBackground = new BackgroundStationary(ScenesArt.ArtificialPlanet, View.InfoTwo);
            PanelTwoLogic panelTwoLogic = new PanelTwoLogic();

            ViewportManager.ChangeDimension(Dimension.Standard);
            return new GameScene(tickerBackground, tickerLogic, panelOneBackground, panelOneLogic, panelTwoBackground, panelTwoLogic, gameboardBackground, gameboardLogic);
        }

        private static GameScene CreateNintendoLayout() {
            BackgroundMoving gameboardBackground = new BackgroundMoving(ScenesArt.BlinkingStar, View.GamePlay);
            GameboardLogic gameboardLogic = new GameboardLogic();

            BackgroundStationary leftControllerBackground = new BackgroundStationary(ScenesArt.LeftController, View.InfoOne);
            PanelOneLogic panelOneLogic = new PanelOneLogic();

            BackgroundStationary rightControllerBackground = new BackgroundStationary(ScenesArt.RightController, View.InfoTwo);
            PanelTwoLogic panelTwoLogic = new PanelTwoLogic();

            BackgroundStationary tickerBackground = new BackgroundStationary(ScenesArt.GenericSpace, View.Ticker);
            TickerLogic tickerLogic = new TickerLogic();

            ViewportManager.ChangeDimension(Dimension.Nintendo);
            return new GameScene(tickerBackground, tickerLogic, leftControllerBackground, panelOneLogic, rightControllerBackground, panelTwoLogic, gameboardBackground, gameboardLogic);
        }

        private static GameScene CreateMenuWindow() {
            StartMenuComponents menuOptions = new StartMenuComponents(new Vector2(ViewportManager.MenuView.Width / 3, ViewportManager.MenuView.Height / 3));
            StartMenuLogic menuLogic = new StartMenuLogic(menuOptions);
            BackgroundStationary background = new BackgroundStationary(ScenesArt.NebulaPlanetRing, View.Menu);
            ViewportManager.ChangeDimension(Dimension.Standard);
            return new GameScene(background, menuOptions, menuLogic);
        }

        private static GameScene CreatePlayerSettingWindow() {
            BackgroundStationary background = new BackgroundStationary(ScenesArt.StellarSpaceship, View.Menu);
            PlayerSettingsLogic logic = new PlayerSettingsLogic();
            ViewportManager.ChangeDimension(Dimension.Standard);
            return new GameScene(background, logic);
        }

        private static GameScene CreateGameSettingWindow() {
            BackgroundStationary background = new BackgroundStationary(ScenesArt.SpacePlanetsStars, View.Menu);
            GameSettingsLogic logic = new GameSettingsLogic();
            ViewportManager.ChangeDimension(Dimension.Standard);
            return new GameScene(background, logic);
        }

        private static GameScene CreateGameOverWindow() {
            if (ViewportManager.CurrentLayout == ViewportLayout.Nintendo) {
                return CreateNintendoGameOverWindow();
            }
            BackgroundStationary background = new BackgroundStationary(ScenesArt.SpaceBattleWide, View.Menu);
            GameOverLogic logic = new GameOverLogic();
            ViewportManager.ChangeDimension(Dimension.Standard);
            return new GameScene(background, logic);
        }

        private static GameScene CreateNintendoGameOverWindow() {
            BackgroundStationary background = new BackgroundStationary(ScenesArt.RedSky, View.GamePlay);
            GameOverLogic logic = new GameOverLogic();

            BackgroundStationary leftControllerBackground = new BackgroundStationary(ScenesArt.LeftController, View.InfoOne);
            PanelOneLogic panelOneLogic = new PanelOneLogic();

            BackgroundStationary rightControllerBackground = new BackgroundStationary(ScenesArt.RightController, View.InfoTwo);
            PanelTwoLogic panelTwoLogic = new PanelTwoLogic();

            BackgroundStationary tickerBackground = new BackgroundStationary(ScenesArt.GenericSpace, View.Ticker);
            TickerLogic tickerLogic = new TickerLogic();

            ViewportManager.ChangeDimension(Dimension.Nintendo);
            return new GameScene(tickerBackground, tickerLogic, background, logic, leftControllerBackground, panelOneLogic, rightControllerBackground, panelTwoLogic);
        }
    }
}
