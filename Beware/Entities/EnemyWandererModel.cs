using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.Entities {
    public class EnemyWandererModel : EnemyModel {
        public EnemyWandererModel(Texture2D image, Vector2 position) : base(image, position) {
            this.PointValue = 1;
        }
    }
}
