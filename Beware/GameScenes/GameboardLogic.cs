using Beware.Entities;
using Beware.Inputs;
using Beware.Managers;
using Microsoft.Xna.Framework;

namespace Beware.GameScenes {
    public class GameboardLogic : DrawableGameComponent {
        
        public GameboardLogic() : base (BewareGame.Instance) {
            EntityManager.Add(PlayerModel.Instance);
        }

        public override void Update(GameTime gameTime) {
            if (Input.WasKeyPressed(ControlMap.Back) || Input.WasButtonPressed(ControlMap.Back_pad)) {
                SceneManager.SwitchScene(SceneManager.MenuWindow);
            }

            EntityManager.Update();
            EnemySpawner.Update();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();

            EntityManager.Draw();
            
            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
