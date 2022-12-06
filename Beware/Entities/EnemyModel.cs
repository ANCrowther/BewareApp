using Beware.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Beware.Entities {
    public abstract class EnemyModel : EntityModel {
        private int timeUntilStart = 60;
        public bool IsActive { get { return timeUntilStart <= 60; } }
        public int PointValue { get; protected set; }

        public event EventHandler OnCollide;

        public EnemyModel(Texture2D image, Vector2 position, int startingHealth) : base(startingHealth) {
            this.image = image;
            Position = position;
            CollisionRadius = image.Width / 2f;
            color = Color.Transparent;
        }

        public void HandleCollision(EnemyModel other) {
            var d = Position - other.Position;
            Velocity += 10 * d / (d.LengthSquared() + 1);
        }
    }
}
