using Beware.Utilities;
using Microsoft.Xna.Framework;

namespace Beware.CardinalModels {
    class EModel : ICardinalModel {
        Vector2 origin;

        public EModel(Vector2 origin) {
            this.origin = origin;
        }

        public void Draw(Vector2 centerPosition, Vector2 direction) {
            BewareGame.Instance._spriteBatch.Draw((direction.X > 0 && direction.Y == 0) ? Art.RedPointer : Art.BluePointer, new Vector2(centerPosition.X + 100, centerPosition.Y), null, Color.White, 0, origin, 0.3f, 0, 0.0f);
        }
    }
}
