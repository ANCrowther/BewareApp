using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware {
    public class BewareGame : Game {
        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        public static BewareGame Instance { get; private set; }
        public static GameTime GameTime { get; private set; }

        public BewareGame() {
            Instance = this;

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            Art.Initialize(Content);
            EntityArt.Initialize(Content);
            Fonts.Initialize(Content);
            ScenesArt.Initialize(Content);
            ControllerArt.Initialize(Content);
            ScoreKeeper.Initialize();
            TimeKeeper.Initialize();
            CardinalMapManager.Initialize();
            ControllerManager.Initialize();
            ViewportManager.Initialize();

            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            SceneManager.SwitchScene(SceneManager.MenuWindow);
        }

        protected override void Update(GameTime gameTime) {
            // Game scenes handles all the updates
            GameTime = gameTime;
            Input.Update();
            AudioManager.Update();
            TimeKeeper.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);
            // SceneManager handles all the game Draws.
            base.Draw(gameTime);
        }
    }
}
