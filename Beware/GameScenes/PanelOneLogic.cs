using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.GameScenes {
    public class PanelOneLogic : DrawableGameComponent {
        private View view;
        private Vector2 centerCardinalPosition;

        public PanelOneLogic(View inputView) : base(BewareGame.Instance) {
            view = inputView;
            centerCardinalPosition = new Vector2(ViewportManager.InfoOneView.Width / 2, ViewportManager.InfoOneView.Height / 4);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();
            ViewportManager.GetView(view);

            if (ViewportManager.CurrentLayout == ViewportLayout.Layout2) {
                CardinalMapManager.Instance.Draw(Helpers.GetPicture(Mode.Move), centerCardinalPosition, Helpers.GetDirection(Mode.Move));
            }

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
