using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Beware.GameScenes {
    public class TickerLogic : DrawableGameComponent {
        private Texture2D frame;
        private BewareGame game;
        private View view;

        public TickerLogic(BewareGame game, View inputView) : base (game) {
            this.game = game;
            view = inputView;
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
            game._spriteBatch.Begin(SpriteSortMode.Texture, BlendState.Additive);
            ViewportManager.GetView(view);

            game._spriteBatch.Draw(frame, new Vector2(0, 0), Color.White);
            game._spriteBatch.End();

            game._spriteBatch.Begin();

            ScoreKeeper.Instance.DrawScore(new Vector2(500, 50));

            game._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
