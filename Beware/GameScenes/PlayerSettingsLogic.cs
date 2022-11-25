using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
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
                ("Aim Up", ControlMap.MoveUp),
                ("Aim Down", ControlMap.MoveDown),
                ("Aim Left", ControlMap.MoveLeft),
                ("Aim Right", ControlMap.MoveRight),
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

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }

        private void DrawKeyboardList() {

        }

        private void DrawGamepadList() {

        }
    }
}
