using Beware.EntityFeatures;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.Entities {
    public class EnemyWandererModel : EnemyModel {
        public EnemyWandererModel(Texture2D image, Vector2 position, int startingHealth = 2, int pointValue = 1, int startingImpactDamage = 5, Sprite sprite = null) 
            : base(image, position, startingHealth, startingImpactDamage, sprite) {
            Health.OnDeath += delegate { this.Die(); ScoreKeeper.AddPoints(pointValue); };
        }
    }
}
