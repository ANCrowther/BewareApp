using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.GameScenes {
    public class LeftPanelLogic : DrawableGameComponent {
        private BewareGame game;
        private View view;
        private Vector2 centerCardinalPosition;

        public LeftPanelLogic(BewareGame inputGame, View inputView) : base(inputGame) {
            game = inputGame;
            view = inputView;
            centerCardinalPosition = new Vector2(ViewportManager.InfoLeftView.Width / 2, ViewportManager.InfoLeftView.Height / 4);
        }

        public override void Draw(GameTime gameTime) {
            game._spriteBatch.Begin();

            ViewportManager.GetView(view);

            if (ViewportManager.CurrentLayout == ViewportLayout.Layout2) {
                CardinalMapManager.Instance.Draw(Helpers.GetPicture(Mode.Move), centerCardinalPosition, Helpers.GetDirection(Mode.Move));
            }

            game._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
