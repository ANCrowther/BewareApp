using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.GameScenes {
    public class GameOverLogic : DrawableGameComponent {
        public GameOverLogic() : base(BewareGame.Instance) {
        }

        public override void Update(GameTime gameTime) {
            if (Input.WasButtonPressed(ControlMap.Back) || Input.WasButtonPressed(ControlMap.Enter)) {
                ScoreKeeper.Reset();
                SceneManager.SwitchScene(SceneManager.MenuWindow);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();

            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareLarge, "GAME OVER", new Vector2(ViewportManager.GameboardView.Width / 2 - Fonts.NovaSquareLarge.MeasureString("GAME OVER").X / 2, 50), Color.MediumVioletRed);
            ScoreKeeper.DrawGameOverScore(new Vector2(ViewportManager.GameboardView.Width / 6, ViewportManager.GameboardView.Height / 3));

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
