using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.GameScenes {
    public class TickerLogic : DrawableGameComponent {
        private Texture2D frame;
        private int cooldownRemaining = 0;
        private const int cooldownFrames = 500;

        public TickerLogic() : base (BewareGame.Instance) {
            ScoreKeeper.NextRound += delegate { DisplayTimer(); };
        }

        public override void Initialize() {
            frame = new Texture2D(GraphicsDevice, ViewportManager.TickerView.Width, ViewportManager.TickerView.Height);
            frame.CreateBorder(5, Color.Purple);
            base.Initialize();
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin(SpriteSortMode.Texture, BlendState.Additive);
            BewareGame.Instance._spriteBatch.Draw(frame, new Vector2(0, 0), Color.White);
            BewareGame.Instance._spriteBatch.End();

            BewareGame.Instance._spriteBatch.Begin();
            ScoreKeeper.DrawScore(new Vector2(450, 50));
            DrawNintendoTicker(new Vector2(ViewportManager.TickerView.Width - 10, 25));

            //BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, $"{PlayerStatus.SpecialAmmoCount}", new Vector2(1000, 50), Color.Yellow);

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }

        private void DisplayTimer() {
            cooldownRemaining = cooldownFrames;
        }

        private void DrawNintendoTicker(Vector2 position) {
            if (cooldownRemaining-- >= 0) {
                position.X -= (cooldownFrames - cooldownRemaining);
                ScoreKeeper.DrawNintendo(position);
            }
        }
    }
}
