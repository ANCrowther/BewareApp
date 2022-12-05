using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.Entities {
    public class EnemyWandererModel : EnemyModel {
        public EnemyWandererModel(Texture2D image, Vector2 position) : base(image, position) {
            this.PointValue = 1;
            this.health = new Health(3);
            health.OnDeath += delegate { this.Die(); ScoreKeeper.AddPoints(PointValue); };
        }
    }
}
