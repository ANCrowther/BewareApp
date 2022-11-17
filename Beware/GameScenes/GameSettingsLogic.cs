using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Beware.GameScenes {
    class GameSettingsLogic: DrawableGameComponent {
        private List<(string heading, GameSettings name)> settingList;
        private (string heading, GameSettings name) activeSetting;
        private List<(Texture2D image, ViewportLayout name)> layoutList;
        private (Texture2D image, ViewportLayout name) activeLayout;
        private Texture2D activeLayoutFrame;
        private bool isActive = false;

        public GameSettingsLogic() : base(BewareGame.Instance) {
            settingList = new List<(string heading, GameSettings name)> {
                ("Layout", GameSettings.Layout),
                ("Master Volume", GameSettings.MasterVolume),
                ("Music Volume", GameSettings.MusicVolume),
                ("SFX Volume", GameSettings.SFXVolume)
            };
            activeSetting = ("Layout", GameSettings.Layout);

            layoutList = new List<(Texture2D image, ViewportLayout name)> {
                (Art.Layout1, ViewportLayout.Layout1),
                (Art.Layout2, ViewportLayout.Layout2),
                (Art.Layout3, ViewportLayout.Layout3)
            };
            activeLayout = (Art.Layout1, ViewportLayout.Layout1);
            ResetActiveLayoutFrameBorder();
        }

        public override void Update(GameTime gameTime) {
            if (Input.WasKeyPressed(ControlMap.Back) || Input.WasButtonPressed(ControlMap.Back_pad)) {
                BewareGame.Instance.Scene.SwitchScene(SceneManager.MenuWindow);
            }

            if (Input.WasKeyPressed(ControlMap.Enter) || Input.WasButtonPressed(ControlMap.Enter_pad)) {
                isActive = !isActive;
            }

            if (isActive == false) {
                activeSetting = Helpers.MoveThroughMenu(settingList, activeSetting);
            }

            if (isActive == true) {
                UpdateActiveSetting(activeSetting.name);
            }
            
            base.Update(gameTime);
        }

        private void UpdateActiveSetting(GameSettings setting) {
            switch (setting) {
                case GameSettings.Layout:
                    activeLayout = Helpers.MoveThroughMenu(layoutList, activeLayout);
                    ViewportManager.ChangeLayout(activeLayout.name);
                    break;
                case GameSettings.MasterVolume:

                    break;
                case GameSettings.MusicVolume:

                    break;
                case GameSettings.SFXVolume:

                    break;
            }
        }

        private void ResetActiveLayoutFrameBorder() {
            activeLayoutFrame = new Texture2D(GraphicsDevice, activeLayout.image.Width, activeLayout.image.Height);
            activeLayoutFrame.CreateBorder(15, Color.DarkRed);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();
            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareLarge, "GAME SETTINGS", new Vector2(ViewportManager.MenuView.Width / 2 - Fonts.NovaSquareLarge.MeasureString("GAME SETTINGS").X / 2, 50), Color.BlueViolet);

            DrawSettingList(new Vector2(200, ViewportManager.MenuView.Height / 4));
            DrawGameLayoutView(new Vector2(ViewportManager.MenuView.Width * 2 / 3, ViewportManager.MenuView.Height / 4));

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }

        private void DrawSettingList(Vector2 position) {
            foreach ((string heading, GameSettings name) setting in settingList) {
                Color color = (activeSetting.name == setting.name) ? Color.Moccasin : Color.Lime;
                BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareMedium, setting.heading, position, color);
                position.Y += 100;
            }
        }

        private void DrawGameLayoutView(Vector2 position) {
            ResetActiveLayoutFrameBorder();
            foreach ((Texture2D picture, _) in layoutList) {
                BewareGame.Instance._spriteBatch.Draw(picture, position, null, Color.White, 0, new Vector2(picture.Width, picture.Height) / 2.0f, 0.3f, 0, 0.3f);
                if (picture == activeLayout.image) {
                    BewareGame.Instance._spriteBatch.Draw(activeLayoutFrame, position, null, Color.White, 0, new Vector2(picture.Width, picture.Height) / 2.0f, 0.3f, 0, 0.0f);
                }
                position.Y += 400;
            }
        }
    }
}
