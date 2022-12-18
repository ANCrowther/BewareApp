using Beware.ExtensionSupport;
using Beware.Inputs;
using Beware.Managers;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Beware.GameScenes {
    public class PlayerSettingsLogic : DrawableGameComponent {
        private List<(string heading, Buttons name)> gamepadList;
        private (string heading, Buttons name) activeGamepad;

        private List<(string heading, Buttons name)> genericGamepadList;

        private bool isSet = true;

        public PlayerSettingsLogic() : base(BewareGame.Instance) {
            Refresh();
        }

        public override void Update(GameTime gameTime) {
            if (Input.WasButtonPressed(ControlMap.Back) && isSet == true) {
                SceneManager.SwitchScene(SceneManager.MenuWindow);
            }

            if (isSet == true) {
                activeGamepad = gamepadList.MoveThroughMenu(activeGamepad);
                if (Input.WasButtonPressed(ControlMap.Enter) || Input.WasButtonPressed(ControlMap.Accept)) {
                    SwitchIsSetStatus();
                }
            }
            if (isSet == false) {
                UpdateSetting();
                Refresh();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            BewareGame.Instance._spriteBatch.Begin();
            BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareLarge, "PLAYER SETTINGS", new Vector2(ViewportManager.MenuView.Width / 2 - Fonts.NovaSquareLarge.MeasureString("PLAYER SETTINGS").X / 2, 50), Color.BlueViolet);

            Vector2 gamepadPosition = new Vector2(ViewportManager.MenuView.Width / 2 + 300, ViewportManager.MenuView.Height / 2 + 100);
            BewareGame.Instance._spriteBatch.Draw(ControllerArt.Gamepad, gamepadPosition, null, Color.White, 0, new Vector2(ControllerArt.Gamepad.Width, ControllerArt.Gamepad.Height) / 2, 0.5f, 0, 0.0f);
            DrawCommmands(new Vector2(100, ViewportManager.MenuView.Height / 6));
            DrawLabels(gamepadPosition);
            BewareGame.Instance._spriteBatch.End();
            base.Draw(gameTime);
        }

        private void DrawLabels(Vector2 position) {
            foreach ((string heading, Buttons name) setting in gamepadList) {
                BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, setting.heading, CommandPosition(setting.name, position), Color.Black);
            }
            foreach ((string heading, Buttons name) setting in genericGamepadList) {
                if (setting.heading == "Pause") {
                    BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, $"/{setting.heading}", CommandPosition(setting.name, new Vector2(position.X + 100, position.Y)), Color.Black);
                    continue;
                }
                BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareSmall, setting.heading, CommandPosition(setting.name, position), Color.Black);
            }
        }

        private void DrawCommmands(Vector2 position) {
            foreach ((string heading, Buttons name) setting in gamepadList) {
                Color color = (activeGamepad.name == setting.name) ? Color.Lime : Color.White;
                BewareGame.Instance._spriteBatch.DrawString(Fonts.NovaSquareMedium, setting.heading, position, color);
                position.Y += 75;
            }
        }

        private Vector2 CommandPosition(Buttons name, Vector2 position) {
            Vector2 output = Vector2.Zero;
            if (name == Buttons.LeftStick) {
                output = new Vector2(position.X - 680, position.Y - 165);
            }
            if (name == Buttons.RightStick) {
                output = new Vector2(position.X + 580, position.Y + 120);
            }
            if (name == Buttons.LeftShoulder) {
                output = new Vector2(position.X - 670, position.Y - 360);
            }
            if (name == Buttons.RightShoulder) {
                output = new Vector2(position.X + 580, position.Y - 360);
            }
            if (name == Buttons.LeftTrigger) {
                output = new Vector2(position.X - 670, position.Y - 460);
            }
            if (name == Buttons.RightTrigger) {
                output = new Vector2(position.X + 580, position.Y - 450);
            }
            if (name == Buttons.A) {
                output = new Vector2(position.X + 580, position.Y - 75);
            }
            if (name == Buttons.B) {
                output = new Vector2(position.X + 580, position.Y - 160);
            }
            if (name == Buttons.X) {
                output = new Vector2(position.X + 580, position.Y + 15);
            }
            if (name == Buttons.Y) {
                output = new Vector2(position.X + 580, position.Y - 250);
            }
            if (name == Buttons.Back) {
                output = new Vector2(position.X - 250, position.Y - 500);
            }
            if (name == Buttons.Start) {
                output = new Vector2(position.X + 100, position.Y - 500);
            }
            if (name == Buttons.DPadUp) {
                // TODO: figure out the vector offset.
            }
            if (name == Buttons.DPadDown) {
                output = new Vector2(position.X - 200, position.Y + 350);
            }
            if (name == Buttons.DPadLeft) {
                output = new Vector2(position.X - 475, position.Y + 300);
            }
            if (name == Buttons.DPadRight) {
                output = new Vector2(position.X - 80, position.Y + 300);
            }
            return output;
        }

        private void LoadGamepadList() {
            gamepadList = new List<(string heading, Buttons name)> {
                ("Move", ControlMap.Move),
                ("Aim", ControlMap.Aim),
                ("Shoot", ControlMap.Shoot),
                ("Boost", ControlMap.Boost),
                ("Slow", ControlMap.Slow),
                ("Special", ControlMap.Special),
                ("Switch Special", ControlMap.SwitchSpecial),
                ("Accept", ControlMap.Accept)
            };
        }

        private void LoadGenericGamepadList() {
            genericGamepadList = new List<(string heading, Buttons name)> {
                ("Back", ControlMap.Back),
                ("Enter", ControlMap.Enter),
                ("Mute", ControlMap.Mute),
                ("Volume Up", ControlMap.VolumeUp),
                ("Volume Down", ControlMap.VolumeDown),
                ("Pause", ControlMap.Pause)
            };
        }

        private void Refresh() {
            LoadGamepadList();
            LoadGenericGamepadList();
        }

        private void SwitchIsSetStatus() {
            isSet = !isSet;
        }

        private void UpdateSetting() {
            var gamepadState = GamePad.GetState(PlayerIndex.One);
            isSet = MapPlayerControls.MapNewControl<Buttons>(gamepadList, activeGamepad, gamepadState.GetButton());
        }
    }
}
