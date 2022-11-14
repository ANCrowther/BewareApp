using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.CardinalModels {
    class WSWModel : ICardinalModel {
        Vector2 origin;

        public WSWModel(Vector2 origin) {
            this.origin = origin;
        }

        public void Draw(Vector2 centerPosition, Vector2 direction) {
            BewareGame.Instance._spriteBatch.Draw(((direction.X < 0 && direction.Y > 0) || (direction.X < 0 && direction.Y == 0)) ? Art.RedPointer : Art.BluePointer, new Vector2(centerPosition.X - 92, centerPosition.Y + 38), null, Color.White, MathHelper.ToRadians(157.5f), origin, 0.3f, 0, 0.0f);
        }
    }
}
