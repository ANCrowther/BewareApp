using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.Entities {
    class EnemyFollowerModel : EnemyModel {
        public EnemyFollowerModel(Texture2D image, Vector2 position) : base(image, position) {
            this.PointValue = 2;
            this.health = new Health(2);
            health.OnDeath += delegate { this.Die(); ScoreKeeper.AddPoints(PointValue); };
        }
    }
}
