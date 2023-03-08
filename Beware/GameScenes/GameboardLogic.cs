using Beware.Entities;
using Beware.Enums;
using Beware.Inputs;
using Beware.Managers;
using Beware.Spawners;
using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.GameScenes {
    public class GameboardLogic : DrawableGameComponent {
        public GameboardLogic() : base (BewareGame.Instance) {
            EntityManager.Clear();
            ScoreKeeper.Reset();
            PlayerModel.Instance.ResetPlayer();
            EntityManager.Add(PlayerModel.Instance);}

        public override void Update(GameTime gameTime) {
            if (Input.WasButtonPressed(ControlMap.Back)) {
                SceneManager.SwitchScene(SceneManager.MenuWindow);
            }

            if (Input.WasButtonPressed(ControlMap.Pause)) {
                PlayerStatus.IsPaused = !PlayerStatus.IsPaused;
            }

            if (PlayerStatus.IsPaused == false) {
                EntityManager.Update();
                EnemySpawner.Update();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();
            
            ViewportManager.GetView(View.GamePlay);
            EntityManager.Draw();
            
            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
