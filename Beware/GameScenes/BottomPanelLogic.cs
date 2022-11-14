using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.GameScenes {
    class BottomPanelLogic : DrawableGameComponent {
        private View view;

        private Vector2 centerCardinalPositionLeft;
        private Vector2 centerCardinalPositionRight;

        public BottomPanelLogic(BewareGame game, View view) : base(game) {
            this.view = view;

            //TODO: combine this panel and panel one logic
            centerCardinalPositionLeft = new Vector2(ViewportManager.InfoBottomView.Width  / 6, ViewportManager.InfoBottomView.Height / 2);
            centerCardinalPositionRight = new Vector2(ViewportManager.InfoBottomView.Width * 5 / 6, ViewportManager.InfoBottomView.Height / 2);
        }

        public override void Update(GameTime gameTime) {
            TimeKeeper.Instance.Update();
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();

            ViewportManager.GetView(view);

            CardinalMapManager.Instance.Draw(Helpers.GetPicture(Mode.Move), centerCardinalPositionLeft, Helpers.GetDirection(Mode.Move));


            CardinalMapManager.Instance.Draw(Helpers.GetPicture(Mode.Shoot), centerCardinalPositionRight, Helpers.GetDirection(Mode.Shoot));

            TimeKeeper.Instance.Draw(new Vector2(ViewportManager.InfoBottomView.Width - 50, ViewportManager.InfoBottomView.Height - 50));

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
