using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.Entities {
    class EnemyFollowerModel : EnemyModel {
        public EnemyFollowerModel(Texture2D image, Vector2 position) : base(image, position) {
            this.PointValue = 2;
        }
    }
}
