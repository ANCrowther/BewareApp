using Beware.Entities;
using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.GameScenes {
    public class GameboardLogic : DrawableGameComponent {
        private Vector2 centerThumbStickPosition;
        private Vector2 centerButtonPosition;

        public GameboardLogic() : base (BewareGame.Instance) {
            EntityManager.Clear();
            ScoreKeeper.Reset();
            PlayerModel.Instance.ResetPlayer();
            EntityManager.Add(PlayerModel.Instance);
            EntityManager.Add(PlayerGunModel.Instance);


            centerThumbStickPosition = new Vector2(ViewportManager.InfoOneView.Width / 2, ViewportManager.InfoOneView.Height / 4);
            centerButtonPosition = new Vector2(centerThumbStickPosition.X, centerThumbStickPosition.Y + 250);
        }

        public override void Update(GameTime gameTime) {
            if (Input.WasButtonPressed(ControlMap.Back)) {
                SceneManager.SwitchScene(SceneManager.MenuWindow);
            }

            if (Input.WasButtonPressed(ControlMap.Pause)) {
                PlayerInputStates.IsPaused = !PlayerInputStates.IsPaused;
            }

            if (PlayerInputStates.IsPaused == false) {
                EntityManager.Update();
                EnemySpawner.Update();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();

            EntityManager.Draw();
            
            if (ViewportManager.CurrentLayout == ViewportLayout.Nintendo) {
                ScoreKeeper.DrawScoreForNintendo();
            }

            BewareGame.Instance._spriteBatch.End();

            BewareGame.Instance._spriteBatch.Begin(SpriteSortMode.Texture, BlendState.Additive);
            if (ViewportManager.CurrentLayout == ViewportLayout.Parallel) {
                //CardinalMapManager.Draw(Art.BlueStarBurst, centerThumbStickPosition, Helpers.GetDirection(Mode.Move));
                ControllerManager.Draw(centerThumbStickPosition, centerButtonPosition, Helpers.GetDirection(Mode.Move), Mode.Move);
            }

            if (ViewportManager.CurrentLayout == ViewportLayout.Nintendo) {
                ControllerManager.Draw(centerThumbStickPosition, centerButtonPosition, Helpers.GetDirection(Mode.Move), Mode.Move);
            }
            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
