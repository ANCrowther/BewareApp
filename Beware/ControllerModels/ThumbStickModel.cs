using Beware.Enums;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.ControllerModels {
    class ThumbStickModel : IControllerModel {
        private Vector2 origin;

        public ThumbStickModel(Vector2 origin) {
            this.origin = origin;
        }

        public void Draw(Vector2 position, Mode mode = Mode.Move, bool isMobile = true, float orientation = 0) {
            Texture2D picture = (isMobile) ? ControllerArt.Button_ThumbMoving : ControllerArt.Button_ThumbStationary;
            BewareGame.Instance._spriteBatch.Draw(picture, position, null, Color.White, orientation, this.origin, 0.5f, 0, 0.0f);
        }
    }
}
