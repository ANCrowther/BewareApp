using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.CardinalModels {
    class NWNModel : ICardinalModel {
        Vector2 origin;

        public NWNModel(Vector2 origin) {
            this.origin = origin;
        }

        public void Draw(Vector2 centerPosition, Vector2 direction) {
            BewareGame.Instance._spriteBatch.Draw(((direction.X < 0 && direction.Y < 0) || (direction.X == 0 && direction.Y < 0)) ? Art.RedPointer : Art.BluePointer, new Vector2(centerPosition.X - 38, centerPosition.Y - 92), null, Color.White, MathHelper.ToRadians(-112.5f), origin, 0.3f, 0, 0.0f);
        }
    }
}
