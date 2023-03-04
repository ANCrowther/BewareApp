using Beware.Enums;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.GameScenes {
    public class PanelTwoLogic : DrawableGameComponent {
        private Vector2 centerThumbStickPositionRight;
        private Vector2 centerButtonPosition;

        public PanelTwoLogic() : base (BewareGame.Instance) {
            if (ViewportManager.CurrentLayout == ViewportLayout.Nintendo) {
                centerThumbStickPositionRight = new Vector2(ViewportManager.InfoTwoView.Width / 2, ViewportManager.InfoTwoView.Height / 2 + 50);
                centerButtonPosition = new Vector2(centerThumbStickPositionRight.X, centerThumbStickPositionRight.Y - 250);
            }
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();

            if (ViewportManager.CurrentLayout == ViewportLayout.Nintendo) {
                ControllerManager.Draw(centerThumbStickPositionRight, centerButtonPosition, Helpers.GetDirection(Mode.Shoot), Mode.Shoot);
            }

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
