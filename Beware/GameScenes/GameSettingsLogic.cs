using Beware.Enums;
using Beware.ExtensionSupport;
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

        private GameSettingsMenu activeMenu;

        private bool isActive = false;
        private string windowTitle = $"GAME SETTINGS";

        public GameSettingsLogic() : base(BewareGame.Instance) {
            activeMenu = GameSettingsMenu.Main;

            settingList = new List<(string heading, GameSettings name)> {
                ("Layout", GameSettings.Layout),
                ("Volume Levels", GameSettings.Volume)
            };
            activeSetting = ("Layout", GameSettings.Layout);

            layoutList = new List<(Texture2D image, ViewportLayout name)> {
                (Art.NoPanelLayout, ViewportLayout.NoPanel),
                (Art.LeftPanelLayout, ViewportLayout.LeftPanel),
                (Art.RightPanelLayout, ViewportLayout.RightPanel),
                (Art.NintendoLayout, ViewportLayout.Nintendo)
            };
            activeLayout = (Art.NoPanelLayout, ViewportLayout.NoPanel);
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
            if (Input.WasButtonPressed(Buttons.LeftThumbstickLeft) || Input.WasButtonPressed(Buttons.LeftThumbstickRight)) {
                UpdateActiveList();
                isActive = !isActive;
            }
            UpdateActiveSetting(activeMenu);

            base.Update(gameTime);
        }

        private void UpdateActiveList() {
            if (activeMenu != GameSettingsMenu.Main) {
                activeMenu = GameSettingsMenu.Main;
            }
            else {
                if (activeSetting.name == GameSettings.Layout) {
                    activeMenu = GameSettingsMenu.Layout;
                }
                if (activeSetting.name == GameSettings.Volume) {
                    activeMenu = GameSettingsMenu.Volume;
                }
            }
        }

        private void GetCurrentLayout() {
            switch (ViewportManager.CurrentLayout) {
                case ViewportLayout.NoPanel:
                    activeLayout = (Art.NoPanelLayout, ViewportLayout.NoPanel);
                    break;
                case ViewportLayout.LeftPanel:
                    activeLayout = (Art.LeftPanelLayout, ViewportLayout.LeftPanel);
                    break;
                case ViewportLayout.RightPanel:
                    activeLayout = (Art.RightPanelLayout, ViewportLayout.RightPanel);
                    break;
                case ViewportLayout.Nintendo:
                    activeLayout = (Art.NintendoLayout, ViewportLayout.Nintendo);
                    break;
            }
        }

        private void UpdateActiveSetting(GameSettingsMenu setting) {
            switch (setting) {
                case GameSettingsMenu.Main:
                    activeSetting = settingList.MoveThroughMenu(activeSetting);
                    break;
                case GameSettingsMenu.Layout:
                    activeLayout = layoutList.MoveThroughMenu(activeLayout);
                    ViewportManager.ChangeLayout(activeLayout.name);
                    break;
                case GameSettingsMenu.Volume:
                    activeVolume = volumeList.MoveThroughMenu(activeVolume);
                    AudioManager.Update(activeVolume.name);
                    break;
            }
        }

        private void ResetActiveLayoutFrameBorder() {
            activeLayoutFrame = new Texture2D(GraphicsDevice, activeLayout.image.Width, activeLayout.image.Height);
            activeLayoutFrame.CreateBorder(15, Color.Yellow);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();
            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareLarge, windowTitle, new Vector2(ViewportManager.MenuView.Width / 2 - Fonts.NovaSquareLarge.MeasureString(windowTitle).X / 2, 50), Color.BlueViolet);

            DrawSettingList(new Vector2(200, ViewportManager.MenuView.Height / 6));
            DrawGameLayoutView(new Vector2(ViewportManager.MenuView.Width * 3 / 4, ViewportManager.MenuView.Height / 4));

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
