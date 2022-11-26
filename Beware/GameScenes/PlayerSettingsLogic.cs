using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Beware.GameScenes {
    public class PlayerSettingsLogic : DrawableGameComponent {
        private bool isActive = false;
        private List<(string heading, PlayerSettings name)> settingList;
        private (string heading, PlayerSettings name) activeSetting;
        private List<(string heading, Keys name)> keyboardList;
        private (string heading, Keys name) activeKeyboard;
        private List<(string heading, Buttons name)> gamepadList;
        private (string heading, Buttons name) activeGamepad;

        public PlayerSettingsLogic() : base(BewareGame.Instance) {
            InitializeSettingList();
            InitializeKeyboardList();
            InitializeGamepadList();
        }

        private void InitializeSettingList() {
            settingList = new List<(string heading, PlayerSettings name)> {
                ("Keyboard", PlayerSettings.Keyboard),
                ("Gamepad", PlayerSettings.Gamepad)
            };
            activeSetting = ("Keyboard", PlayerSettings.Keyboard);
        }

        private void InitializeKeyboardList() {
            keyboardList = new List<(string heading, Keys name)> {
                ("Move Up", ControlMap.MoveUp),
                ("Move Down", ControlMap.MoveDown),
                ("Move Left", ControlMap.MoveLeft),
                ("Move Right", ControlMap.MoveRight),
                ("Aim Up", ControlMap.AimUp),
                ("Aim Down", ControlMap.AimDown),
                ("Aim Left", ControlMap.AimLeft),
                ("Aim Right", ControlMap.AimRight),
                ("Shoot", ControlMap.Shoot),
                ("Slow", ControlMap.Slow),
                ("Special", ControlMap.Special),
            };
            activeKeyboard = ("Move Up", ControlMap.MoveUp);
        }

        private void InitializeGamepadList() {
            gamepadList = new List<(string heading, Buttons name)> {
                ("Move", ControlMap.Move_pad),
                ("Aim", ControlMap.Aim_pad),
                ("Shoot", ControlMap.Shoot_pad),
                ("Slow", ControlMap.Slow_pad),
                ("Special", ControlMap.Special_pad)
            };
            activeGamepad = ("Move", ControlMap.Move_pad);
        }

        public override void Update(GameTime gameTime) {
            if (Input.WasKeyPressed(ControlMap.Back) || Input.WasButtonPressed(ControlMap.Back_pad)) {
                //BewareGame.Instance.Scene.SwitchScene(SceneManager.MenuWindow);
                SceneManager.SwitchScene(SceneManager.MenuWindow);
            }

            if (Input.WasKeyPressed(ControlMap.Enter) || Input.WasButtonPressed(ControlMap.Enter_pad)) {
                SwitchIsActiveStatus();
            }

            if (isActive == false) {
                activeSetting = settingList.MoveThroughMenu(activeSetting);
            }

            if (isActive == true) {
                UpdateActiveSetting(activeSetting.name);
            }

            AudioManager.Update();

            base.Update(gameTime);
        }

        private void SwitchIsActiveStatus() {
            isActive = !isActive;
        }

        private void UpdateActiveSetting(PlayerSettings name) {
            switch (name) {
                case PlayerSettings.Gamepad:

                    break;
                case PlayerSettings.Keyboard:
                    activeKeyboard = keyboardList.MoveThroughMenu(activeKeyboard);
                    UpdateKeyboardSetting();
                    break;
            }
        }

        private void UpdateKeyboardSetting() {

        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();

            if (AudioManager.IsMuted == true) {
                BewareGame.Instance._spriteBatch.Draw(Art.Mute, new Vector2(ViewportManager.MenuView.Width - 150, ViewportManager.MenuView.Height - 150), null, Color.White, 0, new Vector2(Art.Mute.Width, Art.Mute.Height) / 2, 0.25f, 0, 0.0f);
            }

            DrawSettingList(new Vector2(200, ViewportManager.MenuView.Height / 6));

            if (activeSetting.name == PlayerSettings.Keyboard) {
                DrawKeyboardList(new Vector2(1000, ViewportManager.MenuView.Height / 6));
            }

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }

        private void DrawSettingList(Vector2 position) {
            foreach ((string heading, PlayerSettings name) setting in settingList) {
                Color color = (activeSetting.name == setting.name && isActive == false) ? Color.Moccasin : Color.Lime;
                BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareMedium, setting.heading, position, color);
                position.Y += 100;
            }
        }

        private void DrawKeyboardList(Vector2 position) {
            foreach ((string heading, Keys name) item in keyboardList) {
                BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, item.heading, position, Color.White);
                Texture2D picture = MapPlayerControls.GetKeyPicture(item.name);
                BewareGame.Instance._spriteBatch.Draw(picture, new Vector2(position.X + 350, position.Y + 25), null, Color.White, 0, new Vector2(picture.Width, picture.Height) / 2.0f, 0.3f, 0, 0.3f);
                position.Y += 75;
            }
        }

        private void DrawGamepadList(Vector2 position) {

        }
    }
}
