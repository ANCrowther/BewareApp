using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.GameScenes {
    public class PanelTwoLogic : DrawableGameComponent {
        private Vector2 centerCardinalPositionLeft;
        private Vector2 centerCardinalPositionRight;

        public PanelTwoLogic() : base (BewareGame.Instance) {

            if(ViewportManager.CurrentLayout == ViewportLayout.Layout1) {
                centerCardinalPositionLeft = new Vector2(ViewportManager.InfoTwoView.Width / 6, ViewportManager.InfoTwoView.Height / 2);
                centerCardinalPositionRight = new Vector2(ViewportManager.InfoTwoView.Width * 5 / 6, ViewportManager.InfoTwoView.Height / 2);
            }
            if (ViewportManager.CurrentLayout == ViewportLayout.Layout2) {
                centerCardinalPositionRight = new Vector2(ViewportManager.InfoTwoView.Width / 2, ViewportManager.InfoTwoView.Height / 4);
            }
            if (ViewportManager.CurrentLayout == ViewportLayout.Layout3) {
                centerCardinalPositionRight = new Vector2(ViewportManager.InfoTwoView.Width / 2, ViewportManager.InfoTwoView.Height / 2 + 50);
            }
        }

        public override void Update(GameTime gameTime) {
            TimeKeeper.Update();
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();

            if(ViewportManager.CurrentLayout == ViewportLayout.Layout1) {
                CardinalMapManager.Draw(Art.BlueStarBurst, centerCardinalPositionLeft, Helpers.GetDirection(Mode.Move));
                CardinalMapManager.Draw(Art.RedStarBurst, centerCardinalPositionRight, Helpers.GetDirection(Mode.Shoot));
                TimeKeeper.Draw(new Vector2(ViewportManager.InfoTwoView.Width - 50, ViewportManager.InfoTwoView.Height - 50));
            }

            if (ViewportManager.CurrentLayout == ViewportLayout.Layout2) {
                CardinalMapManager.Draw(Art.RedStarBurst, centerCardinalPositionRight, Helpers.GetDirection(Mode.Shoot));
                TimeKeeper.Draw(new Vector2((ViewportManager.InfoTwoView.Width / 2) + 100, ViewportManager.InfoTwoView.Height - 100));
            }

            if (ViewportManager.CurrentLayout == ViewportLayout.Layout3) {
                ControllerManager.Draw(centerCardinalPositionRight, Helpers.GetDirection(Mode.Shoot), Mode.Shoot);
            }


            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
