using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        private float keyScale = 0.5f;
        private float controllerScale = 0.3f;

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
                    activeGamepad = gamepadList.MoveThroughMenu(activeGamepad);
                    UpdateGamepadSetting();
                    break;
                case PlayerSettings.Keyboard:
                    activeKeyboard = keyboardList.MoveThroughMenu(activeKeyboard);
                    UpdateKeyboardSetting();
                    break;
            }
        }

        private void UpdateGamepadSetting() {
            
        }

        private void UpdateKeyboardSetting() {

        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();
            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareLarge, "PLAYER SETTINGS", new Vector2(ViewportManager.MenuView.Width / 2 - Fonts.NovaSquareLarge.MeasureString("PLAYER SETTINGS").X / 2, 50), Color.BlueViolet);

            if (AudioManager.IsMuted == true) {
                BewareGame.Instance._spriteBatch.Draw(Art.Mute, new Vector2(ViewportManager.MenuView.Width - 150, ViewportManager.MenuView.Height - 150), null, Color.White, 0, new Vector2(Art.Mute.Width, Art.Mute.Height) / 2, 0.25f, 0, 0.0f);
            }

            DrawSettingList(new Vector2(200, ViewportManager.MenuView.Height / 6));
            if (activeSetting.name == PlayerSettings.Keyboard) {
                DrawKeyboardList(new Vector2(900, ViewportManager.MenuView.Height / 6));
            }
            if (activeSetting.name == PlayerSettings.Gamepad) {
                DrawGamepadList(new Vector2(900, ViewportManager.MenuView.Height / 6));
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
            //foreach ((string heading, Keys name) item in keyboardList) {
            //    //BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, item.heading, position, Color.White);
            //    Texture2D picture = KeysArt.GetKeyPicture(item.name);
            //    //BewareGame.Instance._spriteBatch.Draw(picture, new Vector2(position.X + 350, position.Y + 25), null, Color.White, 0, new Vector2(picture.Width, picture.Height) / 2.0f, 0.3f, 0, 0.3f);
            //    DrawList(position, item.heading, picture);
            //    position.Y += 100;
            //}

            for (int i = 0; i < keyboardList.Count; i++) {
                Texture2D picture = KeysArt.GetKeyPicture(keyboardList[i].name);
                DrawList(position, keyboardList[i].heading, picture, keyScale);
                if (i == 5) {
                    position = new Vector2(1700, ViewportManager.MenuView.Height / 6);
                } else {
                    position.Y += 125;
                }
            }
        }

        private void DrawGamepadList(Vector2 position) {
            foreach ((string heading, Buttons name) item in gamepadList) {
                Texture2D picture = ControllerArt.GetControllerArt(item.name);
                DrawList(position, item.heading, picture, controllerScale);
                position.Y += 125;
            }
        }

        private void DrawList(Vector2 position,string heading, Texture2D picture, float scale) {
            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareMedium, heading, position, Color.White);
            BewareGame.Instance._spriteBatch.Draw(picture, new Vector2(position.X + 550, position.Y + 50), null, Color.White, 0, new Vector2(picture.Width, picture.Height) / 2.0f, scale, 0, 0.3f);
        }
    }
}
