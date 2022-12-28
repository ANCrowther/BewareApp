using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.Entities {
    class EnemyFollowerModel : EnemyModel {
        public EnemyFollowerModel(Texture2D image, Vector2 position, int startingHealth = 3, int pointValue = 2) 
            : base(image, position, startingHealth) {
            health.OnDeath += delegate { this.Die(); ScoreKeeper.AddPoints(pointValue); };
        }

        public override void Update() {
            //if (this.Shield != null) {
            //    this.Shield.Position = this.Position;
            //    this.Shield.Orientation = this.Orientation;
            //}
            base.Update();
        }
    }
}
