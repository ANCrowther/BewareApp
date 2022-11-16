using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*      |---|--- --- --- ---|           |---|--- --- ---|---|
 *      |   |               |           |   |           |   |
 *      |   |       M       |           |   |     M     |   |
 *      |   |               |           |   |           |   |
 *      | 1 |--- --- --- ---|           | 1 |           | 2 |
 *      |   |--- --- --- ---|           |   |           |   |
 *      |   |       2       |           |   |--- --- ---|   |
 *      |---|--- --- --- ---|           |---|--- --- ---|---|
 *          CreateLayout1()                 CreateLayout2()
 */


namespace Beware.Managers {
    public static class ViewportManager {
        public static Viewport GameboardView { get; private set; }
        public static Viewport TickerView { get; private set; }
        public static Viewport InfoOneView { get; private set; }
        public static Viewport InfoTwoView { get; private set; }
        public static Viewport MenuView { get; private set; }
        public static ViewportLayout CurrentLayout { get; private set; } = ViewportLayout.Layout1;
        public static Vector2 VectorScale { get; private set; } = new Vector2(1600, 1200);
        private static Viewport viewport {
            get { return BewareGame.Instance.GraphicsDevice.Viewport; }
            set { BewareGame.Instance.GraphicsDevice.Viewport = value; }
        }

        public static void Initialize(GraphicsDeviceManager graphics) {
            ApplyWindowSizeSettings();
        }

        public static void GetView(View selection) {
            viewport = LoadViewport(selection);
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

        private static void ApplyWindowSizeSettings() {
            BewareGame.Instance._graphics.PreferredBackBufferWidth = BewareGame.Instance.GraphicsDevice.DisplayMode.Width;
            BewareGame.Instance._graphics.PreferredBackBufferHeight = BewareGame.Instance.GraphicsDevice.DisplayMode.Height;
            BewareGame.Instance._graphics.GraphicsProfile = GraphicsProfile.Reach;
            BewareGame.Instance._graphics.IsFullScreen = true;
            BewareGame.Instance._graphics.ApplyChanges();

            ChangeLayout(CurrentLayout);

            VectorScale = MathUtil.ScaleVector(viewport.Width, viewport.Height, 1600, 1200);
        }

        public static void ChangeLayout(ViewportLayout layout) {
            switch (layout) {
                case ViewportLayout.Layout1: 
                    CreateLayout1();
                    break;
                case ViewportLayout.Layout2:
                    CreateLayout2();
                    break;
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
    }
}
