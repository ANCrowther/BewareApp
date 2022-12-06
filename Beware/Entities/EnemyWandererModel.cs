using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.Entities {
    public class EnemyWandererModel : EnemyModel {
        public EnemyWandererModel(Texture2D image, Vector2 position, int startingHealth = 3, int pointValue = 1) : base(image, position, startingHealth) {
            this.PointValue = pointValue;
            health.OnDeath += delegate { this.Die(); ScoreKeeper.AddPoints(pointValue); };
        }
    }
}
