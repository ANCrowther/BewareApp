using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.GameScenes {
    public class RightPanelLogic : DrawableGameComponent {
        private View view;
        private Vector2 centerCardinalPosition;

        public RightPanelLogic(BewareGame game, View view) : base (game) {
            this.view = view;
            centerCardinalPosition = new Vector2(ViewportManager.InfoRightView.Width / 2, ViewportManager.InfoRightView.Height / 4);
        }

        public override void Update(GameTime gameTime) {
            TimeKeeper.Instance.Update();
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();

            ViewportManager.GetView(view);

            CardinalMapManager.Instance.Draw(Helpers.GetPicture(Mode.Shoot), centerCardinalPosition, Helpers.GetDirection(Mode.Shoot));

            TimeKeeper.Instance.Draw(new Vector2((ViewportManager.InfoRightView.Width / 2) + 100, ViewportManager.InfoRightView.Height - 100));

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
