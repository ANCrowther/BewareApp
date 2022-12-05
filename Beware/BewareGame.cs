using Beware.Behaviours;
using Beware.Entities;
using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
            // TODO: Add your initialization logic here
            Art.Initialize(Content);
            EntityArt.Initialize(Content);
            Fonts.Initialize(Content);
            Scenes.Initialize(Content);
            ControllerArt.Initialize(Content);
            KeysArt.Initialize(Content);
            ScoreKeeper.Initialize();
            TimeKeeper.Initialize();
            CardinalMapManager.Initialize();
            ControllerManager.Initialize();
            ViewportManager.Initialize(_graphics);
            InitializePlayerBehaviours();

            base.Initialize();
        }

        protected void InitializePlayerBehaviours() {
            PlayerModel.Instance.SetBehaviour(BehaviourCategory.Move, PlayerBehaviourBuilder.Factory(PlayerBehaviourType.PlayerAttack1));
            //PlayerModel.Instance.SetBehaviour(BehaviourCategory.Shoot, PlayerBehaviourBuilder.Factory(PlayerBehaviourType.PlayerMove1));
            PlayerModel.Instance.SetBehaviour(BehaviourCategory.Slow, PlayerBehaviourBuilder.Factory(PlayerBehaviourType.PlayerSlow1));
            PlayerModel.Instance.SetBehaviour(BehaviourCategory.Shoot, PlayerBehaviourBuilder.Factory(PlayerBehaviourType.PlayerAttack2));
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            SceneManager.SwitchScene(SceneManager.MenuWindow);
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // Game scenes handles all the updates
            GameTime = gameTime;
            Input.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);
            // SceneManager handles all the game Draws.
            base.Draw(gameTime);
        }
    }
}
