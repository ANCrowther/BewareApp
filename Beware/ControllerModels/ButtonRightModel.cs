using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Beware.ControllerModels {
    class ButtonRightModel : IControllerModel {
        private Vector2 origin;

        public ButtonRightModel(Vector2 origin) {
            this.origin = origin;
        }

        public void Draw(Vector2 position, Mode mode, bool isMobile = true, float orientation = 0) {
            Texture2D picture = (mode == Mode.Move) ? Controls.Arrow : Controls.A;
            var gamepadState = GamePad.GetState(PlayerIndex.One);
            bool isActive = false;

            if (mode == Mode.Move) {
                isActive = ((gamepadState.GetButton() == Buttons.DPadRight));
            }
            if (mode == Mode.Shoot) {
                isActive = ((gamepadState.GetButton() == Buttons.B));
            }
            Color color = (isActive) ? Color.Red : Color.DarkGray;

            BewareGame.Instance._spriteBatch.Draw(Controls.Button_Generic, new Vector2(position.X + 75, position.Y), null, Color.White, orientation, this.origin, 0.5f, 0, 0.0f);
            
            if (mode == Mode.Move) {
                BewareGame.Instance._spriteBatch.Draw(picture, new Vector2(position.X + 75, position.Y), null, color, MathHelper.ToRadians(90.0f), new Vector2(picture.Width, picture.Height) / 2, 0.5f, 0, 0.0f);
            }
            if (mode == Mode.Shoot) {
                BewareGame.Instance._spriteBatch.Draw(picture, new Vector2(position.X + 75, position.Y), null, color, orientation, new Vector2(picture.Width, picture.Height) / 2, 0.5f, 0, 0.0f);
            }
        }
    }
}
