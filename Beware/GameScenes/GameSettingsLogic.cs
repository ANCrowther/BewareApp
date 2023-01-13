﻿using Beware.ExtensionSupport;
using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Beware.GameScenes {
    class GameSettingsLogic: DrawableGameComponent {
        private readonly List<(string heading, GameSettings name)> settingList;
        private (string heading, GameSettings name) activeSetting;
        private readonly List<(Texture2D image, ViewportLayout name)> layoutList;
        private (Texture2D image, ViewportLayout name) activeLayout;
        private Texture2D activeLayoutFrame;
        private readonly List<(string heading, VolumeType name)> volumeList;
        private (string heading, VolumeType name) activeVolume;
        private bool isActive = false;

        public GameSettingsLogic() : base(BewareGame.Instance) {
            settingList = new List<(string heading, GameSettings name)> {
                ("Layout", GameSettings.Layout),
                ("Volume Levels", GameSettings.Volume)
            };
            activeSetting = ("Layout", GameSettings.Layout);

            layoutList = new List<(Texture2D image, ViewportLayout name)> {
                (Art.Layout1, ViewportLayout.Unbalanced),
                (Art.Layout2, ViewportLayout.Parallel),
                (Art.Layout3, ViewportLayout.Nintendo)
            };
            activeLayout = (Art.Layout1, ViewportLayout.Unbalanced);
            ResetActiveLayoutFrameBorder();

            volumeList = new List<(string heading, VolumeType name)> {
                ("Master volume  ", VolumeType.Master),
                ("Music volume   ", VolumeType.Music),
                ("SFX volume     ", VolumeType.SFX)
            };
            activeVolume = ("Master volume  ", VolumeType.Master);
        }

        public override void Update(GameTime gameTime) {
            GetCurrentLayout();

            if (Input.WasButtonPressed(ControlMap.Back)) {
                SceneManager.SwitchScene(SceneManager.MenuWindow);
            }

            if (Input.WasButtonPressed(ControlMap.Enter) || Input.WasButtonPressed(Buttons.A)) {
                isActive = !isActive;
            }

            if (isActive == false) {
                activeSetting = settingList.MoveThroughMenu(activeSetting);
            }

            if (isActive == true) {
                UpdateActiveSetting(activeSetting.name);
            }

            base.Update(gameTime);
        }

        private void GetCurrentLayout() {
            switch (ViewportManager.CurrentLayout) {
                case ViewportLayout.Unbalanced:
                    activeLayout = (Art.Layout1, ViewportLayout.Unbalanced);
                    break;
                case ViewportLayout.Parallel:
                    activeLayout = (Art.Layout2, ViewportLayout.Parallel);
                    break;
                case ViewportLayout.Nintendo:
                    activeLayout = (Art.Layout3, ViewportLayout.Nintendo);
                    break;
            }
        }

        private void UpdateActiveSetting(GameSettings setting) {
            switch (setting) {
                case GameSettings.Layout:
                    activeLayout = layoutList.MoveThroughMenu(activeLayout);
                    ViewportManager.ChangeLayout(activeLayout.name);
                    break;
                case GameSettings.Volume:
                    activeVolume = volumeList.MoveThroughMenu(activeVolume);
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

            DrawSettingList(new Vector2(200, ViewportManager.MenuView.Height / 6));
            DrawGameLayoutView(new Vector2(ViewportManager.MenuView.Width * 2 / 3, ViewportManager.MenuView.Height / 4));

            Vector2 volumePosition = new Vector2(200, ViewportManager.MenuView.Height * 3 / 4);
            AudioManager.DrawGameSettingsView(volumePosition, activeSetting.name, activeVolume.name, isActive);

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }

        private void DrawSettingList(Vector2 position) {
            foreach ((string heading, GameSettings name) in settingList) {
                Color color = (activeSetting.name == name && isActive == false) ? Color.Moccasin : Color.Lime;
                BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareMedium, heading, position, color);
                position.Y += 100;
            }
        }

        private void DrawGameLayoutView(Vector2 position) {
            ResetActiveLayoutFrameBorder();
            foreach ((Texture2D picture, _) in layoutList) {
                BewareGame.Instance._spriteBatch.Draw(picture, position, null, Color.White, 0, new Vector2(picture.Width, picture.Height) / 2.0f, 0.2f, 0, 0.3f);
                if (picture == activeLayout.image) {
                    BewareGame.Instance._spriteBatch.Draw(activeLayoutFrame, position, null, Color.White, 0, new Vector2(picture.Width, picture.Height) / 2.0f, 0.2f, 0, 0.0f);
                }
                position.Y += 300;
            }
        }
    }
}
