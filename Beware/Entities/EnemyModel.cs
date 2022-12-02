using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Beware.Entities {
    public abstract class EnemyModel : EntityModel {
        private int timeUntilStart = 60;
        public bool IsActive { get { return timeUntilStart <= 60; } }
        public int PointValue { get; protected set; }

        public EnemyModel(Texture2D image, Vector2 position) {
            this.image = image;
            Position = position;
            CollisionRadius = image.Width / 2f;
            color = Color.Transparent;
        }

        public virtual void WasShot() {
            IsExpired = true;
            ScoreKeeper.AddPoints(PointValue);
            ScoreKeeper.IncreaseMultiplier();
            //Sounds.Explosion.Play(AudioManager.SFXVolumeLevel.ToFloat(), rand.NextFloat(-0.2f, 0.2f), 0);
        }

        public void HandleCollision(EnemyModel other) {
            var d = Position - other.Position;
            Velocity += 10 * d / (d.LengthSquared() + 1);
        }
    }
}
