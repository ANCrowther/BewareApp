using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.GameScenes {
    public class GameOverLogic : DrawableGameComponent {
        private Texture2D backgroundOpaqueScreen;

        public GameOverLogic() : base(BewareGame.Instance) {
            backgroundOpaqueScreen = new Texture2D(GraphicsDevice, 1000, 1000);
            backgroundOpaqueScreen.CreateTranslucentRectangle(Color.White);
        }

        public override void Update(GameTime gameTime) {
            if (Input.WasKeyPressed(ControlMap.Back) || Input.WasButtonPressed(ControlMap.Back_pad) || 
                Input.WasKeyPressed(ControlMap.Enter) || Input.WasButtonPressed(ControlMap.Enter_pad)) {
                ScoreKeeper.Reset();
                SceneManager.SwitchScene(SceneManager.MenuWindow);
            }


            // As GameSettingsLogic handles all the music volume, this line was added so the user can mute anytime they want.
            if (Input.WasKeyPressed(ControlMap.Mute) || Input.WasButtonPressed(ControlMap.Mute_pad)) {
                AudioManager.Update();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();

            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareLarge, "GAME OVER", new Vector2(ViewportManager.GameboardView.Width / 2 - Fonts.NovaSquareLarge.MeasureString("GAME OVER").X / 2, 50), Color.MediumVioletRed);

            BewareGame.Instance._spriteBatch.Draw(backgroundOpaqueScreen, new Vector2(ViewportManager.GameboardView.Width / 2, ViewportManager.GameboardView.Height / 2), null, Color.White, 0, new Vector2(backgroundOpaqueScreen.Width, backgroundOpaqueScreen.Height) / 2.0f, 0.2f, 0, 0.0f);

            ScoreKeeper.DrawGameOverScore(new Vector2(ViewportManager.GameboardView.Width / 6, ViewportManager.GameboardView.Height / 3));

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
