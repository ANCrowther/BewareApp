using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.GameScenes {
    public class PanelOneLogic : DrawableGameComponent {
        private Vector2 centerCardinalPosition;

        public PanelOneLogic() : base(BewareGame.Instance) {
            centerCardinalPosition = new Vector2(ViewportManager.InfoOneView.Width / 2, ViewportManager.InfoOneView.Height / 4);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();
            
            if (ViewportManager.CurrentLayout == ViewportLayout.Layout2) {
                CardinalMapManager.Draw(Art.BlueStarBurst, centerCardinalPosition, Helpers.GetDirection(Mode.Move));
            }

            if (ViewportManager.CurrentLayout == ViewportLayout.Layout3) {
                CardinalMapManager.Draw(Art.BlueStarBurst, centerCardinalPosition, Helpers.GetDirection(Mode.Move));
            }

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
