using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.CardinalModels {
    class SModel : ICardinalModel {
        Vector2 origin;

        public SModel(Vector2 origin) {
            this.origin = origin;
        }

        public void Draw(Vector2 centerPosition, Vector2 direction) {
            BewareGame.Instance._spriteBatch.Draw((direction.X == 0 && direction.Y > 0) ? Art.RedPointer : Art.BluePointer, new Vector2(centerPosition.X, centerPosition.Y + 100), null, Color.White, MathHelper.ToRadians(90.0f), origin, 0.3f, 0, 0.0f);
        }
    }
}
