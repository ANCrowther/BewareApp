using Beware.EntityFeatures;
using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.Entities {
    class EnemyFollowerModel : EnemyModel {
        public EnemyFollowerModel(Texture2D image, Vector2 position, int startingHealth = 3, int pointValue = 2, int startingImpactDamage = 5, Sprite sprite = null) 
            : base(image, position, startingHealth, startingImpactDamage, sprite) {
            Health.OnDeath += delegate { this.Die(); ScoreKeeper.AddPoints(pointValue); };
        }

        public override void Update() {
            base.Update();
        }
    }
}
