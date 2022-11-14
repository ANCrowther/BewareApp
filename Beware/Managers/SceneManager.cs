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


        public GameScene NewGame => CreateNewGame();

        public SceneManager() {
            Initialize();
        }

        private GameScene CreateNewGame() {
            TickerLogic tickerLogic = new TickerLogic(BewareGame.Instance, View.Ticker);
            BackgroundStationary tickerBackground = new BackgroundStationary(BewareGame.Instance, Scenes.Stars_1, View.Ticker);

            GameboardLogic gameboardLogic = new GameboardLogic(BewareGame.Instance, View.GamePlay);
            BackgroundStationary gameboardBackground = new BackgroundStationary(BewareGame.Instance, Scenes.Stars_2, View.GamePlay);

            PanelOneLogic panelOneLogic = new PanelOneLogic(BewareGame.Instance, View.InfoLeft);
            BackgroundStationary leftPanelBackground = new BackgroundStationary(BewareGame.Instance, Scenes.Stars_3, View.InfoLeft);

            switch (ViewportManager.CurrentLayout) {
                case ViewportLayout.Layout1:
                    (BackgroundStationary background, BottomPanelLogic logic) layout1 = CreateGameLayout1();
                    return new GameScene(tickerBackground, tickerLogic, leftPanelBackground, panelOneLogic, layout1.background, layout1.logic, gameboardBackground);
                case ViewportLayout.Layout2:
                    (BackgroundStationary background, PanelTwoLogic logic) layout2 = CreateGameLayout2();
                    return new GameScene(tickerBackground, tickerLogic, leftPanelBackground, panelOneLogic, layout2.background, layout2.logic, gameboardBackground);
                default:
                    (BackgroundStationary background, BottomPanelLogic logic) defaultLayout = CreateGameLayout1();
                    return new GameScene(tickerBackground, tickerLogic, leftPanelBackground, panelOneLogic, defaultLayout.background, defaultLayout.logic, gameboardBackground);
            }
        }

        private (BackgroundStationary background, BottomPanelLogic logic) CreateGameLayout1() {
            BottomPanelLogic bottomPanelLogic = new BottomPanelLogic(BewareGame.Instance, View.InfoBottom);
            BackgroundStationary bottomPanelBackground = new BackgroundStationary(BewareGame.Instance, Scenes.Stars_4, View.InfoBottom);

            return (bottomPanelBackground, bottomPanelLogic);
        }

        private (BackgroundStationary background, PanelTwoLogic logic) CreateGameLayout2() {
            PanelTwoLogic rightPanelLogic = new PanelTwoLogic(BewareGame.Instance, View.InfoRight);
            BackgroundStationary rightPanelBackground = new BackgroundStationary(BewareGame.Instance, Scenes.Stars_4, View.InfoRight);

            return (rightPanelBackground, rightPanelLogic);
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
        }

        private void InitializePlayerSettingsWindow() {

        }

        private void InitializeMenuWindow() {
            StartMenuComponents menuOptions = new StartMenuComponents(BewareGame.Instance, new Vector2(ViewportManager.MenuView.Width / 3, ViewportManager.MenuView.Height / 3));
            StartMenuLogic menuLogic = new StartMenuLogic(BewareGame.Instance, menuOptions);
            BackgroundStationary background = new BackgroundStationary(BewareGame.Instance, Scenes.Stars_3, View.Menu);
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
