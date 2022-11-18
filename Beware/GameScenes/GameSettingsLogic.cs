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
        private List<(string heading, VolumeType name)> volumeList;
        private (string heading, VolumeType name) activeVolume;
        private bool isActive = false;

        public GameSettingsLogic() : base(BewareGame.Instance) {
            settingList = new List<(string heading, GameSettings name)> {
                ("Layout", GameSettings.Layout),
                ("Volume Levels", GameSettings.Volume)
            };
            activeSetting = ("Layout", GameSettings.Layout);

            layoutList = new List<(Texture2D image, ViewportLayout name)> {
                (Art.Layout1, ViewportLayout.Layout1),
                (Art.Layout2, ViewportLayout.Layout2),
                (Art.Layout3, ViewportLayout.Layout3)
            };
            activeLayout = (Art.Layout1, ViewportLayout.Layout1);
            ResetActiveLayoutFrameBorder();

            volumeList = new List<(string heading, VolumeType name)> {
                ("Master volume  ", VolumeType.Master),
                ("Music volume   ", VolumeType.Music),
                ("SFX volume     ", VolumeType.SFX)
            };
            activeVolume = ("Master volume  ", VolumeType.Master);
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

            AudioManager.Update();

            base.Update(gameTime);
        }

        private void UpdateActiveSetting(GameSettings setting) {
            switch (setting) {
                case GameSettings.Layout:
                    activeLayout = Helpers.MoveThroughMenu(layoutList, activeLayout);
                    ViewportManager.ChangeLayout(activeLayout.name);
                    break;
                case GameSettings.Volume:
                    activeVolume = Helpers.MoveThroughMenu(volumeList, activeVolume);
                    AudioManager.Update(activeVolume.name);
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

            Vector2 volumePosition = new Vector2(200, ViewportManager.MenuView.Height * 3 / 4);
            DrawMasterVolumeLevel(volumePosition);
            volumePosition.Y += 100;
            DrawMusicVolumeLevel(volumePosition);
            volumePosition.Y += 100;
            DrawSFXVolumeLevel(volumePosition);

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }

        private void DrawMasterVolumeLevel(Vector2 position) {
            Color color = Color.Lime;
            if (activeSetting.name == GameSettings.Volume && isActive == true) {
                color = (activeVolume.name == VolumeType.Master) ? Color.Moccasin : Color.Lime;
            }

            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareMedium, "Master volume", position, color);
            position.X += Fonts.NovaSquareMedium.MeasureString("Master volume  ").X;
            position.Y += 50;


            for (int i = 1; i <= 20; i++) {
                Texture2D image = (AudioManager.MasterVolumeLevel >= i) ? Art.BlueSquare : Art.RedSquare;
                BewareGame.Instance._spriteBatch.Draw(image, position, null, Color.White, 0, new Vector2(image.Width, image.Height) / 2.0f, 0.5f, 0, 0.0f);
                position.X += 50;
            }
        }

        private void DrawMusicVolumeLevel(Vector2 position) {
            Color color = Color.Lime;
            if (activeSetting.name == GameSettings.Volume && isActive == true) {
                color = (activeVolume.name == VolumeType.Music) ? Color.Moccasin : Color.Lime;
            }

            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareMedium, "Music volume", position, color);
            position.X += Fonts.NovaSquareMedium.MeasureString("Music volume   ").X;
            position.Y += 50;

            for (int i = 1; i <= 20; i++) {
                Texture2D image = (AudioManager.MusicVolumeLevel >= i) ? Art.BlueSquare : Art.RedSquare;
                BewareGame.Instance._spriteBatch.Draw(image, position, null, Color.White, 0, new Vector2(image.Width, image.Height) / 2.0f, 0.5f, 0, 0.0f);
                position.X += 50;
            }
        }

        private void DrawSFXVolumeLevel(Vector2 position) {
            Color color = Color.Lime;
            if (activeSetting.name == GameSettings.Volume && isActive == true) {
                color = (activeVolume.name == VolumeType.SFX) ? Color.Moccasin : Color.Lime;
            }

            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareMedium, "SFX volume", position, color);
            position.X += Fonts.NovaSquareMedium.MeasureString("SFX volume      ").X;
            position.Y += 50;

            for (int i = 1; i <= 20; i++) {
                Texture2D image = (AudioManager.SFXVolumeLevel >= i) ? Art.BlueSquare : Art.RedSquare;
                BewareGame.Instance._spriteBatch.Draw(image, position, null, Color.White, 0, new Vector2(image.Width, image.Height) / 2.0f, 0.5f, 0, 0.0f);
                position.X += 50;
            }
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
