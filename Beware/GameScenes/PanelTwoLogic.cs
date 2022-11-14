using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.GameScenes {
    public class PanelTwoLogic : DrawableGameComponent {
        private View view;
        private Vector2 centerCardinalPosition;

        public PanelTwoLogic(BewareGame game, View view) : base (game) {
            this.view = view;

            //TODO: consider any logic for different layouts
            centerCardinalPosition = new Vector2(ViewportManager.InfoTwoView.Width / 2, ViewportManager.InfoTwoView.Height / 4);
        }

        public override void Update(GameTime gameTime) {
            TimeKeeper.Instance.Update();
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();

            ViewportManager.GetView(view);

            CardinalMapManager.Instance.Draw(Helpers.GetPicture(Mode.Shoot), centerCardinalPosition, Helpers.GetDirection(Mode.Shoot));

            TimeKeeper.Instance.Draw(new Vector2((ViewportManager.InfoTwoView.Width / 2) + 100, ViewportManager.InfoTwoView.Height - 100));

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
