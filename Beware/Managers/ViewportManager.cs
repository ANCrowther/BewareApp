using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
    static class ViewportManager {
        public static Viewport GameboardView { get; private set; }
        public static Viewport TickerView { get; private set; }
        public static Viewport InfoOneView { get; private set; }
        public static Viewport InfoTwoView { get; private set; }
        public static Viewport MenuView { get; private set; }
        public static ViewportLayout CurrentLayout { get; private set; } = ViewportLayout.Layout1;

        private static Viewport viewport {
            get { return BewareGame.Instance.GraphicsDevice.Viewport; }
            set { BewareGame.Instance.GraphicsDevice.Viewport = value; }
        }

        public static void Initialize(GraphicsDeviceManager graphics) {
            BewareGame.Instance._graphics.PreferredBackBufferWidth = BewareGame.Instance.GraphicsDevice.DisplayMode.Width;
            BewareGame.Instance._graphics.PreferredBackBufferHeight = BewareGame.Instance.GraphicsDevice.DisplayMode.Height;
            BewareGame.Instance._graphics.GraphicsProfile = GraphicsProfile.Reach;
            BewareGame.Instance._graphics.IsFullScreen = true;
            BewareGame.Instance._graphics.ApplyChanges();
            ChangeLayout(CurrentLayout);
        }

        public static void GetView(View selection) {
            viewport = LoadViewport(selection);
        }

        public static Vector2 GetScale(View view, Texture2D picture) {
            Vector2 window = GetWindowSize(view);
            float width = (picture.Width > window.X) ? window.X : picture.Width;
            float height = (picture.Height > window.Y) ? window.Y : picture.Height;

            return MathUtil.ScaleVector(window.X, window.Y, width, height);
        }

        public static void ChangeLayout(ViewportLayout layout) {
            switch (layout) {
                case ViewportLayout.Layout1:
                    CreateLayout1();
                    break;
                case ViewportLayout.Layout2:
                    CreateLayout2();
                    break;
                case ViewportLayout.Layout3:
                    CreateLayout3();
                    break;
            }
        }

        private static Vector2 GetWindowSize(View view) {
            switch (view) {
                case View.InfoOne:
                    return new Vector2(InfoOneView.Width, InfoOneView.Height);
                case View.InfoTwo:
                    return new Vector2(InfoTwoView.Width, InfoTwoView.Height);
                case View.GamePlay:
                    return new Vector2(GameboardView.Width, GameboardView.Height);
                case View.Ticker:
                    return new Vector2(TickerView.Width, TickerView.Height);
                default:
                    return new Vector2(MenuView.Width, MenuView.Height);
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

        private static void CreateLayout1() {
            MenuView = viewport;
            CurrentLayout = ViewportLayout.Layout1;

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

        private static void CreateLayout2() {
            MenuView = viewport;
            CurrentLayout = ViewportLayout.Layout2;

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

        private static void CreateLayout3() {
            MenuView = viewport;
            CurrentLayout = ViewportLayout.Layout3;

            GameboardView = new Viewport {
                X = viewport.Width / 6,
                Y = viewport.Height / 6,
                Width = viewport.Width - (viewport.Width / 3),
                Height = viewport.Height / 2
            };

            InfoOneView = new Viewport {
                X = 0,
                Y = GameboardView.Y,
                Width = GameboardView.X,
                Height = GameboardView.Height
            };

            InfoTwoView = new Viewport {
                X = viewport.Width - GameboardView.X,
                Y = GameboardView.Y,
                Width = GameboardView.X,
                Height = GameboardView.Height
            };
        }
    }
}
