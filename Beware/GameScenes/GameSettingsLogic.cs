using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Beware.GameScenes {
    class GameSettingsLogic : DrawableGameComponent {
        public View view;
        private List<(string heading, GameSettings name)> settingList;
        private (string heading, GameSettings name) activeSetting;
        private bool isActive = false;

        public GameSettingsLogic(View inputView) : base(BewareGame.Instance) {
            view = inputView;

            settingList = new List<(string heading, GameSettings name)> {
                ("Layout", GameSettings.Layout),
                ("Volume", GameSettings.Volume),
                ("SFX Volume", GameSettings.SFXVolume)
            };
            activeSetting = ("Layout", GameSettings.Layout);
        }

        public override void Update(GameTime gameTime) {
            if (Input.WasKeyPressed(ControlMap.Back) || Input.WasButtonPressed(ControlMap.Back_pad)) {
                BewareGame.Instance.Scene.SwitchScene(SceneManager.MenuWindow);
            }

            if (isActive == false) {
                MoveThroughMenuOptions();
            }
            
            base.Update(gameTime);
        }

        private void MoveThroughMenuOptions() {
            if (Input.WasKeyPressed(Keys.Up) || Input.WasButtonPressed(Buttons.DPadUp)) {
                SelectMenuUp();
            }
            if (Input.WasKeyPressed(Keys.Down) || Input.WasButtonPressed(Buttons.DPadDown)) {
                SelectMenuDown();
            }
        }

        private void SelectMenuDown() {
            int index = settingList.IndexOf(activeSetting);
            if (index < settingList.Count - 1) {
                activeSetting = settingList[index + 1];
            } else {
                activeSetting = settingList[0];
            }
        }

        private void SelectMenuUp() {
            int index = settingList.IndexOf(activeSetting);
            if (index > 0) {
                activeSetting = settingList[index - 1];
            } else {
                activeSetting = settingList[settingList.Count - 1];
            }
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();
            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareLarge, "GAME SETTINGS", new Vector2(ViewportManager.MenuView.Width / 2 - Fonts.NovaSquareLarge.MeasureString("GAME SETTINGS").X / 2, 50), Color.BlueViolet);

            DrawGameLayoutView();

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }

        private void DrawGameLayoutView() {
            Texture2D picture = (ViewportManager.CurrentLayout == ViewportLayout.Layout1) ? Art.Layout1 : Art.Layout2;
            BewareGame.Instance._spriteBatch.Draw(picture, new Vector2(ViewportManager.MenuView.Width * 5 / 6, ViewportManager.MenuView.Height / 2), null, Color.White, 0, new Vector2(picture.Width, picture.Height) / 2.0f, 0.3f, 0, 0.0f);
        }
    }
}
