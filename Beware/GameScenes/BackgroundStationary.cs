using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.GameScenes {
    public class BackgroundStationary : DrawableGameComponent {
        public Texture2D image;
        private View view;
        private Vector2 windowSize;
        private Vector2 scale;

        public BackgroundStationary(Texture2D backgroundImage, View backgroundView) : base(BewareGame.Instance) {
            image = backgroundImage;
            view = backgroundView;
            windowSize = ViewportManager.GetWindowSize(backgroundView);

            float width = (image.Width > windowSize.X) ? windowSize.X : image.Width;
            float height = (image.Height > windowSize.Y) ? windowSize.Y : image.Height;

            scale = MathUtil.ScaleVector(windowSize.X, windowSize.Y, width, height);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();

            ViewportManager.GetView(view);

            BewareGame.Instance._spriteBatch.Draw(image, Vector2.Zero, image.Bounds, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.3f);
            BewareGame.Instance._spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
