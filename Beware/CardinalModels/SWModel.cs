using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.CardinalModels {
    class SWModel : ICardinalModel {
        Vector2 origin;

        public SWModel(Vector2 origin) {
            this.origin = origin;
        }

        public void Draw(Vector2 centerPosition, Vector2 direction) {
            BewareGame.Instance._spriteBatch.Draw((direction.X < 0 && direction.Y > 0) ? Art.RedPointer : Art.BluePointer, new Vector2(centerPosition.X - 75, centerPosition.Y + 75), null, Color.White, MathHelper.ToRadians(135.0f), origin, 0.3f, 0, 0.0f);
        }
    }
}
