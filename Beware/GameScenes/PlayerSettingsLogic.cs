using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Beware.GameScenes {
    public class PlayerSettingsLogic : DrawableGameComponent {
        private List<(string heading, PlayerSettings name)> settingMenuList;
        private (string heading, PlayerSettings name) activeMenuSetting;

        private List<(string heading, Keys name)> keyboardList;
        private (string heading, Keys name) activeKeyboard;

        private List<(string heading, Buttons name)> gamepadList;
        private (string heading, Buttons name) activeGamepad;

        private List<(string heading, object name)> genericSettingList;
        
        private bool isActive = false;
        private bool isSet = true;
        private float keyScale = 0.5f;
        private float controllerScale = 0.3f;
        private float masterVolume;
        private float timeShowingVolumeChange = 2.0f;
        private float timeLeft;
        private bool isVolumeChanged = false;

        public PlayerSettingsLogic() : base(BewareGame.Instance) {
            LoadSettingList();
            Refresh();
            LoadGenericSettingList();
            LoadActiveSettings();
            masterVolume = AudioManager.MasterVolumeLevel;
            Reset();
        }

        private void Reset() {
            isVolumeChanged = false;
            timeLeft = 0;
        }

        private void LoadGenericSettingList() {
            genericSettingList = new List<(string heading, object name)> {
                ("Pause", ControlMap.Pause),
                ("Back", ControlMap.Back),
                ("Enter", ControlMap.Enter),
                ("Mute", ControlMap.Mute),
                ("Vol. Up", ControlMap.VolumeUp),
                ("Vol. Down", ControlMap.VolumeDown),
                ("Pause", ControlMap.Pause_pad),
                ("Back", ControlMap.Back_pad),
                ("Enter", ControlMap.Enter_pad),
                ("Mute", ControlMap.Mute_pad),
                ("Vol. Up", ControlMap.VolumeUp_pad),
                ("Vol. Down", ControlMap.VolumeDown_pad)
            };
        }

        private void LoadSettingList() {
            settingMenuList = new List<(string heading, PlayerSettings name)> {
                ("Keyboard", PlayerSettings.Keyboard),
                ("Gamepad", PlayerSettings.Gamepad),
                ("Generic", PlayerSettings.Generic)
            };
        }

        private void LoadKeyboardList() {
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
        }

        private void LoadGamepadList() {
            gamepadList = new List<(string heading, Buttons name)> {
                ("Move", ControlMap.Move_pad),
                ("Aim", ControlMap.Aim_pad),
                ("Shoot", ControlMap.Shoot_pad),
                ("Slow", ControlMap.Slow_pad),
                ("Special", ControlMap.Special_pad)
            };
        }

        private void LoadActiveSettings() {
            activeGamepad = ("Move", ControlMap.Move_pad);
            activeKeyboard = ("Move Up", ControlMap.MoveUp);
            activeMenuSetting = ("Keyboard", PlayerSettings.Keyboard);
        }

        public override void Update(GameTime gameTime) {
            if ((Input.WasKeyPressed(ControlMap.Back) || Input.WasButtonPressed(ControlMap.Back_pad)) && isSet == true) {
                SceneManager.SwitchScene(SceneManager.MenuWindow);
            }

            if ((Input.WasKeyPressed(Keys.Left) || Input.WasKeyPressed(Keys.Right) ||
                Input.WasButtonPressed(Buttons.DPadLeft) || Input.WasButtonPressed(Buttons.DPadRight)) && isSet == true) {
                SwitchIsActiveStatus();
            }

            if (isActive == true && isSet == true) {
                MoveThroughMenu(activeMenuSetting.name);
                if (Input.WasKeyPressed(ControlMap.Enter) || Input.WasButtonPressed(ControlMap.Enter_pad)) {
                    SwitchIsSetStatus();
                }
            }

            if (isActive == true && isSet == false) {
                UpdateSetting();
                Refresh();
            }

            if (isActive == false) {
                MoveThroughMenu(PlayerSettings.Standard);
            }

            AudioManager.Update();
            TimeKeeper.Update();

            base.Update(gameTime);
        }

        private void Refresh() {
            LoadKeyboardList();
            LoadGamepadList();
        }

        private void SwitchIsActiveStatus() {
            isActive = !isActive;
        }

        private void SwitchIsSetStatus() {
            isSet = !isSet;
        }

        private void MoveThroughMenu(PlayerSettings name) {
            switch (name) {
                case PlayerSettings.Gamepad:
                    activeGamepad = gamepadList.MoveThroughMenu(activeGamepad);
                    break;
                case PlayerSettings.Keyboard:
                    activeKeyboard = keyboardList.MoveThroughMenu(activeKeyboard);
                    break;
                case PlayerSettings.Standard:
                    activeMenuSetting = settingMenuList.MoveThroughMenu(activeMenuSetting);
                    break;
            }
        }

        private void UpdateSetting() {
            if (activeMenuSetting.name == PlayerSettings.Keyboard) {
                var keyboardState = Keyboard.GetState();
                isSet = MapPlayerControls.MapNewControl<Keys>(keyboardList, activeKeyboard, keyboardState.GetKey());
            }
            if (activeMenuSetting.name == PlayerSettings.Gamepad) {
                var gamepadState = GamePad.GetState(PlayerIndex.One);
                isSet = MapPlayerControls.MapNewControl<Buttons>(gamepadList, activeGamepad, gamepadState.GetButton());
            }
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();
            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareLarge, "PLAYER SETTINGS", new Vector2(ViewportManager.MenuView.Width / 2 - Fonts.NovaSquareLarge.MeasureString("PLAYER SETTINGS").X / 2, 50), Color.BlueViolet);

            if (AudioManager.IsMuted == true) {
                BewareGame.Instance._spriteBatch.Draw(Art.Mute, new Vector2(ViewportManager.MenuView.Width - 150, ViewportManager.MenuView.Height - 150), null, Color.White, 0, new Vector2(Art.Mute.Width, Art.Mute.Height) / 2, 0.25f, 0, 0.0f);
            }

            if (isVolumeChanged == true) {
                int volume = AudioManager.MasterVolumeLevel;
                BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareLarge, $"{volume}", new Vector2(ViewportManager.MenuView.Width - 150 - Fonts.NovaSquareLarge.MeasureString($"{volume}").X / 2, ViewportManager.MenuView.Height - 150), Color.BlueViolet);
            }

            DrawSettingList(new Vector2(200, ViewportManager.MenuView.Height / 6));
            if (activeMenuSetting.name == PlayerSettings.Keyboard) {
                DrawKeyboardList(new Vector2(800, ViewportManager.MenuView.Height / 6));
            }
            if (activeMenuSetting.name == PlayerSettings.Gamepad) {
                DrawGamepadList(new Vector2(800, ViewportManager.MenuView.Height / 6));
            }
            if (activeMenuSetting.name == PlayerSettings.Generic) {
                DrawGenericList(new Vector2(800, ViewportManager.MenuView.Height / 6));
            }

            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }

        private void DrawSettingList(Vector2 position) {
            foreach ((string heading, PlayerSettings name) setting in settingMenuList) {
                Color color = (activeMenuSetting.name == setting.name && isActive == false) ? Color.Lime : Color.White;
                BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareMedium, setting.heading, position, color);
                position.Y += 100;
            }
        }

        private void DrawKeyboardList(Vector2 position) {
            int count = 1;
            foreach ((string heading, Keys name) item in keyboardList) {
                Texture2D picture = KeysArt.GetKeyPicture(item.name);
                Color color = (activeKeyboard.name == item.name && isActive == true) ? Color.Lime : Color.White;
                DrawList(position, item.heading, picture, keyScale, color);
                position = AdjustPosition(count++, position);
            }
        }

        private void DrawGamepadList(Vector2 position) {
            int count = 1;
            foreach ((string heading, Buttons name) item in gamepadList) {
                Texture2D picture = ControllerArt.GetControllerArt(item.name);
                Color color = (activeGamepad.name == item.name && isActive == true) ? Color.Lime : Color.White;
                DrawList(position, item.heading, picture, controllerScale, color);
                position = AdjustPosition(count, position);
            }
        }

        private void DrawGenericList(Vector2 position) {
            int count = 1;
            foreach ((string heading, object name) item in genericSettingList) {
                Texture2D picture;
                if (item.name is Keys) {
                    picture = KeysArt.GetKeyPicture((Keys)item.name);
                } else {
                    picture = ControllerArt.GetControllerArt((Buttons)item.name);
                }

                float scale = (item.name is Keys) ? keyScale : controllerScale;
                DrawList(position, item.heading, picture, scale, Color.White);
                position = AdjustPosition(count++, position);
            }
        }

        private Vector2 AdjustPosition(int count, Vector2 position) {
            if (count == 6) {
                position = new Vector2(position.X + 800, ViewportManager.MenuView.Height / 6);
            } else {
                position.Y += 125;
            }
            return position;
        }

        private void DrawList(Vector2 position,string heading, Texture2D picture, float scale, Color color) {
            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareMedium, heading, position, color);
            BewareGame.Instance._spriteBatch.Draw(picture, new Vector2(position.X + 550, position.Y + 50), null, Color.White, 0, new Vector2(picture.Width, picture.Height) / 2.0f, scale, 0, 0.3f);
        }
    }
}
