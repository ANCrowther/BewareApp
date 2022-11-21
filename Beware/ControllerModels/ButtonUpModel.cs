using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Beware.ControllerModels {
    public class ButtonUpModel : IControllerModel {
        private Vector2 origin;

        public ButtonUpModel(Vector2 origin) {
            this.origin = origin;
        }

        public void Draw(Vector2 position, Mode mode, bool isMobile = true, float orientation = 0) {
            Texture2D picture = (mode == Mode.Move) ? Controls.Arrow : Controls.X;
            var gamepadState = GamePad.GetState(PlayerIndex.One);
            bool isActive = false;

            if (mode == Mode.Move) {
                isActive = ((gamepadState.GetButton() == Buttons.DPadUp));
            }
            if (mode == Mode.Shoot) {
                isActive = ((gamepadState.GetButton() == Buttons.Y));
            }
            Color color = (isActive) ? Color.Red : Color.DarkGray;
            
            BewareGame.Instance._spriteBatch.Draw(Controls.Button_Generic, new Vector2(position.X, position.Y - 75), null, Color.White, orientation, this.origin, 0.5f, 0, 0.0f);
            BewareGame.Instance._spriteBatch.Draw(picture, new Vector2(position.X, position.Y - 75), null, color, orientation, new Vector2(picture.Width, picture.Height) / 2, 0.5f, 0, 0.0f);
        }
    }
}
