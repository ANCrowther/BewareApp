using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.GameScenes {
    public class PanelOneLogic : DrawableGameComponent {
        private Vector2 centerThumbStickPosition;
        private Vector2 centerButtonPosition;

        public PanelOneLogic() : base(BewareGame.Instance) {
            centerThumbStickPosition = new Vector2(ViewportManager.InfoOneView.Width / 2, ViewportManager.InfoOneView.Height / 4);
            centerButtonPosition = new Vector2(centerThumbStickPosition.X, centerThumbStickPosition.Y + 250);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();
            
            if (ViewportManager.CurrentLayout == ViewportLayout.Layout2) {
                //CardinalMapManager.Draw(Art.BlueStarBurst, centerThumbStickPosition, Helpers.GetDirection(Mode.Move));
                ControllerManager.Draw(centerThumbStickPosition, centerButtonPosition, Helpers.GetDirection(Mode.Move), Mode.Move);
            }

            if (ViewportManager.CurrentLayout == ViewportLayout.Layout3) {
                ControllerManager.Draw(centerThumbStickPosition, centerButtonPosition, Helpers.GetDirection(Mode.Move), Mode.Move);
            }

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
