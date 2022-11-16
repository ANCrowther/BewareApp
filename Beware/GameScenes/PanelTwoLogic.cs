using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.GameScenes {
    public class PanelTwoLogic : DrawableGameComponent {
        private View view;
        private Vector2 centerCardinalPositionLeft;
        private Vector2 centerCardinalPositionRight;

        public PanelTwoLogic(View view) : base (BewareGame.Instance) {
            this.view = view;

            if(ViewportManager.CurrentLayout == ViewportLayout.Layout1) {
                centerCardinalPositionLeft = new Vector2(ViewportManager.InfoTwoView.Width / 6, ViewportManager.InfoTwoView.Height / 2);
                centerCardinalPositionRight = new Vector2(ViewportManager.InfoTwoView.Width * 5 / 6, ViewportManager.InfoTwoView.Height / 2);
            }
            if (ViewportManager.CurrentLayout == ViewportLayout.Layout2) {
                centerCardinalPositionRight = new Vector2(ViewportManager.InfoTwoView.Width / 2, ViewportManager.InfoTwoView.Height / 4);
            }
        }

        public override void Update(GameTime gameTime) {
            TimeKeeper.Instance.Update();
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();

            ViewportManager.GetView(view);

            if(ViewportManager.CurrentLayout == ViewportLayout.Layout1) {
                CardinalMapManager.Instance.Draw(Helpers.GetPicture(Mode.Move), centerCardinalPositionLeft, Helpers.GetDirection(Mode.Move));
                CardinalMapManager.Instance.Draw(Helpers.GetPicture(Mode.Shoot), centerCardinalPositionRight, Helpers.GetDirection(Mode.Shoot));
                TimeKeeper.Instance.Draw(new Vector2(ViewportManager.InfoTwoView.Width - 50, ViewportManager.InfoTwoView.Height - 50));
            }

            if (ViewportManager.CurrentLayout == ViewportLayout.Layout2) {
                CardinalMapManager.Instance.Draw(Helpers.GetPicture(Mode.Shoot), centerCardinalPositionRight, Helpers.GetDirection(Mode.Shoot));
                TimeKeeper.Instance.Draw(new Vector2((ViewportManager.InfoTwoView.Width / 2) + 100, ViewportManager.InfoTwoView.Height - 100));
            }




            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
