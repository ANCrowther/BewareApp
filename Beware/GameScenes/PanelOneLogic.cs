using Beware.Entities;
using Beware.EntityFeatures;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.GameScenes {
    public class PanelOneLogic : DrawableGameComponent {
        private Vector2 centerThumbStickPosition;
        private Vector2 centerButtonPosition;
        private readonly Sprite shieldSprite;
        private readonly Sprite gunSprite;
        private readonly Sprite redBooster;
        private readonly Sprite blueBooster;

        private Texture2D frame;

        public PanelOneLogic() : base(BewareGame.Instance) {
            centerThumbStickPosition = new Vector2(ViewportManager.InfoOneView.Width / 2, ViewportManager.InfoOneView.Height / 4);
            centerButtonPosition = new Vector2(centerThumbStickPosition.X, centerThumbStickPosition.Y + 250);

            if (ViewportManager.CurrentLayout == ViewportLayout.NoPanel) {
                shieldSprite = new Sprite(EntityArt.Shield);
                gunSprite = new Sprite(EntityArt.MainGun);
                redBooster = new Sprite(EntityArt.RedBooster);
                blueBooster = new Sprite(EntityArt.BlueBooster);
                ResetFrameBorder();
            }
        }

        private void ResetFrameBorder() {
            frame = new Texture2D(GraphicsDevice, (int)ViewportManager.GetWindowSize(View.InfoOne).X, (int)ViewportManager.GetWindowSize(View.InfoOne).Y);
            frame.CreateTranslucentBorder(100, Color.DarkSlateBlue);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();
            ViewportManager.GetView(View.InfoOne);
            if (ViewportManager.CurrentLayout == ViewportLayout.Parallel) {
                ControllerManager.Draw(centerThumbStickPosition, centerButtonPosition, Helpers.GetDirection(Mode.Move), Mode.Move);
            }
            if (ViewportManager.CurrentLayout == ViewportLayout.Nintendo) {
                ControllerManager.Draw(centerThumbStickPosition, centerButtonPosition, Helpers.GetDirection(Mode.Move), Mode.Move);
            }
            if (ViewportManager.CurrentLayout == ViewportLayout.NoPanel) {
                DrawHUD();
            }

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }

        private void DrawHUD() {
            BewareGame.Instance._spriteBatch.End();
            BewareGame.Instance._spriteBatch.Begin(SpriteSortMode.Texture, BlendState.Additive);
            BewareGame.Instance._spriteBatch.Draw(frame, new Vector2(0, 0), Color.White);
            BewareGame.Instance._spriteBatch.End();
            BewareGame.Instance._spriteBatch.Begin();

            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, $"{ScoreKeeper.Score:000000}", new Vector2(25, 25), Color.DarkViolet);
            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, $"Enemy Count: {ScoreKeeper.EnemyCount}", new Vector2(ViewportManager.GetWindowSize(View.InfoOne).X / 2, 25), Color.DeepPink);
            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, $"Round: {ScoreKeeper.EnemyCount}", new Vector2(ViewportManager.GetWindowSize(View.InfoOne).X - 200, 25), Color.Maroon);

            (float gun, float shield) scale = (PlayerStatus.IsSpecialDefensive == true) ? (2.5f, 0.25f) : (3.5f, 0.15f);
            gunSprite?.Draw(new Vector2(200, ViewportManager.GetWindowSize(View.InfoOne).Y - 80), scale.gun, -135.0f);
            shieldSprite?.Draw(new Vector2(100, ViewportManager.GetWindowSize(View.InfoOne).Y - 80),scale.shield, -135.0f);

            DrawBooster(new Vector2(300, ViewportManager.GetWindowSize(View.InfoOne).Y - 80), 2.0f);
            DrawShieldCooldown();
            DrawSpecialGunRoundCount();

            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, $"Round: {ScoreKeeper.EnemyCount}", new Vector2(ViewportManager.GetWindowSize(View.InfoOne).X - 200, ViewportManager.GetWindowSize(View.InfoOne).Y - 50), Color.Cyan);
        }

        private void DrawSpecialGunRoundCount() {
            if (PlayerStatus.IsSpecialDefensive == false) {
                Vector2 position = new Vector2(175, ViewportManager.GetWindowSize(View.InfoOne).Y - 100);
                BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, $"{PlayerStatus.SpecialAmmoCount:00}", position, Color.Cyan);
            }
        }

        private void DrawBooster(Vector2 position, float scale) {
            if (PlayerModel.Instance.Engine.IsBoosting == true) {
                redBooster?.Draw(position, scale, 0.0f);
            } else {
                blueBooster?.Draw(position, scale, 0.0f);
            }
            if (PlayerModel.Instance.BoostCountdown > 0) {
                BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, $"{PlayerModel.Instance.BoostCountdown:00}", new Vector2(position.X - 25, position.Y - 25), Color.Lime);
            }
        }

        private void DrawShieldCooldown() {
            shieldSprite.color = Color.LightCyan;
            if (PlayerModel.Instance.ShieldCountdown > 0) {
                Vector2 position = new Vector2(75, ViewportManager.GetWindowSize(View.InfoOne).Y - 100);
                BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, $"{PlayerModel.Instance.ShieldCountdown:00}", position, Color.Orange);
                shieldSprite.color = Color.OrangeRed;
            }
        }
    }
}
