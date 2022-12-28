using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*      |---|--- --- --- ---|   |---|--- --- ---|---|                           |--- --- --- -|- ---|   |--- -|- --- --- ---|
 *      |   |               |   |   |           |   |                           |             |     |   |     |             |
 *      |   |       M       |   |   |     M     |   |                           |             |     |   |     |             |
 *      |   |               |   |   |           |   |   |---|--- --- ---|---|   |       M     |  1  |   |  1  |     M       |
 *      | 1 |--- --- --- ---|   | 1 |           | 2 |   |   |           |   |   |             |     |   |     |             |
 *      |   |--- --- --- ---|   |   |           |   |   | 1 |     M     | 2 |   |             |     |   |     |             |
 *      |   |       2       |   |   |--- --- ---|   |   |   |--- --- ---|   |   |--- --- --- -|- ---|   |--- -|- --- -|- ---|
 *      |---|--- --- --- ---|   |---|--- --- ---|---|   |---|--- --- ---|---|   |--- --- --- -|- ---|   |--- -|- --- --- ---|   
 *          Unbalanced              Parallel                Nintendo                SinglePanelRight        SinglePanelLeft
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
        public static ViewportLayout CurrentLayout { get; private set; } = ViewportLayout.Unbalanced;
        private static Viewport viewport {
            get { return BewareGame.Instance.GraphicsDevice.Viewport; }
            set { BewareGame.Instance.GraphicsDevice.Viewport = value; }
        }

        private static (int width, int height) nintendoDimension = (2200, 1200);
        private static (int width, int height) standardDimension = (2880, 1620);

        public static void Initialize(GraphicsDeviceManager graphics) {
            ChangeDimension(standardDimension);
            ChangeLayout(CurrentLayout);
        }

        public static void GetView(View selection) {
            viewport = LoadViewport(selection);
        }

        public static Vector2 GetScale(View view, Texture2D picture) {
            switch (CurrentLayout) {
                case ViewportLayout.Nintendo: return GetControllerScale(view, picture);
                default:                     return GetRegularScale(view, picture);
            }
        }

        public static void ChangeDimension(Dimension dimension) {
            switch (dimension) {
                case Dimension.Nintendo:
                    ChangeDimension(nintendoDimension);
                    break;
                case Dimension.Standard:
                    ChangeDimension(standardDimension);
                    break;
            }
        }

        private static void ChangeDimension((int width, int height) dimension) {
            BewareGame.Instance._graphics.PreferredBackBufferWidth = BewareGame.Instance.GraphicsDevice.DisplayMode.Width;
            BewareGame.Instance._graphics.PreferredBackBufferHeight = BewareGame.Instance.GraphicsDevice.DisplayMode.Height;
            //BewareGame.Instance._graphics.PreferredBackBufferWidth = dimension.width;
            //BewareGame.Instance._graphics.PreferredBackBufferHeight = dimension.height;
            BewareGame.Instance._graphics.GraphicsProfile = GraphicsProfile.Reach;
            BewareGame.Instance._graphics.IsFullScreen = true;
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
                case ViewportLayout.Unbalanced:
                    CreateUnbalancedView();
                    break;
                case ViewportLayout.Parallel:
                    CreateParallelView();
                    break;
                case ViewportLayout.Nintendo:
                    CreateNintendoView();
                    break;
                case ViewportLayout.SinglePanelLeft:
                    CreateSinglePanelLeftView();
                    break;
            }
        }

        public static Vector2 GetWindowSize(View view) {
            switch (view) {
                case View.InfoOne:  return new Vector2(InfoOneView.Width, InfoOneView.Height);
                case View.InfoTwo:  return new Vector2(InfoTwoView.Width, InfoTwoView.Height);
                case View.GamePlay: return new Vector2(GameboardView.Width, GameboardView.Height);
                case View.Ticker:   return new Vector2(TickerView.Width, TickerView.Height);
                default:            return new Vector2(MenuView.Width, MenuView.Height);
            }
        }

        private static Viewport LoadViewport(View selection) {
            switch (selection) {
                case View.GamePlay: return GameboardView;
                case View.Menu:     return MenuView;
                case View.Ticker:   return TickerView;
                case View.InfoOne:  return InfoOneView;
                case View.InfoTwo:  return InfoTwoView;
                default:            return viewport;
            }
        }

        private static void CreateUnbalancedView() {
            MenuView = viewport;
            CurrentLayout = ViewportLayout.Unbalanced;

            GameboardView = new Viewport {
                X = viewport.Width / 6,
                Y = 0,
                Width = viewport.Width - (viewport.Width / 6),
                Height = viewport.Height - 100 - (viewport.Height / 6)
            };

            InfoOneView = new Viewport {
                X = 0,
                Y = 0,
                Width = GameboardView.X,
                Height = viewport.Height
            };

            TickerView = new Viewport {
                X = viewport.Width / 6,
                Y = GameboardView.Height,
                Width = GameboardView.Width,
                Height = viewport.Height - (viewport.Height - 100)
            };

            InfoTwoView = new Viewport {
                X = viewport.Width / 6,
                Y = GameboardView.Height + TickerView.Height,
                Width = GameboardView.Width,
                Height = viewport.Height - GameboardView.Height - TickerView.Height
            };
        }

        private static void CreateParallelView() {
            MenuView = viewport;
            CurrentLayout = ViewportLayout.Parallel;

            GameboardView = new Viewport {
                X = viewport.Width / 6,
                Y = 0,
                Width = viewport.Width - (viewport.Width / 3),
                Height = viewport.Height - 100
            };

            TickerView = new Viewport {
                X = GameboardView.X,
                Y = GameboardView.Height,
                Width = GameboardView.Width,
                Height = GameboardView.Height
            };

            InfoOneView = new Viewport {
                X = 0,
                Y = 0,
                Width = GameboardView.X,
                Height = viewport.Height
            };

            InfoTwoView = new Viewport {
                X = viewport.Width - GameboardView.X,
                Y = 0,
                Width = GameboardView.X,
                Height = viewport.Height
            };
        }

        private static void CreateNintendoView() {
            MenuView = viewport;
            CurrentLayout = ViewportLayout.Nintendo;

            GameboardView = new Viewport {
                X = 366,
                Y = 100,
                Width = 1440,
                Height = 785
            };

            InfoOneView = new Viewport {
                X = 50,
                Y = GameboardView.Y,
                Width = 315,
                Height = 885
            };

            InfoTwoView = new Viewport {
                X = 1805,
                Y = GameboardView.Y,
                Width = 315,
                Height = 885
            };

            TickerView = new Viewport {
                X = GameboardView.X,
                Y = 885,
                Width = GameboardView.Width,
                Height = 100
            };
        }

        private static void CreateSinglePanelLeftView() {
            MenuView = viewport;
            CurrentLayout = ViewportLayout.SinglePanelLeft;

            GameboardView = new Viewport {
                X = viewport.Width / 5,
                Y = 0,
                Width = viewport.Width - (viewport.Width / 3),
                Height = viewport.Height - 100
            };

            TickerView = new Viewport {
                X = GameboardView.X,
                Y = GameboardView.Height,
                Width = GameboardView.Width,
                Height = GameboardView.Height
            };

            InfoOneView = new Viewport {
                X = 0,
                Y = 0,
                Width = GameboardView.X,
                Height = viewport.Height
            };
        }
    }
}
