using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Beware.GameScenes {
    public class TickerLogic : DrawableGameComponent {
        private Texture2D frame;

        public TickerLogic() : base (BewareGame.Instance) {
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
            //BewareGame.Instance._spriteBatch.Begin(SpriteSortMode.Texture, BlendState.Additive);

            //BewareGame.Instance._spriteBatch.Draw(frame, new Vector2(0, 0), Color.White);
            //BewareGame.Instance._spriteBatch.End();

            BewareGame.Instance._spriteBatch.Begin();
            ScoreKeeper.DrawScore(new Vector2(500, 50));

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
