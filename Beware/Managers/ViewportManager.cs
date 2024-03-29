﻿using Beware.Enums;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*                              |--- --- --- -|- ---|   |--- -|- --- --- ---|   |--- --- --- --- ---|
 *                              |             |     |   |     |             |   | |- --- --- --- -| |
 *                              |             |     |   |     |             |   | |               | |
 *      |---|--- --- ---|---|   |       M     |  1  |   |  1  |     M       |   | |       M       | |
 *      |   |           |   |   |             |     |   |     |             |   | |               | |
 *      | 1 |     M     | 2 |   |             |     |   |     |             |   | |               | |
 *      |   |--- --- ---|   |   |--- --- --- --- ---|   |--- --- --- --- ---|   | |- --- --- --- -| |
 *      |---|--- --- ---|---|   |--- --- --- --- ---|   |--- --- --- --- ---|   |--- --- --- --- ---|
 *          Nintendo                RightPanel              LeftPanel                NoPanel
 */

//   16:10
//1280×800, 1440x900, 1680x1050, 1920×1200, 2240x1400, 2560×1600

//    16:9
//1280×720, 1366×768, 1600×900, 1920×1080, 2560×1440, 2880x1620, 3840×2160, 5120×2880, 7680×4320

//     4:3
//1400×1050, 1440×1080, 1600×1200, 1920×1440, 2048×1536

namespace Beware.Managers {
    static class ViewportManager {
        public static Viewport GameboardView { get; private set; }
        public static Viewport TickerView { get; private set; }
        public static Viewport InfoOneView { get; private set; }
        public static Viewport InfoTwoView { get; private set; }
        public static Viewport MenuView { get; private set; }
        public static ViewportLayout CurrentLayout { get; private set; } = ViewportLayout.NoPanel;
        private static Viewport Viewport {
            get { return BewareGame.Instance.GraphicsDevice.Viewport; }
            set { BewareGame.Instance.GraphicsDevice.Viewport = value; }
        }

        private static (int width, int height) nintendoDimension = (2070,885);
        private static (int width, int height) standardDimension = (2880, 1620);

        public static void Initialize() {
            ChangeDimension(standardDimension);
            ChangeLayout(CurrentLayout);
        }

        public static void GetView(View selection) {
            Viewport = LoadViewport(selection);
        }

        public static Vector2 GetScale(View view, Texture2D picture) => CurrentLayout switch {
            ViewportLayout.Nintendo => GetControllerScale(view, picture),
            _ => GetRegularScale(view, picture)
        };

        private static void ChangeDimension((int width, int height) dimension) {
            //BewareGame.Instance._graphics.PreferredBackBufferWidth = BewareGame.Instance.GraphicsDevice.DisplayMode.Width;
            //BewareGame.Instance._graphics.PreferredBackBufferHeight = BewareGame.Instance.GraphicsDevice.DisplayMode.Height;
            BewareGame.Instance._graphics.PreferredBackBufferWidth = dimension.width;
            BewareGame.Instance._graphics.PreferredBackBufferHeight = dimension.height;
            BewareGame.Instance._graphics.GraphicsProfile = GraphicsProfile.Reach;
            BewareGame.Instance._graphics.IsFullScreen = false;
            BewareGame.Instance._graphics.ApplyChanges();
        }

        private static Vector2 GetRegularScale(View view, Texture2D picture) {
            Vector2 window = GetWindowSize(view);
            float width = (picture.Width >= window.X) ? window.X : picture.Width;
            float height = (picture.Height >= window.Y) ? window.Y : picture.Height;

            return MathUtil.ScaleVector(window.X, window.Y, width, height);
        }

        private static Vector2 GetControllerScale(View view, Texture2D picture) {
            Vector2 window = GetWindowSize(view);

            return MathUtil.ScaleVector(window.X, window.Y, picture.Width, picture.Height);
        }

        public static void ChangeLayout(ViewportLayout layout) {
            switch (layout) {
                case ViewportLayout.Nintendo:
                    CreateNintendoView();
                    break;
                case ViewportLayout.LeftPanel:
                    CreateLeftPanelView();
                    break;
                case ViewportLayout.RightPanel:
                    CreateRightPanelView();
                    break;
                case ViewportLayout.NoPanel:
                    CreateNoPanelView();
                    break;
            }
        }

        public static Vector2 GetWindowSize(View view) => view switch {
            View.InfoOne => new Vector2(InfoOneView.Width, InfoOneView.Height),
            View.InfoTwo => new Vector2(InfoTwoView.Width, InfoTwoView.Height),
            View.GamePlay => new Vector2(GameboardView.Width, GameboardView.Height),
            View.Ticker => new Vector2(TickerView.Width, TickerView.Height),
            _ => new Vector2(MenuView.Width, MenuView.Height)
        };

        private static Viewport LoadViewport(View selection) => selection switch {
            View.GamePlay => GameboardView,
            View.Menu => MenuView,
            View.Ticker => TickerView,
            View.HUD => InfoOneView,
            View.InfoOne => InfoOneView,
            View.InfoTwo => InfoTwoView,
            _ => Viewport
        };

        private static void CreateNintendoView() {
            MenuView = Viewport;
            CurrentLayout = ViewportLayout.Nintendo;

            int tempX = (standardDimension.width - nintendoDimension.width) / 2;
            int tempY = (standardDimension.height - nintendoDimension.height) / 2;

            InfoOneView = new Viewport {
                X = tempX,
                Y = tempY,
                Width = 315,
                Height = 885
            };

            GameboardView = new Viewport {
                X = InfoOneView.X + InfoOneView.Width,
                Y = InfoOneView.Y,
                Width = 1440,
                Height = InfoOneView.Height - 100
            };

            TickerView = new Viewport {
                X = GameboardView.X,
                Y = GameboardView.Y + GameboardView.Height,
                Width = GameboardView.Width,
                Height = 100
            };

            InfoTwoView = new Viewport {
                X = GameboardView.X + GameboardView.Width,
                Y = GameboardView.Y,
                Width = InfoOneView.Width,
                Height = InfoOneView.Height
            };
        }

        private static void CreateLeftPanelView() {
            MenuView = Viewport;
            CurrentLayout = ViewportLayout.LeftPanel;

            InfoOneView = new Viewport {
                X = 0,
                Y = 0,
                Width = (Viewport.Width / 4),
                Height = Viewport.Height - 100
            };

            GameboardView = new Viewport {
                X = InfoOneView.Width,
                Y = 0,
                Width = Viewport.Width - (Viewport.Width / 4),
                Height = Viewport.Height - 100
            };

            TickerView = new Viewport {
                X = 0,
                Y = GameboardView.Height,
                Width = Viewport.Width,
                Height = 100
            };
        }

        private static void CreateRightPanelView() {
            MenuView = Viewport;
            CurrentLayout = ViewportLayout.RightPanel;

            GameboardView = new Viewport {
                X = 0,
                Y = 0,
                Width = (Viewport.Width * 3 / 4),
                Height = Viewport.Height - 100
            };

            InfoOneView = new Viewport {
                X = GameboardView.Width,
                Y = 0,
                Width = Viewport.Width - GameboardView.Width,
                Height = Viewport.Height - 100
            };

            TickerView = new Viewport {
                X = 0,
                Y = GameboardView.Height,
                Width = Viewport.Width,
                Height = 100
            };
        }

        private static void CreateNoPanelView() {
            MenuView = Viewport;
            CurrentLayout = ViewportLayout.NoPanel;

            InfoOneView = new Viewport {
                X = 0,
                Y = 0,
                Width = Viewport.Width,
                Height = Viewport.Height
            };

            GameboardView = new Viewport {
                X = InfoOneView.X + 100,
                Y = InfoOneView.Y + 100,
                Width = InfoOneView.Width - 200,
                Height = InfoOneView.Height - 200
            };
        }
    }
}
