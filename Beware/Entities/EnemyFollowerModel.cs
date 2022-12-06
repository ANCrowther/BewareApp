using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.Entities {
    class EnemyFollowerModel : EnemyModel {
        public EnemyFollowerModel(Texture2D image, Vector2 position, int startingHealth = 2, int pointValue = 2) : base(image, position, startingHealth) {
            this.PointValue = pointValue;
            health.OnDeath += delegate { this.Die(); ScoreKeeper.AddPoints(pointValue); };
        }
    }
}
