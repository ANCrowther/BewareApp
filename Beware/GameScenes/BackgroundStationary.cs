using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.GameScenes {
    public class BackgroundStationary : DrawableGameComponent {
        public Texture2D image;
        private View view;

        public BackgroundStationary(Texture2D backgroundImage, View backgroundView) : base(BewareGame.Instance) {
            image = backgroundImage;
            view = backgroundView;
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();
            
            ViewportManager.GetView(view);

            BewareGame.Instance._spriteBatch.Draw(image, Vector2.Zero, image.Bounds, Color.White, 0.0f, Vector2.Zero, ViewportManager.VectorScale, SpriteEffects.None, 0.3f);
            BewareGame.Instance._spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
