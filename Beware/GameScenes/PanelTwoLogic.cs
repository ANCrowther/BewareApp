using Beware.Enums;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.GameScenes {
    public class PanelTwoLogic : DrawableGameComponent {
        private Vector2 centerThumbStickPositionLeft;
        private Vector2 centerThumbStickPositionRight;
        private Vector2 centerButtonPosition;

        public PanelTwoLogic() : base (BewareGame.Instance) {

            if(ViewportManager.CurrentLayout == ViewportLayout.Unbalanced) {
                centerThumbStickPositionLeft = new Vector2(ViewportManager.InfoTwoView.Width / 6, ViewportManager.InfoTwoView.Height / 2);
                centerThumbStickPositionRight = new Vector2(ViewportManager.InfoTwoView.Width * 5 / 6, ViewportManager.InfoTwoView.Height / 2);
            }
            if (ViewportManager.CurrentLayout == ViewportLayout.Parallel) {
                centerThumbStickPositionRight = new Vector2(ViewportManager.InfoTwoView.Width / 2, ViewportManager.InfoTwoView.Height / 4);
                centerButtonPosition = new Vector2(centerThumbStickPositionRight.X, centerThumbStickPositionRight.Y + 250);

            }
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

            if(ViewportManager.CurrentLayout == ViewportLayout.Unbalanced) {
                CardinalMapManager.Draw(Art.BlueStarBurst, centerThumbStickPositionLeft, Helpers.GetDirection(Mode.Move));
                CardinalMapManager.Draw(Art.RedStarBurst, centerThumbStickPositionRight, Helpers.GetDirection(Mode.Shoot));
                TimeKeeper.Draw(new Vector2(ViewportManager.InfoTwoView.Width - 50, ViewportManager.InfoTwoView.Height - 50));
            }

            if (ViewportManager.CurrentLayout == ViewportLayout.Parallel) {
                //CardinalMapManager.Draw(Art.RedStarBurst, centerThumbStickPositionRight, Helpers.GetDirection(Mode.Shoot));
                ControllerManager.Draw(centerThumbStickPositionRight, centerButtonPosition, Helpers.GetDirection(Mode.Shoot), Mode.Shoot);
                TimeKeeper.Draw(new Vector2((ViewportManager.InfoTwoView.Width / 2) + 100, ViewportManager.InfoTwoView.Height - 100));
            }

            if (ViewportManager.CurrentLayout == ViewportLayout.Nintendo) {
                ControllerManager.Draw(centerThumbStickPositionRight, centerButtonPosition, Helpers.GetDirection(Mode.Shoot), Mode.Shoot);
            }

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
